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
                customerid = customer.Id,
                CustomerName = customer.Name,
                CustomerPassword = customer.Password
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer
            {   
                //Id = customer.customerid,
                Name = customer.CustomerName,
                Password = customer.CustomerPassword
            };
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                Locationid = location.Id,
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
                inventoryname = inventory.NameOfInventory,
                quantity = inventory.Quantity,
                productid = inventory.Productid,
                locationid = inventory.Locationid
            };
        }

        public Entity.Inventory ParseInventory(Model.Inventory inventory)
        {
            return new Entity.Inventory
            {
                NameOfInventory = inventory.inventoryname,
                Quantity = inventory.quantity,
                Productid = inventory.productid,
                Locationid = inventory.locationid


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
                customerid = order.Customerid.Value,
                locationid = order.Locationid.Value
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

        public Model.Cart ParseCart(Entity.Cart cart)
        {
            return new Model.Cart{
                id = cart.Id,
                total = cart.Total,
                locationid = cart.Locationid,
                customerid = cart.Customterid
            };
        }

        public Entity.Cart ParseCart(Model.Cart cart)
        {
            return new Entity.Cart{
                Id = cart.id,
                Total = cart.total,
                Locationid = cart.locationid,
                Customterid = cart.customerid
            };
        }

        public Model.CartItems ParseCartItems(Entity.CartItem cartitems)
        {
            return new Model.CartItems{
                id = cartitems.Id,
                cartid = cartitems.Cartid,
                productid = cartitems.Productid,
                quantity = cartitems.Quantity
            };
        }

        public Entity.CartItem ParseCartItems(Model.CartItems cartitems)
        {
            return new Entity.CartItem{
                Id = cartitems.id,
                Cartid = cartitems.cartid,
                Productid = cartitems.productid,
                Quantity = cartitems.quantity
            };
        }

        public Model.OrderItems ParseOrderItems(Entity.OrderItem orderitems)
        {
            return new Model.OrderItems{
                id = orderitems.Id,
                orderid = orderitems.Orderid,
                quantity = orderitems.Quantity,
                productid = orderitems.Productid
            };
        }

        public Entity.OrderItem ParseOrderItems(Model.OrderItems orderitems)
        {
            return new Entity.OrderItem{
                Id = orderitems.id,
                Orderid = orderitems.orderid,
                Quantity = orderitems.quantity,
                Productid = orderitems.productid
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