using StoreModels;
using Model = StoreModels;
using System.Collections.Generic;
using System;
namespace StoreDL
{
    public interface IStoreRepository
    {
         List<Customer> GetCustomers();

         Customer AddCustomer(Customer newCustomer);

         Customer GetCustomerName(string name);

         Customer CustomerSignIn(string password);

         List<Location> ViewLoc();

         Location ChooseLoc(string location);

         void ViewInventory(string locvalue);

         Inventory SelectInventory(string inventory);

         void ViewProducts(string invvalue, string locvalue);

         Product SelectProduct(string product);

         void AddOrder(decimal x, DateTime y, Customer c, Cart z);

         public void AddOrderToDatabase(Orders order);

         List<Orders> AllOrders();

         public void AddToCart(Customer c, Location l, Product p, int q);

        public void AddCart(Model.Cart c);

        public void AddToCartItems(Cart c, Product p, int q);

        public void AddCartItems(CartItems c);
         public Manager ManagerSignInName(string name);
         public Manager ManagerSignInPassword(string password);
         public Cart GetCart(int x);
         public CartItems GetCartItems(int x);
         public Product GetProduct(int x);

    }
}