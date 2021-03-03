
using System;
namespace StoreModels
{
    public class Product
    {
        public int id;

        public string name;

        public string description;

        public decimal price;

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

        public string Name
        {
        get{return name;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. Product name cannot be null.");
            }
            name = value;

        }
        }

        public string Description
        {
        get{return description;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. Product description cannot be null.");
            }
            description = value;

        }
        }

        public decimal Price
        {
        get{return price;}
        set 
        {
            if(value == null ) 
            {throw new ArgumentNullException("Error. Product price cannot be null.");
            }
            price = value;

        }
        }
        
    }
}