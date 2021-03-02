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

    }
}