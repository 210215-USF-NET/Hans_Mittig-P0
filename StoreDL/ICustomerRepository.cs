using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepository
    {
         List<Customer> GetCustomers();

         Customer AddCustomer(Customer newCustomer);
         Customer GetCustomerName(string name);

         Customer CustomerSignIn(string password);

         List<Location> ViewLoc();

         Location ChooseLoc(string location);
    }
}