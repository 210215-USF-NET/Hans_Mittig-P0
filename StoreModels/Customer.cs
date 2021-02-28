using System;

namespace StoreModels
{
    public class Customer
    {
        private String customerName;
        private String customerPassword;
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

    public String CustomerPassword
        {
        get{return customerPassword;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Customer password should not be null, try again.");
            } // TODO:
            customerPassword = value;

        }
    }

        public override string ToString() => $"The customer {this.CustomerName.ToString()} was found in the system.";

    }
}
