using System;
namespace StoreModels
{
    public class Location
    {
        private int locationID;
        private string locationName;

        public int Locationid
        {
            get{return locationID;}
            set{
                if(value == null)
                {
                    throw new ArgumentNullException("Location cannot be null.");
                }
                locationID = value;
            }
        }

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

        public override string ToString() => $"{this.LocationName.ToString()}";
    }
}