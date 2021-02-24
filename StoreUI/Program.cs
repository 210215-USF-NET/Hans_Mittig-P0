using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using StoreBL;
using StoreDL;
using StoreModels;


namespace StoreUI
{
    class Program
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            //logger.Error("Item successfully purchased");  
            //Console.Read();
            IMenu menu = new StoreMenu(new StrBL(new CustomerRepoFile()));
            menu.Start();
        }
    }
}
