using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.ChaatsModel
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime? Toa { get; set; }
    }
}
