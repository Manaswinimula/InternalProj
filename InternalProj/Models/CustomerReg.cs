using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalProj.Models
{
    public class CustomerReg
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public string StudioName { get; set; }

        public decimal Discount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(1)]
        [RegularExpression("Y|N")]
        public string Active { get; set; }

        // This is your only FK to CustomerCategory
        public int CategoryId { get; set; }

        // This tells EF Core CategoryId is the FK
        [ForeignKey(nameof(CategoryId))]
        public CustomerCategory CustomerCategory { get; set; }


        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey("RateTypeMaster")]
        public int RateTypeId { get; set; }
        public RateTypeMaster RateTypeMaster { get; set; }

        [ForeignKey("StaffReg")]
        public int StaffId { get; set; }
        public StaffReg StaffReg { get; set; }
        public CustomerAddress? Address { get; set; }

        public ICollection<CustomerContact> Contacts { get; set; } = new List<CustomerContact>();
    }
}
