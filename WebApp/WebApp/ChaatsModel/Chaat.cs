using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApp.ChaatsModel
{
    public partial class Chaat
    {
        [Required]
        public int Cid { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="Please enter alphabets")]
        public string Cname { get; set; }
        public double? Cprice { get; set; }
    }
}
