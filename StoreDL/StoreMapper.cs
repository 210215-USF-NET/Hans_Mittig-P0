using Entity = StoreDL.Entities;
using Model = StoreModels;
using StoreModels;
using StoreDL.Entities;
using System.Collections.Generic;

namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                CustomerName = customer.Name,
                CustomerPassword = customer.Password
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer
            {
                Name = customer.CustomerName,
                Password = customer.CustomerPassword
            };
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                LocationName = location.Address
            };
        }

        public Entity.Location ParseLocation(Model.Location location)
        {
            return new Entity.Location
            {
                Address = location.LocationName
            };
        }

        public Model.Manager ParseManager(Entity.Manager manager)
        {
            return new Model.Manager
            {
                ManagerName = manager.Name,
                ManagerPassword = manager.Password
            };
        }

        public Entity.Manager ParseManager(Model.Manager manager)
        {
            return new Entity.Manager
            {
                Name = manager.ManagerName,
                Password = manager.ManagerPassword
            };
        }
    }
}