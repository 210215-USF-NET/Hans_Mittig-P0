using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class StrBL : IStrBL
    {
        private IStoreRepository _repo;
        public StrBL(IStoreRepository repo)
        {
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public Customer GetCustomerName(string name)
        {
            return _repo.GetCustomerName(name);
        }

        public Customer CustomerSignIn(string password)
        {
            return _repo.CustomerSignIn(password);
        }

        public List<Location> ViewLoc()
        {
            return _repo.ViewLoc();
        }

        public Location ChooseLoc(string location)
        {
            return _repo.ChooseLoc(location);
        }


        public void ViewInventory(string locvalue)
        {
            _repo.ViewInventory(locvalue);
        }

        public Inventory InventorySelect(string inventory)
        {
            return _repo.SelectInventory(inventory);
        }

        public void ViewProducts(string invvalue, string locvalue)
        {
            _repo.ViewProducts(invvalue, locvalue);
        }

        public Product SelectProduct(string product)
        {
            return _repo.SelectProduct(product);
        }

        public void AddOrder(Orders order)
        {
            _repo.AddOrder(order);
        }
        public Manager ManagerSignInName(string name)
        {
            return _repo.ManagerSignInName(name);
        }

        public Manager ManagerSignInPassword(string password)
        {
            return _repo.ManagerSignInPassword(password);
        }

        public List<Orders> AllOrders()
        {
            return _repo.AllOrders();
        }
    }
}
