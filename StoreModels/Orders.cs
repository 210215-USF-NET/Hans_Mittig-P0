using System;
namespace StoreModels
{
    public class Orders
    {
        public int id;

        public decimal total;

        public DateTime orderdate;

        public int? customerid;

        public int? locationid;

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

        public decimal Total
        {
        get{return total;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. total cannot be null.");
            }
            total = value;

        }
        }

        public DateTime Orderdate
        {
        get{return orderdate;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            orderdate = value;

        }
        }

        public int? Customerid
        {
        get{return customerid;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            customerid = value;

        }
        }

        public int? Locationid
        {
        get{return locationid;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            locationid = value;

        }
        }
        public override string ToString() => $"${this.total}\t{this.orderdate}";

    }
}