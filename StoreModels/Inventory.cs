using System;
namespace StoreModels
{
    public class Inventory
    {
        public int id;
        public string inventoryname;

        private string description;

        public int productid;
        public int locationid;

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

        public String InventoryName
        {
        get{return inventoryname;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Location should not be null, try again.");
            } // TODO:
            inventoryname = value;

        }
        }

        public String Description
        {
        get{return description;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Location should not be null, try again.");
            } // TODO:
            description = value;

        }
        }

        public int Productid
        {
        get{return id;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. ID cannot be null.");
            }
            productid = value;

        }
        }

        public int Locationid
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

    }
}