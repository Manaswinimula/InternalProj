using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalProj.Models
{
    public class DeptMaster
    {
        [Key]
        public int DeptId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression("Y|N")]
        public string Active { get; set; }

        public ICollection<StaffReg> StaffRegs { get; set; }

    }
}
