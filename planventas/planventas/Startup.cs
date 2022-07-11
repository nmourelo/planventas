using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using planventas.Data;
using planventas.Helpers;
using planventas.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<SeedDb>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<ICombosHelper, CombosHelper>();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
                 {
                     options.LoginPath = "/Account/NotAuthorized";
                     options.LogoutPath = "/home/Index";
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                     options.SlidingExpiration = true;
                     options.AccessDeniedPath = "/Account/NotAuthorized";
                 });
            //TODO More strongest Password on production
            services.AddIdentity<User, IdentityRole>(cfg =>
             {
                 cfg.User.RequireUniqueEmail = true;
                 cfg.Password.RequireDigit = false;
                 cfg.Password.RequiredUniqueChars = 0;
                 cfg.Password.RequireLowercase = false;
                 cfg.Password.RequireNonAlphanumeric = false;
                 cfg.Password.RequireUppercase = false;
                 cfg.Password.RequiredLength = 6;
             }).AddEntityFrameworkStores<Context>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");
        }
    }
}
