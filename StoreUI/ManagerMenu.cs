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
                ReplenishInventory();
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

        public void ReplenishInventory()
        { String inventoryname = "";
          String productname = "";
          //Inventory foundinv;
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
                Inventory foundinv = _strbl.InventorySelect(inventoryname);
                if(foundinv !=null)
                    {
                        Console.WriteLine($"You have selected {inventoryname}.");
                        Console.WriteLine("Please choose from the products available");
                        _strbl.ViewProducts(inventoryname, location);
                        productname = Console.ReadLine();
                        Product foundprod = _strbl.SelectProduct(productname);
                        if(foundprod != null)
                        {
                            Console.WriteLine($"{productname} selected. How many items are you adding?");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            if(quantity > 0)
                            {
                                Console.WriteLine($"{foundinv.id}\t{foundinv.InventoryName}\t{foundinv.productid}\t{foundinv.quantity}");
                               inventoryupdate((int)foundinv.locationid, (int)foundinv.productid, quantity);
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

        public void inventoryupdate(int l, int p, int q)
        {
            Inventory inv = new Inventory();
            inv.quantity = _strbl.GetInventoryById(p,l).quantity + q;
            _strbl.UpdateInventory(_strbl.GetInventoryById(p,l),inv);
            Console.WriteLine($"Your new stock quantity is {inv.quantity}.");
        }

       /* public Inventory GetInventoryDetails(Inventory i, int x)
        {
            Inventory ii = new Inventory();
            //i.id = 1;
            ii.id = i.id;
            ii.inventoryname = i.inventoryname;
            ii.quantity = i.quantity + x;
            ii.productid = i.productid;
            ii.locationid = i.locationid;
            return ii;
        }*/
    }
}