using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using static WebApplication1.Models.ContactsModel;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static void InsertData()
        {
            using (var context = new ContactsContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Saves changes
                context.SaveChanges();
            }
        }
    }
}
