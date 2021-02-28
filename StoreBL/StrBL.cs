using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class StrBL : IStrBL
    {
        private ICustomerRepository _repo;

        public StrBL(ICustomerRepository repo)
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
    }
}
