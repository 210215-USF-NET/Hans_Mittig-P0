using System;
using System.Collections.Generic;
using StoreDL;
using Entity = StoreDL.Entities;
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

        public void AddToCart(Customer c, Location l, Product p, int q)
        {
            //return 
            _repo.AddToCart(c,l, p, q);
        }

        public void AddCart(Cart c)
        { _repo.AddCart(c);}

        public void AddToCartItems(Cart c, Product p, int q)
        {
            _repo.AddToCartItems(c, p, q);
        }

        public void AddCartItems(CartItems c)
        {
            _repo.AddCartItems(c);
        }
        public void AddOrder(decimal x, DateTime y, Customer c, Cart z)
        {
            _repo.AddOrder(x, y, c, z);
        }

        public void AddOrderToDatabase(Orders order)
        {
            _repo.AddOrderToDatabase(order);
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

        public Cart GetCart(int x)
        {
            return _repo.GetCart(x);
        }

        public CartItems GetCartItems(int x)
        {
            return _repo.GetCartItems(x);
        }

        public Product GetProduct(int x)
        {
            return _repo.GetProduct(x);
        }
    }
}
