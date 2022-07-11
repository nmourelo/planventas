using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using planventas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            RunSeeding(host);
            //CreateHostBuilder(args).Build().Run();
            host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            IServiceScopeFactory scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                SeedDb seeder = scope.ServiceProvider.GetService<SeedDb>();
                seeder.SeedAsync().Wait();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) //=>
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            //Host.CreateDefaultBuilder(args)
            //      .ConfigureWebHostDefaults(webBuilder =>
            //      {
            //          webBuilder.UseStartup<Startup>();
            //      });
        }
    }
}
