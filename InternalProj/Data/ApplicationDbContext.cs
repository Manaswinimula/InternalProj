using InternalProj.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalProj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<CustomerReg> CustomerRegs { get; set; }
        public DbSet<RegionMaster> RegionMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }

        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<RateTypeMaster> RateTypeMasters { get; set; }
        public DbSet<DeptMaster> DeptMasters { get; set; }
        public DbSet<DesignationMaster> DesignationMasters { get; set; }
        public DbSet<StaffReg> StaffRegs { get; set; }

        public DbSet<AlbumSizeDetails> Albums { get; set; }
        public DbSet<ChildSubHead> ChildSubHeads { get; set; }
        public DbSet<DeliveryMaster> DeliveryMasters { get; set; }
        public DbSet<DeliveryMode> DeliveryModes { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MainHeadReg> MainHeads { get; set; }
        public DbSet<OrderVia> OrderVias { get; set; }
        public DbSet<SubHeadDetails> SubHeads { get; set; }
        public DbSet<TaxMaster>TaxMasters { get; set; }
        public DbSet<WorkOrderMaster> WorkOrders { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorkDetails> WorkDetails { get; set; }

        public DbSet<RateMaster> RateMasters { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ModeOfPayment> ModeOfPayments { get; set; }
        public DbSet<OutstandingAmount> OutstandingAmounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegionMaster>()
                .HasOne(r => r.State)
                .WithMany(s => s.Regions)
                .HasForeignKey(r => r.StateId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<StateMaster>()
                .Property(s => s.Active)
                .HasDefaultValue("Y");
            
            modelBuilder.Entity<CustomerReg>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<CustomerAddress>(a => a.CustomerId);

            modelBuilder.Entity<CustomerReg>()
                .HasMany(c => c.Contacts)
                .WithOne(cc => cc.Customer)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<CustomerContact>()
                .HasOne(cc => cc.PhoneType)
                .WithMany()
                .HasForeignKey(cc => cc.PhoneTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerReg>()
                .HasOne(cc => cc.CustomerCategory)
                .WithMany()
                .HasForeignKey(cc => cc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerReg>()
                .HasOne(c => c.Branch)
                .WithMany(b => b.CustomerRegs)
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerReg>()
                .HasOne(c => c.RateTypeMaster)
                .WithMany(r => r.CustomerRegs)
                .HasForeignKey(c => c.RateTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // WorkOrderMaster Relationships
            modelBuilder.Entity<WorkOrderMaster>()
                .HasOne(w => w.Machine)
                .WithMany()
                .HasForeignKey(w => w.MachineId)
                .OnDelete(DeleteBehavior.SetNull);
                      
            modelBuilder.Entity<WorkOrderMaster>()
                .HasOne(w => w.AlbumSize)
                .WithMany()
                .HasForeignKey(w => w.AlbumSizeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrderMaster>()
                .HasOne(w => w.Customer)
                .WithMany()
                .HasForeignKey(w => w.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrderMaster>()
                .HasOne(w => w.WorkType)
                .WithMany()
                .HasForeignKey(w => w.WorkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrderMaster>()
                .HasOne(w => w.Staff)
                .WithMany()
                .HasForeignKey(w => w.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            

            // SubHeadDetails to MainHead and Machine
            modelBuilder.Entity<SubHeadDetails>()
                .HasOne(s => s.MainHead)
                .WithMany()
                .HasForeignKey(s => s.MainHeadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubHeadDetails>()
                .HasOne(s => s.Machine)
                .WithMany()
                .HasForeignKey(s => s.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            // ChildSubHead to SubHeadDetails
            modelBuilder.Entity<ChildSubHead>()
                .HasOne(c => c.SubHead)
                .WithMany(s => s.ChildSubHeads)
                .HasForeignKey(c => c.SubHeadId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkOrderMaster>()
               .HasOne(w => w.Staff)
               .WithMany() 
               .HasForeignKey(w => w.StaffId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffReg>()
                .HasMany(s => s.WorkOrders)
                .WithOne(w => w.Staff)
                .HasForeignKey(w => w.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrderMaster>()
                .Property(w => w.Active)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength()
                .HasDefaultValue("Y")
                .HasAnnotation("RegularExpression", "Y|N");
        }
    }
}
