using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTesting
{
    public class CustomWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                

                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ShopDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<ShopDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });



            });


        }
    }
}
