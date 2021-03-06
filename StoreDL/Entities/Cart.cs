using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public decimal Total { get; set; }
        public int? Locationid { get; set; }
        public int? Customterid { get; set; }

        public virtual Customer Customter { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
