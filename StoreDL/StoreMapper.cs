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

        public Model.Inventory ParseInventory(Entity.Inventory inventory)
        {
            return new Model.Inventory
            {
                inventoryname = inventory.NameOfInventory
            };
        }

        public Entity.Inventory ParseInventory(Model.Inventory inventory)
        {
            return new Entity.Inventory
            {
                NameOfInventory = inventory.inventoryname
            };
        }

        public Model.Product ParseProducts(Entity.Product products)
        {
            return new Model.Product
            {
                id = products.Id,
                Name = products.Name,
                description = products.Description,
                price = products.Price
            };
        }

        public Entity.Product ParseProducts(Model.Product products)
        {
            return new Entity.Product
            {
                Id = products.id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price
            };
        }

        public Model.Orders ParseOrder(Entity.Order order)
        {
            return new Model.Orders{
                Total = order.Total,
                Orderdate = order.Orderdate,
                customerid = (int)order.Customerid,
                locationid = (int)order.Locationid
            };
        }

        public Entity.Order ParseOrder(Model.Orders order)
        {
            return new Entity.Order{
                Total = order.Total,
                Orderdate = order.Orderdate,
                Customerid = order.customerid,
                Locationid = order.locationid
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