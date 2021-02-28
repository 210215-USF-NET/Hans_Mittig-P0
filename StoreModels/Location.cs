using System;
namespace StoreModels
{
    public class Location
    {
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
        public override string ToString() => $"{this.LocationName.ToString()} \n";
    }
}