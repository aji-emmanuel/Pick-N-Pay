using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Database
{
    public class Seeder
    {
        private static IServiceProvider serviceProvider;

        /// <summary>
        /// Provides an instance of the DbContext class
        /// </summary>
        /// <param name="services"></param>
        public static void SeedDataBase(IServiceCollection services)
        {
            serviceProvider = services.BuildServiceProvider();
            AppDbContext context = serviceProvider.GetRequiredService<AppDbContext>();
            CategoryData(context).Wait();
            ProductData(context).Wait();
        }

        /// <summary>
        /// Saves a list of products to the database
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task ProductData(AppDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.Products.Any())
                {
                    var data = File.ReadAllText(@"JsonFile/Products.json");

                    var listOfProducts = JsonConvert.DeserializeObject<List<Product>>(data);
                    await context.Products.AddRangeAsync(listOfProducts);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves a list of categories to the database
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task CategoryData(AppDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.Categories.Any())
                {
                    var data = File.ReadAllText(@"JsonFile/Category.json");

                    var listOfCategories = JsonConvert.DeserializeObject<List<Category>>(data);
                    await context.Categories.AddRangeAsync(listOfCategories);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
