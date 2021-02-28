using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IStrBL
    {
         List<Customer> GetCustomers();

         void AddCustomer(Customer newCustomer);

         Customer GetCustomerName(string name);
    }
}