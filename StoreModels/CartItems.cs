using System;
namespace StoreModels
{
    public class CartItems
    {
        public int id;
        public int? cartid;
        public int? productid;
        public int quantity;

        public int ID
        {
            get { return id; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                id = value; 
            }
        }

        public int? CartID
        {
            get { return cartid; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                cartid = value; 
            }
        }

        public int? ProductID
        {
            get { return productid; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                productid = value; 
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                quantity = value; 
            }
        }
    }
}