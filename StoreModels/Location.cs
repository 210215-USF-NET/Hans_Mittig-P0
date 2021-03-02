using System;
namespace StoreModels
{
    public class Location
    {
        public int id;
        private string locationName;

        public String LocationName
        {
        get{return locationName;}
        set 
        {
            if(value == null || value.Equals("") ) 
            {throw new ArgumentNullException("Location should not be null, try again.");
            } // TODO:
            locationName = value;

        }
        }

        public int ID {
            get{
                return id;
            } 
            set {
                if(value.Equals(null))
                {
                    throw new ArgumentNullException("Error retrieving location id.");
                }
                id = value;
            }
        }
        public override string ToString() => $"{this.LocationName.ToString()}";
    }
}