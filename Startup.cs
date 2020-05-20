using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Chinita.Data;
using Chinita.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Chinita.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace Chinita
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration config)
        {
            _configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
                {
                    cfg.User.RequireUniqueEmail = true;
                    cfg.Password.RequireDigit = true;
                })
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CContext>();

            services.AddDbContext<CContext>(cfg => cfg.UseSqlServer(_configuration.GetConnectionString("CConnectionString")));
            services.AddTransient<CSeeder>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICRepository, CRepository>();

            services.Configure<RequestLocalizationOptions>(
                options => {
                    var supportedCultures = new List<CultureInfo> {
                        new CultureInfo("en"),
                        new CultureInfo("es")
                };

                    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                });
            services.AddMemoryCache();

            services.AddLocalization(opts => opts.ResourcesPath = "Resources");

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix, opts => opts.ResourcesPath = "Resources")
                .AddDataAnnotationsLocalization();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
                cfg.MapRazorPages();
            });

            
        }
    }
}
