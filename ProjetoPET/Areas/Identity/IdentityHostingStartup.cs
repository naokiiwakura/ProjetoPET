using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoPET.Areas.Identity.Data;
using ProjetoPET.Models;

[assembly: HostingStartup(typeof(ProjetoPET.Areas.Identity.IdentityHostingStartup))]
namespace ProjetoPET.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BancoContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BancoContext")));

                services.AddDefaultIdentity<Usuario>()
                    .AddEntityFrameworkStores<BancoContext>();
            });
        }
    }
}