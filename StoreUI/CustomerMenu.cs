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
        { 
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
                //foundinv = _strbl.InventorySelect(inventoryname);
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

        public List<Orders> GetOrders(List<Orders> orders)
        {
            List<Orders> customerorderlist = new List<Orders>();
            customerorderlist = orders.Select(O => O).Where(O => O.customerid == _customer.customerid).ToList();
            return customerorderlist;
            /*foreach(Orders x in orders)
            {
                if (x.customerid == _customer.customerid)
                {
                    customerorderlist.Add(x);
                }
            } return customerorderlist; */
        }

    }
}