using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int Cartid { get; set; }
        public int? Productid { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
