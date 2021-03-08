using StoreBL;
using StoreModels;
using System.Collections.Generic;
using Serilog;
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
        {   Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("../logs.Json")
            .CreateLogger();
            Boolean stay = true;
            do{
                // Menu options
            Console.WriteLine("Welcome to my electronics store. What would you like to do?");
            Console.WriteLine("[0] Add customer");
            Console.WriteLine("[1] Search for Customer");
            Console.WriteLine("[2] Customer Login");
            //Console.WriteLine("[3] View order history");
            Console.WriteLine("[3] Manager Login");
            //Console.WriteLine("[5] Replenish inventory (Manager only)");
            Console.WriteLine("[4] Exit");

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
                    Log.Information("User has selected to search by location.");
                    SearchCustomer();
                    break;
                case "2":
                    Log.Information("User has selected to log in as customer.");
                    CustomerLogin();
                    break;
                case "3":
                    Log.Information("User has selected to log in as manager");
                    ManagerSignIn();
                    break;
                case "4":
                    Log.Information("User has exited the application.");
                    stay = false;
                    ExitRemarks();
                    break;
                default:
                    Log.Error("User has entered invalid input.");
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

        public void CustomerLogin()
        {   Console.WriteLine("Welcome to the Elecronics Store login system!");
            Console.WriteLine("Please enter the full name you registered with: ");
            string name = Console.ReadLine();
            Customer found = _strBL.GetCustomerName(name);
            if(found == null)
            {
                Console.WriteLine("Sorry, the specified name could not be found. Please try again.");
                //return null;
            }
            else
            {
                Console.WriteLine(found.ToString());
                Console.WriteLine("Please enter the associated password for your account: ");
                String password = Console.ReadLine();
                Customer foundpass = _strBL.CustomerSignIn(password);
                if(foundpass == null)
                {
                    Console.WriteLine("Sorry, the specified password does not match with this account.");
                    //return null;
                }
                else
                {
                    Console.WriteLine("Logging you in, please wait...");
                    CustomerMenu cmenu = new CustomerMenu(_strBL, found);
                    cmenu.Start();
                }
            }
        }

        public void ManagerSignIn()
        {
            Console.WriteLine("Please enter a manager's full name: ");
            Manager found = _strBL.ManagerSignInName(Console.ReadLine());
            if(found != null)
            {
                Console.WriteLine(found.ToString());
                Console.WriteLine("Please enter the manager's password: ");
                Manager found2 = _strBL.ManagerSignInPassword(Console.ReadLine());
                if(found2 != null)
                {
                    Console.WriteLine("Login successful, please wait a moment...");
                    ManagerMenu menu = new ManagerMenu(_strBL);
                    menu.Start();
                }
                else
                {
                Console.WriteLine("Sorry, the specified name and password do not match our records. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Sorry, the specified name could not be found. Please try again.");
            }
        }

        public void ViewLocationOrders()
        {
            ManagerSignIn();
            Console.WriteLine("Sorry, this feature is not fully implemented yet!");
        }

        public void ReplenishInventory()
        {
            ManagerSignIn();
            Console.WriteLine("Sorry, this feature is not fully implemented yet!");
        }
    }
}