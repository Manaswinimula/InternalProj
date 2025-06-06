using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalProj.Models
{
    public class StaffReg
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [ForeignKey("DeptMaster")]
        public int DeptId { get; set; }
        public DeptMaster DeptMaster { get; set; }

        [ForeignKey("DesignationMaster")]
        public int DesignationId { get; set; }
        public DesignationMaster DesignationMaster { get; set; }

        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(1)]
        [RegularExpression("Y|N")]
        public string Active { get; set; }

        public ICollection<WorkOrderMaster> WorkOrders { get; set; } = new List<WorkOrderMaster>(); 

    }
}
