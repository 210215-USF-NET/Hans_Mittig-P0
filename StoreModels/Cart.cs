using System;
namespace StoreModels
{
    public class Cart
    {
        public int id;
        public decimal total;
        public int? locationid;
        public int? customerid;

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

        public decimal Total
        {
            get { return total; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                total = value; 
            }
        }

        public int? LocationID
        {
            get { return locationid; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                locationid = value; 
            }
        }

        public int? CustomerID
        {
            get { return customerid; }
            set 
            { 
                if (value.Equals(null)) 
                {
                   throw new ArgumentNullException("ID cannot be null.");
                }
                customerid = value; 
            }
        }

        public override string ToString() => $"Customer's cart: ";
    }
}