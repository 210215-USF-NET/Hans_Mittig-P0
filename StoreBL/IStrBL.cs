using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IStrBL
    {
         List<Customer> GetCustomers();

         void AddCustomer(Customer newCustomer);

         Customer GetCustomerName(string name);

         Customer CustomerSignIn(string password);

         List<Location> ViewLoc();

         Location ChooseLoc(string location);

         Manager ManagerSignInName(string name);

         Manager ManagerSignInPassword(string password);

         void ViewInventory(string locvalue);

         Inventory InventorySelect(string inventory);

         void ViewProducts(string invvalue, string locvalue);

         Product SelectProduct(string product);

         void AddToCart(Customer customer, Location l, Product product, int q);

         void AddCart(Cart c);

         void AddOrder(Orders order);

         List<Orders> AllOrders();

    }
}