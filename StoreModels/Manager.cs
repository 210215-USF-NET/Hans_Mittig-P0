using System;
namespace StoreModels
{
    public class Manager
    {
        private String managerName;
        private String managerPassword;
        public String ManagerName
        {
        get{return managerName;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Manager name should not be null, try again.");
            } // TODO:
            managerName = value;

        }
    }

    public String ManagerPassword
        {
        get{return managerPassword;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Manager password should not be null, try again.");
            } // TODO:
            managerPassword = value;

        }
    }

        public override string ToString() => $"The manager {this.ManagerName.ToString()} was found in the system.";
    }
}