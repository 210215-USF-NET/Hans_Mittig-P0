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
                    ViewLocationOrders();
                    break;
                case "5":
                    ReplenishInventory();
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

         public string PickLocation()
        {
            Console.WriteLine("Please select a location from the available options: ");
            foreach (var item in _strBL.ViewLoc())
            {
                Console.WriteLine(item.ToString());
            }
            string location = Console.ReadLine();
            Location found = _strBL.ChooseLoc(location);
            if(found != null)
            {
                Console.WriteLine($"You have selected {found.ToString()} as your location.");
                return location;
            }
            else
            {
                Console.WriteLine("Sorry, the specified location does not match our records. Please try again.");
                return null;
            }

        } 

        public void PlaceOrder()
        {   /* String name = CustomerLogin();
            if(CustomerLogin() != null)
            {String location = PickLocation();
              if(PickLocation() != null)
              {
                  //PickInventory();
              }
            } */
            string name = "";
            string location = "";
            string inventoryname = "";
            string productname ="";
            int quantity = 0;
            Console.WriteLine("Welcome to the Elecronics Store login system!");
            Console.WriteLine("Please enter the full name you registered with: ");
            name = Console.ReadLine();
            Customer found = _strBL.GetCustomerName(name);
            if(found != null)
            {
                Console.WriteLine(found.ToString());
                Console.WriteLine("Please enter the associated password for your account: ");
                Customer foundpass = _strBL.CustomerSignIn(Console.ReadLine());
                if(foundpass != null)
                {
                    Console.WriteLine("Login successful, please wait a moment...");
                    Console.WriteLine("Please select a location from the available options: ");
            foreach (var item in _strBL.ViewLoc())
            {
                Console.WriteLine(item.ToString());
            }
            location = Console.ReadLine();
            Location foundloc = _strBL.ChooseLoc(location);
            if(found != null)
            {
                Console.WriteLine($"You have selected {foundloc.ToString()} as your location.");
                Console.WriteLine("Please choose from the available types of products: ");
                _strBL.ViewInventory(location);
                inventoryname = Console.ReadLine();
                Inventory foundinv = _strBL.InventorySelect(inventoryname);
                if(foundinv !=null)
                    {
                        Console.WriteLine($"You have selected {inventoryname}.");
                        Console.WriteLine("Please choose from the products available");
                        _strBL.ViewProducts(inventoryname, location);
                        productname = Console.ReadLine();
                        Product foundprod = _strBL.SelectProduct(productname);
                        if(foundprod != null)
                        {
                            Console.WriteLine($"{productname} selected. How many would you like to buy?");
                            quantity = Convert.ToInt32(Console.ReadLine());
                            if(quantity > 0)
                            {
                                Console.WriteLine($"Checkout for {name}");
                                
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid product entered. Please input a valid product from the list.");
                            quantity = 0;
        
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, the specified product does not exist.");
                        inventoryname = null;
                    }
            }
            else
            {
                Console.WriteLine("Sorry, the specified location does not match our records. Please try again.");
                location = null;
            }
                }
                else
                {
                    Console.WriteLine("Sorry, the specified name and password do not match our records. Please try again.");
	            name = null;
                }
            }
            else
            {
                Console.WriteLine("Sorry, the specified name could not be found. Please try again.");
                name = null;
            }
        }

        public string CustomerLogin()
        {   Console.WriteLine("Welcome to the Elecronics Store login system!");
            Console.WriteLine("Please enter the full name you registered with: ");
            string name = Console.ReadLine();
            Customer found = _strBL.GetCustomerName(name);
            if(found != null)
            {
                Console.WriteLine(found.ToString());
                Console.WriteLine("Please enter the associated password for your account: ");
                Customer foundpass = _strBL.CustomerSignIn(Console.ReadLine());
                if(foundpass != null)
                {
                    Console.WriteLine("Login successful, please wait a moment...");
                    return name;
		    
                }
                else
                {
                    Console.WriteLine("Sorry, the specified name and password do not match our records. Please try again.");
	            return null;
                }
            }
            else
            {
                Console.WriteLine("Sorry, the specified name could not be found. Please try again.");
                return null;
            }
        }

        public Boolean ManagerSignIn()
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
                    return true;
                }
                else
                {
                Console.WriteLine("Sorry, the specified name and password do not match our records. Please try again.");
                return false;
                }
            }
            else
            {
                Console.WriteLine("Sorry, the specified name could not be found. Please try again.");
                return false;
            }
        }

        public void ViewLocationOrders()
        {
            ManagerSignIn();
        }

        public void ReplenishInventory()
        {
            ManagerSignIn();
        }
    }
}