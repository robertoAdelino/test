using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeroWaste.Data;

[assembly: HostingStartup(typeof(ZeroWaste.Areas.Identity.IdentityHostingStartup))]
namespace ZeroWaste.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ZeroWasteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ZeroWasteContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<ZeroWasteContext>();
            });
        }
    }
}