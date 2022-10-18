using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assign.Models
{
    public class Chaat
    {
        [Required]
        [Display(Name = "Id")]
        public int Cid { get; set; }
        [Display(Name = " ")]
        public string Cname { get; set; }
        [Display(Name = "Chaat")]
        public string Cimage { get; set; }
        [Display(Name = "Price")]
        public double? Cprice { get; set; }
    }
}
