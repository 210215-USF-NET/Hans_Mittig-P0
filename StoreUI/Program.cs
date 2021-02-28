using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using StoreBL;
using StoreDL;
using StoreModels;
using StoreDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace StoreUI
{
    class Program
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            //logger.Error("Item successfully purchased");  
            //Console.Read();
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseSqlServer(connectionString)
            .Options;
            
            using var context = new StoreDBContext(options);
            IMenu menu = new StoreMenu(new StrBL(new CustomerRepoDB(context, new StoreMapper())));
            menu.Start();
        }
    }
}
