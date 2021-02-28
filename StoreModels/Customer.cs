using System;

namespace StoreModels
{
    public class Customer
    {
        private String customerName;

        public String CustomerName
        {
        get{return customerName;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Customer name should not be null, try again.");
            } // TODO:
            customerName = value;

        }
    }

        public override string ToString() => $"{this.CustomerName.ToString()} was found in the system.";

    }
}
