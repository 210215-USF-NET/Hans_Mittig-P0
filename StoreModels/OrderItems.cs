using System;
namespace StoreModels
{
    public class OrderItems
    {
        public int id;
        public int? orderid;
        public int quantity;

        public int? productid;

        public int Id
        {
        get{return id;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            id = value;

        }
        }

        public int? Orderid
        {
        get{return orderid;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            orderid = value;

        }
        }

        public int Quantity
        {
        get{return quantity;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            quantity = value;

        }
        }

        public int? Productid
        {
        get{return productid;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            productid = value;

        }
        }
        public override string ToString() => $"Product: ${this.id} Quantity: {this.quantity}";
    }
}