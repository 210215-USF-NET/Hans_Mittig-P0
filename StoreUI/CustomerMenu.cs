using System;
using System.Collections.Generic;
using System.Text;
using StoreBL;
using StoreDL;
using StoreModels;
using System.Linq;

namespace StoreUI
{
    public class CustomerMenu : IMenu
    {

        private Location location;
        private IStrBL _strbl;
        private Customer _customer;
        public List<Orders> customerOrders;

        public Cart findcart;

        public CustomerMenu(IStrBL _strBL, Customer customer)
        {
            _strbl = _strBL;
            _customer = customer;
            customerOrders = GetOrders(_strBL.AllOrders());

        }
         public void Start()
        {    Boolean stay = true;
            do{
            Console.WriteLine("Welcome to the Customer Menu!");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[0] Place order");
            Console.WriteLine("[1] View order history");
            Console.WriteLine("[2] Exit");

            Console.WriteLine("Enter a number: ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    PlaceOrder();
                    break;
                case "1":
                    OrderHistory(customerOrders);
                    break;
                case "2":
                    stay = false;
                    //ExitRemarks();
                    break;
                default:
                    Console.WriteLine("Invalid input, please enter a proper value.");
                    break;
            }
            }while(stay);

        }

        public void PlaceOrder()
        { String inventoryname = "";
          String productname = "";
          Inventory foundinv;
        Console.WriteLine("Please choose from the locations listed below:");
        foreach (var item in _strbl.ViewLoc())
            {
                Console.WriteLine(item.ToString());
            }
            string location = "";
            location = Console.ReadLine();
            Location foundloc = _strbl.ChooseLoc(location);
            if(foundloc != null)
            {
                Console.WriteLine($"You have selected {foundloc.ToString()} as your location.");
                Console.WriteLine("Please choose from the available types of products: ");
                _strbl.ViewInventory(location);
                inventoryname = Console.ReadLine();
                foundinv = _strbl.InventorySelect(inventoryname);
                if(foundinv !=null)
                    {
                        Console.WriteLine($"You have selected {inventoryname}.");
                        Console.WriteLine("Please choose from the products available");
                        _strbl.ViewProducts(inventoryname, location);
                        productname = Console.ReadLine();
                        Product foundprod = _strbl.SelectProduct(productname);
                        if(foundprod != null)
                        {
                            Console.WriteLine($"{productname} selected. How many would you like to buy?");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            if(quantity > 0)
                            {
                                Console.WriteLine($"You have selected {quantity} {foundprod.Name}(s). Would you like to add to your cart?");
                                Boolean select = true;
                                do{
                                    string userInput = Console.ReadLine();
                                    switch(userInput.ToUpper())
                                    {
                                    case "YES":
                                    _strbl.AddToCart(_customer, foundloc, foundprod, quantity);
                                    Cart newcart =GetCart(_customer.CustomerID);
                                    _strbl.AddToCartItems(newcart, foundprod, quantity);
                                    CartItems newcartitems = GetCartItems(newcart.id);
                                    purchase(_customer, newcart, newcartitems);
                                    select = false;
                                    break;
                                    case "NO":
                                    select = false;
                                    break;
                                    default:
                                    Console.WriteLine("Invalid input, please enter a proper value.");
                                    break;
                                    }
                                }while(select);
                                Console.WriteLine("Thank you for your purchase!");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid product entered. Please input a valid product from the list.");
                        }
                    }
                else
                    {
                        Console.WriteLine("Invalid product type.");
                    }
            }
            else
            {
                Console.WriteLine("Sorry, the specified location does not match our records. Please try again.");
                location = null;
            }
        }

        public void OrderHistory(List<Orders> orders)
        {
            foreach (Orders order in orders)
                {
                    Console.WriteLine(order.ToString());
                 }
        }

        public Cart GetCart(int x)
        {
            return _strbl.GetCart(x);
        }

        public CartItems GetCartItems(int x)
        {
            return _strbl.GetCartItems(x);
        }

        public void purchase(Customer w, Cart x, CartItems y)
        {   Product p = GetProduct(w.customerid);
            Console.WriteLine($"Checkout for {w.CustomerName}");
            Console.WriteLine($"{y.quantity} {p.Name}(s)\t${x.total}");
            decimal ttl = x.total;
            DateTime now = DateTime.Now;
            Console.WriteLine($"Purchase made on {now}.");
            _strbl.AddOrder(ttl, now, w, x);
            //OrderItems neworderitems = _strbl.AddOrderItems(neworder, y, p);
        }

        public List<Orders> GetOrders(List<Orders> orders)
        {
            List<Orders> customerorderlist = new List<Orders>();
            customerorderlist = orders.Select(O => O).Where(O => O.customerid == _customer.customerid).ToList();
            return customerorderlist;
        }

        public Product GetProduct(int x)
        {
            return _strbl.GetProduct(x);
        }
        /* public void AddCart(Customer x, Location y, Product product, int q)
        {
            Cart newcart = _strbl.AddToCart(x, y,  product, q);

        } */

    }
}