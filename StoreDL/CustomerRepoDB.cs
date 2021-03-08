using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
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

        public Model.Orders AddOrder(Model.Orders order)
        {     _context.Orders.Add(_mapper.ParseOrder(order));
              _context.SaveChanges();
              return order;
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

        public void ViewInventory(string locvalue)
        {   
            var queryInventory = (
            from inventory in _context.Inventories join loc in _context.Locations
            on inventory.Locationid equals loc.Id
            where loc.Address == locvalue
            select inventory
            );
        foreach (var item in queryInventory)
            {
                Console.WriteLine(String.Format(item.NameOfInventory));
            }
        }

        public Inventory SelectInventory(string inventory)
        {
            return _context.Inventories.Select(x => _mapper.ParseInventory(x)).ToList().FirstOrDefault(x => x.InventoryName == inventory);
        }

        public void ViewProducts(string invvalue, string locvalue)
        {   
            var queryProducts = (
            from inv in _context.Inventories join loc in _context.Locations
            on inv.Locationid equals loc.Id
            join prod in _context.Products
            on inv.Productid equals prod.Id
            where inv.NameOfInventory == invvalue
            select prod
            ).Distinct();
        foreach (var item in queryProducts)
            {
                Console.WriteLine($"Product: {item.Name} \tDecription: {item.Description} \tPrice: ${item.Price}");
            }
        }
        
        public Product SelectProduct(string product)
        {   return _context.Products.Select(x =>_mapper.ParseProducts(x)).ToList().Last(x => x.Name == product);
        }

        public void AddToCart(Customer c, Location l, Product p, int q)
        {
            Cart newcart = new Cart();
            newcart.CustomerID = c.customerid;
            newcart.LocationID = l.Locationid;
            newcart.Total +=  p.price * q;
            AddCart(newcart);
            //return newcart;
        }

        public void AddCart(Model.Cart c)
        {
            _context.Carts.Add(_mapper.ParseCart(c));
            _context.SaveChanges();
            
        }

        public Product GetProduct(int x)
        { return _mapper.ParseProducts(_context.Products.Where(y => y.Id == x).FirstOrDefault());}

        public void AddToCartItems(Cart c, Product p, int q)
        {
            CartItems citems = new CartItems();
            citems.cartid = c.id;
            citems.productid = p.id;
            citems.quantity = q;
            AddCartItems(citems);
            //return citems;
        }

        public void AddCartItems(CartItems c)
        {
             _context.CartItems.Add(_mapper.ParseCartItems(c));
            _context.SaveChanges();
        }
        public List<Orders> AllOrders()
        {
            return _context.Orders.AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
        }

        public List<OrderItems> AllOrderItems()
        {
            return _context.OrderItems.AsNoTracking().Select(x => _mapper.ParseOrderItems(x)).ToList();
        }

        public void AddOrder(decimal x, DateTime y, Customer c, Location l)
        {
            Orders order = new Orders();
            order.total = x;
            order.orderdate = y;
            order.customerid = c.customerid;
            order.locationid = l.locationID;
            AddOrderToDatabase(order);
        }
        public void AddOrderToDatabase(Orders order)
        {
            _context.Orders.Add(_mapper.ParseOrder(order));
            _context.SaveChanges();
        }

        public Manager ManagerSignInName(string name)
        {
            return _context.Managers.Select(x => _mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.ManagerName == name);
        }

        public Manager ManagerSignInPassword(string password)
        {
            return _context.Managers.Select(x => _mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.ManagerPassword == password);
        }

        public Cart GetCart(int x)
        {
            return _mapper.ParseCart(_context.Carts.Where(y => y.Id == x).FirstOrDefault());
        }

        public OrderItems GetOrderByOrderID(int x)
        {
            return _mapper.ParseOrderItems(_context.OrderItems.Where(y => y.Id == x).FirstOrDefault());
        }


        public CartItems GetCartItems(int x)
        {
            return _mapper.ParseCartItems(_context.CartItems.Where(y => y.Id == x).FirstOrDefault());
        }

        public Orders GetOrder(int x)
        {
            return _mapper.ParseOrder(_context.Orders.Where(y => y.Id == x).FirstOrDefault());
        }

        public void AddOrderItems(Orders x, int y, Product p)
        {
            OrderItems order = new OrderItems();
            order.orderid = x.id;
            order.quantity = y;
            order.productid = p.id;
            AddOrderItemsToDatabase(order);
        }

        public void AddOrderItemsToDatabase(OrderItems order)
        {
            _context.OrderItems.Add(_mapper.ParseOrderItems(order));
            _context.SaveChanges();
        }

        public CartItems DeleteCartItems(CartItems c)
        {   _context.ChangeTracker.Clear();
            _context.CartItems.RemoveRange(_mapper.ParseCartItems(c));
            _context.SaveChanges();
            return c;
        }

        public Cart DeleteCart(Cart c)
        {   _context.ChangeTracker.Clear();
            _context.Carts.Remove(_mapper.ParseCart(c));
            _context.SaveChanges();
            return c;
        }
    }
}