using StoreModels;
using Model = StoreModels;
using System.Collections.Generic;
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

         Orders AddOrder(Orders order);

         List<Orders> AllOrders();

         public void AddToCart(Customer c, Location l, Product p, int q);

        public Model.Cart AddCart(Model.Cart c);
         public Manager ManagerSignInName(string name);
         public Manager ManagerSignInPassword(string password);

    }
}