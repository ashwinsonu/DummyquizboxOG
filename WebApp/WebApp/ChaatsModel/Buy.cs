using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.ChaatsModel
{
    public partial class Buy
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Addr { get; set; }
        public string CardNo { get; set; }
        public int? Cvv { get; set; }
        public DateTime? Doe { get; set; }
    }
}
