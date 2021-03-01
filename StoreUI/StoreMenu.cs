using StoreBL;
using StoreModels;
using System;

namespace StoreUI
{
    public class StoreMenu : IMenu
    {
        private IStrBL _strBL;

        public StoreMenu(IStrBL strBL)
        {
            _strBL = strBL;
        }

        public void Start()
        {   Boolean stay = true;
            do{
                // Menu options
            Console.WriteLine("Welcome to my electronics store. What would you like to do?");
            Console.WriteLine("[0] Add customer");
            Console.WriteLine("[1] Search for Customer");
            Console.WriteLine("[2] Place order");
            Console.WriteLine("[3] View order history");
            Console.WriteLine("[4] View location order history (Manager only)");
            Console.WriteLine("[5] Replenish inventory (Manager only)");
            Console.WriteLine("[6] Exit");

            // get user input
            Console.WriteLine("Enter a number: ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    try
                    {CreateCustomer();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Invalid input" + e.Message);
                        continue;
                    }
                    break;
                case "1":
                    SearchCustomer();
                    break;
                case "2":
                    PlaceOrder();
                    break;
                case "3":
                    //ViewOrders();
                    break;
                case "4":
                    //ViewLocationOrders
                    break;
                case "5":
                    //ReplenishInventory
                    break;
                case "6":
                    stay = false;
                    ExitRemarks();
                    break;
                default:
                    Console.WriteLine("Invalid input, please enter a proper value.");
                    break;
            }
            
              }while (stay);

        }

        public void CreateCustomer()
        {
             // Create hero method/logic
            Customer newCustomer = new Customer();
            Console.WriteLine("Enter Customer's full name: ");
            newCustomer.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter a password for the new customer: ");
            newCustomer.CustomerPassword = Console.ReadLine();

            _strBL.AddCustomer(newCustomer);
            Console.WriteLine("Customer registered successfully.");
        }

        public void ExitRemarks()
        {Console.WriteLine("Thank you for coming, see you again soon!");}

        public Boolean SearchCustomer()
        {
            Console.WriteLine("Please enter a full name to search by: ");
            Customer found = _strBL.GetCustomerName(Console.ReadLine());
            if(found != null)
            {
                Console.WriteLine(found.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Sorry, the specified name could not be found. Please try again.");
                return false;
            }
        }

         public void PickLocation()
        {
            Console.WriteLine("Please select a location from the available options: ");
            foreach (var item in _strBL.ViewLoc())
            {
                Console.WriteLine(item.ToString());
            }
            Location found = _strBL.ChooseLoc(Console.ReadLine());
            if(found != null)
            {
                Console.WriteLine($"You have selected {found.ToString()} as your location.");
            }
            else
            {
                Console.WriteLine("Sorry, the specified location does not match our records. Please try again.");
            }

        } 

        public void PlaceOrder()
        {
            CustomerLogin();
        }

        public void CustomerLogin()
        {   Console.WriteLine("Welcome to the the Electronics Store login system!");
            if(SearchCustomer()) 
            {
                Console.WriteLine("Please enter a password for the specified user: ");
                Customer foundpass = _strBL.CustomerSignIn(Console.ReadLine());
                if(foundpass != null)
                {
                    Console.WriteLine("Login successful, please wait a moment...");
                    PickLocation();
                }
                else
                {
                    Console.WriteLine("Sorry, the specified name and password do not match our records. Please try again.");
                }
            }
        }
    }
}