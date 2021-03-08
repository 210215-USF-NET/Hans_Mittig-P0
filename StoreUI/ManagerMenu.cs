using System;
using System.Collections.Generic;
using System.Text;
using StoreBL;
using StoreDL;
using StoreModels;
using System.Linq;
namespace StoreUI
{
    public class ManagerMenu :IMenu
    {
        private IStrBL _strbl;
        public List<Orders> LocOrders;

         public ManagerMenu(IStrBL _strBL)
        {
            _strbl = _strBL;
        }

        public void Start()
        {    Boolean stay = true;
            do{
            Console.WriteLine("Welcome to the Manager Menu!");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[0] View order history by location");
            Console.WriteLine("[1] Replenish inventory");
            Console.WriteLine("[2] Exit");

            Console.WriteLine("Enter a number: ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                ViewOrdersByLocation();
                    break;
                case "1":
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

        public void ViewOrdersByLocation()
        {
            Console.WriteLine("Please enter a location to select from: ");
            foreach (var item in _strbl.ViewLoc())
            {
                Console.WriteLine(item.ToString());
            }
            string location = "";
            location = Console.ReadLine();
            Location foundloc = _strbl.ChooseLoc(location);
            if(foundloc != null)
            {Console.WriteLine($"You have selected {foundloc.LocationName}.");
            Console.WriteLine($"Here are the orders for {foundloc.LocationName}:");
            LocOrders = GetOrdersByLocation(_strbl.AllOrders(),foundloc);
            OrderHistory(LocOrders);
            }
            else
            {
                Console.WriteLine("Sorry, the specified location does not match our records. Please try again.");
            }
        }

        public void OrderHistory(List<Orders> orders)
        {
                
            foreach (var order in orders)
                {
                    Console.WriteLine(order.ToString());
                    List<OrderItems> orderitems = _strbl.GetOrderByOrderID(order.id);
                    foreach(var orderi in orderitems)
                    {
                        Console.WriteLine(orderi.ToString());
                    }
                 }
        }
        public List<Orders> GetOrdersByLocation(List<Orders> orders, Location x)
        {
            List<Orders> customerorderlist = new List<Orders>();
            customerorderlist = orders.Select(O => O).Where(O => O.locationid == x.Locationid).ToList();
            return customerorderlist;
        }
    }
}