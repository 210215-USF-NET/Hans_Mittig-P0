using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class CustomerRepoDB : IStoreRepository
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

        public Customer CustomerSignIn(string password)
        {
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerPassword == password);
        }

        public List<Location> ViewLoc()
        {
            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public Location ChooseLoc(string location)
        {
            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList().FirstOrDefault(x => x.LocationName == location);
        }

        public Manager ManagerSignInName(string name)
        {
            return _context.Managers.Select(x => _mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.ManagerName == name);
        }

        public Manager ManagerSignInPassword(string password)
        {
            return _context.Managers.Select(x => _mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.ManagerPassword == password);
        }
    }
}