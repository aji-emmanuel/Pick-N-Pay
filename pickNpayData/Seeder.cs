using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Database
{
    public class Seeder
    {
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
