using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class CustomerRepoDB : ICustomerRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public CustomerRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public Customer GetCustomerName(string name)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerName == name);
        }
    }
}