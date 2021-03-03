using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
namespace StoreDL
{
    public class CustomerRepoDB : IStoreRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public CustomerRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public Model.Orders AddOrder(Model.Orders order)
        {     _context.Orders.Add(_mapper.ParseOrder(order));
              _context.SaveChanges();
              return order;
        }     

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public Customer GetCustomerName(string name)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerName == name);
        }

        public Customer CustomerSignIn(string password)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerPassword == password);
        }

        public List<Location> ViewLoc()
        {
            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public Location ChooseLoc(string location)
        {
            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList().FirstOrDefault(x => x.LocationName == location);
        }

        public void ViewInventory(string locvalue)
        {   
            var queryInventory = (
            from inventory in _context.Inventories join loc in _context.Locations
            on inventory.Locationid equals loc.Id
            where loc.Address == locvalue
            select inventory
            );
        foreach (var item in queryInventory)
            {
                Console.WriteLine(String.Format(item.NameOfInventory));
            }
        }

        public Inventory SelectInventory(string inventory)
        {
            return _context.Inventories.Select(x => _mapper.ParseInventory(x)).ToList().FirstOrDefault(x => x.InventoryName == inventory);
        }

        public void ViewProducts(string invvalue, string locvalue)
        {   
            var queryProducts = (
            from inv in _context.Inventories join loc in _context.Locations
            on inv.Locationid equals loc.Id
            join prod in _context.Products
            on inv.Productid equals prod.Id
            where inv.NameOfInventory == invvalue
            select prod
            ).Distinct();
        foreach (var item in queryProducts)
            {
                Console.WriteLine($"Product: {item.Name} \tDecription: {item.Description} \tPrice: ${item.Price}");
            }
        }
        
        public Product SelectProduct(string product)
        {   return _context.Products.Select(x =>_mapper.ParseProducts(x)).ToList().Last(x => x.Name == product);
        }

        public Manager ManagerSignInName(string name)
        {
            return _context.Managers.Select(x => _mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.ManagerName == name);
        }

        public Manager ManagerSignInPassword(string password)
        {
            return _context.Managers.Select(x => _mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.ManagerPassword == password);
        }
    }
}