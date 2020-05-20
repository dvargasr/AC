using System;
using Chinita.Data;
using Chinita.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Chinita.Areas.Identity.IdentityHostingStartup))]
namespace Chinita.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddIdentityCore<StoreUser>()
            //    .AddEntityFrameworkStores<CContext>();
            //});
        }
    }
}