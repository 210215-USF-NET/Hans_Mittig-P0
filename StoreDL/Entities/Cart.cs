using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Cart
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public int? Productid { get; set; }
        public int? Locationid { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
