using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalProj.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression("Y|N")]
        public string Active { get; set; }

        public ICollection<CustomerReg> CustomerRegs { get; set; }

        public ICollection<StaffReg> StaffRegs { get; set; }

        public ICollection<WorkOrderMaster>WorkOrders { get; set; }

    }
}
