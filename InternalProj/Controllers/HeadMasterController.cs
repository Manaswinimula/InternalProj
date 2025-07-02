using InternalProj.Data;
using InternalProj.Models;
using InternalProj.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace InternalProj.Controllers
{
    public class HeadMasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HeadMasterViewModel
            {
                MainHeads = _context.MainHeads
                    .Include(m => m.SubHeads)
                        .ThenInclude(s => s.ChildSubHeads)
                    .Where(m => m.Active == "Y")
                    .ToList(),

                SubHeads = _context.SubHeads.Where(s => s.Active == "Y").ToList(),
                ChildSubHeads = _context.ChildSubHeads.Where(c => c.Active == "Y").ToList()
            };

            return View(viewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> AddSubHead([FromForm] int mainHeadId, [FromForm] string subHeadName)
        {
            if (string.IsNullOrWhiteSpace(subHeadName))
                return BadRequest("SubHead name is required.");

            try
            {
                var subHead = new SubHeadDetails
                {
                    MainHeadId = mainHeadId,
                    SubHeadName = subHeadName,
                    Active = "Y",
                    Status = true,
                    MachineId = 1
                };

                _context.SubHeads.Add(subHead);
                await _context.SaveChangesAsync();

                return Json(new { success = true, subHead });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddChildSubHead(int subHeadId, string childSubHeadName)
        {
            var newChild = new ChildSubHead
            {
                SubHeadId = subHeadId,
                ChildSubHeadName = childSubHeadName,
                Active = "Y"
            };

            _context.ChildSubHeads.Add(newChild);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }


}
