﻿using System.ComponentModel.DataAnnotations;

namespace InternalProj.Models
{
    public class CustomerCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression("Y|N")]
        public string Active { get; set; }

        public ICollection<CustomerReg> Customers { get; set; }
    }

}
