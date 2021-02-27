﻿using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? Orderid { get; set; }
        public int Quantity { get; set; }
        public int? Productid { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
