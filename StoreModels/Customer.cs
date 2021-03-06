using System;
using System.Collections.Generic;
using System.Text;

namespace StoreModels
{
    public class Customer
    {
        public int customerid;
        private String customerName;
        private String customerPassword;

        public int CustomerID
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
