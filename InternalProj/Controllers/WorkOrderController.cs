using Microsoft.AspNetCore.Mvc;
using InternalProj.Models;
using InternalProj.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using InternalProj.Data;
using Newtonsoft.Json;

namespace InternalProj.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()   
        {
            var viewModel = new WorkOrderViewModel
            {
                WorkOrder = new WorkOrderMaster(),
                Machines = _context.Machines.Where(s => s.Active == "Y").ToList(),
                DeliveryMasters = _context.DeliveryMasters.Where(s => s.Active == "Y").ToList(),
                DeliveryModes = _context.DeliveryModes.Where(s => s.Active == "Y").ToList(),
                OrderVias = _context.OrderVias.Where(s => s.Active == "Y").ToList(),
                WorkTypes = _context.WorkTypes.Where(s => s.Active == "Y").ToList(),
                Customers = _context.CustomerRegs.Where(a => a.Active == "Y").ToList(),
                Branches = _context.Branches.Where(s => s.Active == "Y").ToList(),
                StaffRegs = _context.StaffRegs.Where(s => s.Active == "Y").ToList(),
                MainHeads = _context.MainHeads.Include(m => m.SubHeads)
                                              .Where(s => s.Active == "Y")
                                              .ToList(),
                SubHeads = _context.SubHeads.Where(s => s.Active == "Y").ToList(),
                Albums = _context.Albums.Where(s => s.Active == "Y").ToList(),
                ChildSubHeads = _context.ChildSubHeads.Where(s => s.Active == "Y").ToList(),
                RateMasterList = _context.RateMasters.Where(e => e.Active == "Y").ToList(),                
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetCustomerDetailsById(int id)
        {
            Console.WriteLine($"Received ID: {id}");
            var customer = _context.CustomerRegs
                .Where(c => c.Id == id && c.Active == "Y")
                .Join(_context.CustomerContacts,
                      reg => reg.Id,
                      contact => contact.CustomerId,
                      (reg, contact) => new
                      {
                          FullName = reg.FirstName + " " + reg.LastName,
                          Mobile = contact.Phone1
                      })
                .FirstOrDefault();

            return Json(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Create(WorkOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelError in ModelState)
                {
                    foreach (var error in modelError.Value.Errors)
                    {
                        Console.WriteLine($"Key: {modelError.Key}, Error: {error.ErrorMessage}");
                    }
                }

                PopulateDropdowns(model);
                return View(model);
            }

            Console.WriteLine($"WorkDetailsList count: {model.WorkDetailsList?.Count ?? 0}");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                model.WorkOrder.Active = "Y";
                model.WorkOrder.Wdate = DateTime.UtcNow;

                if (model.WorkOrder.Ddate.HasValue)
                {
                    if (model.WorkOrder.Ddate.Value < DateTime.UtcNow)
                    {
                        ModelState.AddModelError("WorkOrder.Ddate", "Delivery date cannot be in the past.");
                        PopulateDropdowns(model);
                        return View(model);
                    }

                    model.WorkOrder.Ddate = model.WorkOrder.Ddate.Value.ToUniversalTime();
                }

                // Save WorkOrder
                _context.WorkOrders.Add(model.WorkOrder);
                await _context.SaveChangesAsync(); // Required to get WorkOrderId

                if (model.WorkDetailsList == null || !model.WorkDetailsList.Any())
                {
                    ModelState.AddModelError("", "Please add at least one work detail entry.");
                    PopulateDropdowns(model);
                    return View(model);
                }

                double subTotal = 0;

                foreach (var detail in model.WorkDetailsList)
                {
                    if (detail.Qty <= 0)
                    {
                        ModelState.AddModelError("", "Quantity must be greater than 0.");
                        PopulateDropdowns(model);
                        return View(model);
                    }

                    var subHeadName = await _context.SubHeads
                        .Where(s => s.SubHeadId == detail.SubheadId)
                        .Select(s => s.SubHeadName)
                        .FirstOrDefaultAsync();

                    var sizeName = await _context.Albums
                        .Where(s => s.SizeId == detail.SizeId)
                        .Select(s => s.Size)
                        .FirstOrDefaultAsync();

                    var mainHead = await _context.MainHeads
                        .FirstOrDefaultAsync(m => m.MainHeadId == detail.MainHeadId);

                    if (mainHead == null)
                    {
                        ModelState.AddModelError("", $"Invalid MainHeadId: {detail.MainHeadId}. It does not exist.");
                        PopulateDropdowns(model);
                        return View(model);
                    }

                    // Handle ChildSubheadId: set to null if invalid or absent
                    if (detail.ChildSubheadId != null && detail.ChildSubheadId != 0)
                    {
                        var childExists = await _context.ChildSubHeads
                            .AnyAsync(c => c.ChildSubHeadId == detail.ChildSubheadId);

                        if (!childExists)
                        {
                            // ChildSubheadId invalid - ignore and set null
                            Console.WriteLine($"Warning: Invalid ChildSubheadId {detail.ChildSubheadId}, setting to null.");
                            detail.ChildSubheadId = null;
                        }
                    }
                    else
                    {
                        detail.ChildSubheadId = null;
                    }

                    if (detail.Rate > 0.00)
                    {
                        var existingRate = await _context.RateMasters
                            .FirstOrDefaultAsync(r => r.SubHeadId == detail.SubheadId && r.SizeId == detail.SizeId && r.Active == "Y");

                        if (existingRate == null)
                        {
                            existingRate = new RateMaster
                            {
                                SubHeadId = detail.SubheadId,
                                SizeId = detail.SizeId,
                                MainHeadId = detail.MainHeadId,
                                Rate = Math.Round((decimal)detail.Rate, 2),
                                Active = "Y",
                                Details = $"{subHeadName} - {sizeName}"
                            };

                            _context.RateMasters.Add(existingRate);

                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"RateMaster save error: {ex.Message}");
                                throw;
                            }
                        }
                        else if (existingRate.Rate != (decimal)detail.Rate)
                        {
                            existingRate.Rate = Math.Round((decimal)detail.Rate, 2);
                            existingRate.Details = $"{subHeadName} - {sizeName}";
                            _context.RateMasters.Update(existingRate);
                            await _context.SaveChangesAsync();
                        }

                        detail.Rate = (double)existingRate.Rate;
                    }

                    Console.WriteLine($"subHeadName: {subHeadName}");
                    Console.WriteLine($"sizeName: {sizeName}");

                    detail.WorkOrderId = model.WorkOrder.WorkOrderId;
                    detail.GTotal = detail.Qty * detail.Rate;
                    detail.Tax ??= 0;
                    detail.Cess ??= 0;
                    detail.Active = "Y";

                    subTotal += detail.GTotal;

                    _context.WorkDetails.Add(detail);
                }

                model.WorkOrder.SubTotal = Math.Round(subTotal, 2);
                _context.WorkOrders.Update(model.WorkOrder);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["SuccessMessage"] = "Work Order created successfully.";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error: {ex.Message}");
                //ModelState.AddModelError("", "An error occurred while saving the work order.");
                TempData["ErrorMessage"] = "An error occurred while saving the work order.";
                PopulateDropdowns(model);
                return View(model);
            }
        }




        //public async Task<IActionResult> Create(WorkOrderViewModel model)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            foreach (var modelError in ModelState)
        //            {
        //                foreach (var error in modelError.Value.Errors)
        //                {
        //                    Console.WriteLine($"Key: {modelError.Key}, Error: {error.ErrorMessage}");
        //                }
        //            }

        //            PopulateDropdowns(model);
        //            return View(model);
        //        }

        //        Console.WriteLine($"WorkDetailsList count: {model.WorkDetailsList?.Count ?? 0}");

        //    try
        //    {
        //            model.WorkOrder.Active = "Y";
        //            model.WorkOrder.Wdate = DateTime.UtcNow;

        //            // Validate delivery date
        //            if (model.WorkOrder.Ddate.HasValue)
        //            {
        //                if (model.WorkOrder.Ddate.Value < DateTime.UtcNow)
        //                {
        //                    ModelState.AddModelError("WorkOrder.Ddate", "Delivery date cannot be in the past.");
        //                    PopulateDropdowns(model);
        //                    return View(model);
        //                }

        //                model.WorkOrder.Ddate = model.WorkOrder.Ddate.Value.ToUniversalTime();
        //            }

        //            // Save WorkOrderMaster
        //            _context.WorkOrders.Add(model.WorkOrder);
        //            await _context.SaveChangesAsync(); // Ensure WorkOrderId is generated

        //            // Validate WorkDetails
        //            if (model.WorkDetailsList == null || !model.WorkDetailsList.Any())
        //            {
        //                ModelState.AddModelError("", "Please add at least one work detail entry.");
        //                PopulateDropdowns(model);
        //                return View(model);
        //            }

        //            double subTotal = 0;

        //        foreach (var detail in model.WorkDetailsList)
        //        {
        //            Console.WriteLine($"Detail: MainHeadId={detail.MainHeadId}, SubheadId={detail.SubheadId}, SizeId={detail.SizeId}, Qty={detail.Qty}, Rate={detail.Rate}");

        //            if (detail.Qty <= 0)
        //            {
        //                ModelState.AddModelError("", "Quantity must be greater than 0.");
        //                PopulateDropdowns(model);
        //                return View(model);
        //            }

        //            // Validate if the SubHeadId and SizeId exists in the respective tables
        //            var subHeadName = await _context.SubHeads
        //                .Where(s => s.SubHeadId == detail.SubheadId)
        //                .Select(s => s.SubHeadName)
        //                .FirstOrDefaultAsync();

        //            var sizeName = await _context.Albums
        //                .Where(s => s.SizeId == detail.SizeId)
        //                .Select(s => s.Size)
        //                .FirstOrDefaultAsync();

        //            // Validate MainHeadId
        //            var mainHead = await _context.MainHeads
        //                .FirstOrDefaultAsync(m => m.MainHeadId == detail.MainHeadId);

        //            if (mainHead == null)
        //            {
        //                ModelState.AddModelError("", $"Invalid MainHeadId: {detail.MainHeadId}. It does not exist.");
        //                PopulateDropdowns(model);
        //                return View(model);
        //            }

        //            if (detail.Rate > 0.00) // Only add/update RateMaster if rate > 0
        //            {
        //                var existingRate = await _context.RateMasters
        //                    .FirstOrDefaultAsync(r => r.SubHeadId == detail.SubheadId && r.SizeId == detail.SizeId && r.Active == "Y");

        //                if (existingRate == null)
        //                {
        //                    existingRate = new RateMaster
        //                    {
        //                        SubHeadId = detail.SubheadId,
        //                        SizeId = detail.SizeId,
        //                        MainHeadId = detail.MainHeadId,
        //                        Rate = Math.Round((decimal)detail.Rate, 2),
        //                        Active = "Y",
        //                        Details = $"{subHeadName} - {sizeName}"
        //                    };

        //                    _context.RateMasters.Add(existingRate);
        //                    await _context.SaveChangesAsync();
        //                }
        //                else if (existingRate.Rate != (decimal)detail.Rate)
        //                {
        //                    existingRate.Rate = Math.Round((decimal)detail.Rate, 2);
        //                    existingRate.Details = $"{subHeadName} - {sizeName}";
        //                    _context.RateMasters.Update(existingRate);
        //                    await _context.SaveChangesAsync();
        //                }

        //                detail.Rate = (double)existingRate.Rate;
        //            }
        //            else
        //            {
        //                // Rate is 0 or not provided, just keep detail.Rate as is (0)
        //            }

        //            // Add WorkDetail in all cases, no matter rate is zero or not
        //            detail.WorkOrderId = model.WorkOrder.WorkOrderId;
        //            detail.GTotal = detail.Qty * detail.Rate;
        //            detail.Tax ??= 0;
        //            detail.Cess ??= 0;
        //            detail.Active = "Y";

        //            subTotal += detail.GTotal;

        //            _context.WorkDetails.Add(detail);
        //        }

        //        Console.WriteLine($"WorkOrderId in model: {model.WorkOrder.WorkOrderId}");

        //        model.WorkOrder.SubTotal = Math.Round(subTotal, 2);

        //            await _context.SaveChangesAsync();

        //            TempData["SuccessMessage"] = "Work Order created successfully.";
        //            return RedirectToAction("Create");
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error: {ex.Message}");
        //            ModelState.AddModelError("", "An error occurred while saving the work order.");
        //            PopulateDropdowns(model);
        //            return View(model);
        //        }
        //    }

        private void PopulateDropdowns(WorkOrderViewModel model)
        {
            model.Machines = _context.Machines.Where(s => s.Active == "Y").ToList();
            model.DeliveryMasters = _context.DeliveryMasters.Where(s => s.Active == "Y").ToList();
            model.DeliveryModes = _context.DeliveryModes.Where(s => s.Active == "Y").ToList();
            model.OrderVias = _context.OrderVias.Where(s => s.Active == "Y").ToList();
            model.WorkTypes = _context.WorkTypes.Where(s => s.Active == "Y").ToList();
            model.Albums = _context.Albums.Where(s => s.Active == "Y").ToList();
            model.Customers = _context.CustomerRegs.Where(s => s.Active == "Y").ToList();
            model.Branches = _context.Branches.Where(s => s.Active == "Y").ToList();
            model.StaffRegs = _context.StaffRegs.Where(s => s.Active == "Y").ToList();
            model.MainHeads = _context.MainHeads.Where(s => s.Active == "Y").ToList();
            model.SubHeads = _context.SubHeads.Where(s => s.Active == "Y").ToList();
            model.RateMasterList = _context.RateMasters.Where(e => e.Active == "Y").ToList();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubHeadRate(int subHeadId, int sizeId, double newRate)
        {
            var rateMaster = await _context.RateMasters
                .FirstOrDefaultAsync(r => r.SubHeadId == subHeadId && r.SizeId == sizeId);

            if (rateMaster == null)
            {
                return NotFound(new { success = false, message = "Rate not found for SubHead and Size!" });
            }

            rateMaster.Rate = (decimal)newRate;

            try
            {
                _context.RateMasters.Update(rateMaster);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Rate updated successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetSubHeads(int mainHeadId)
        {
            var subHeads = _context.SubHeads
                                   .Where(s => s.MainHeadId == mainHeadId)
                                   .Select(s => new
                                   {
                                       subHeadId = s.SubHeadId,
                                       subHeadName = s.SubHeadName,
                                   })
                                   .ToList();

            return Json(subHeads);
        }

        [HttpGet]
        public IActionResult GetChildSubHeads(int subHeadId, int sizeId)
        {
            Console.WriteLine($"sizeId before query: {sizeId}");

            // Fetch the rate once based on subHeadId and sizeId
            var rate = _context.RateMasters
                .Where(r => r.SubHeadId == subHeadId && r.SizeId == sizeId && r.Active == "Y")
                .Select(r => r.Rate)
                .FirstOrDefault();

            Console.WriteLine($"Fetched Rate: {rate}");

            // Fetch child subheads based on subHeadId
            var childSubHeads = _context.ChildSubHeads
                .Where(c => c.SubHeadId == subHeadId)
                .Select(c => new
                {
                    childSubHeadId = c.ChildSubHeadId,
                    childSubHeadName = c.ChildSubHeadName,
                    // Fetch the rate from RateMasters table based on SubHeadId and SizeId
                    rate = _context.RateMasters
                        .Where(r => r.SubHeadId == subHeadId && r.SizeId == sizeId && r.Active == "Y")
                        .Select(r => r.Rate)
                        .FirstOrDefault(), // Assuming FirstOrDefault is safe for your use case
                    size = _context.Albums
                        .Where(s => s.SizeId == sizeId)
                        .Select(s => s.Size)
                        .FirstOrDefault() // Get the size name for the given sizeId
                })
                .ToList();

            return Json(childSubHeads);
        }
    }
}
