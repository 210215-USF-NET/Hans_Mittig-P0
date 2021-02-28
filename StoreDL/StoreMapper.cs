using Entity = StoreDL.Entities;
using Model = StoreModels;
using StoreModels;
using StoreDL.Entities;
using System.Collections.Generic;

namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                CustomerName = customer.Name,
                CustomerPassword = customer.Password
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer
            {
                Name = customer.CustomerName,
                Password = customer.CustomerPassword
            };
        }
    }
}