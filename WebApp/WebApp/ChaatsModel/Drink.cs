using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApp.ChaatsModel
{
    public partial class Drink
    {
        [Required]
        [Display(Name = "Id")]
        public int Did { get; set; }

        [Display(Name = "Drink")]
        public string Dname { get; set; }

        [Display(Name = "Rate")]
        public double? Dprice { get; set; }
        
    
        
    }
}
