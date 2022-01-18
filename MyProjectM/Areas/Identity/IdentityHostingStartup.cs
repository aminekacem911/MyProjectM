using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProjectM.Areas.Identity.Data;
using MyProjectM.Data;

[assembly: HostingStartup(typeof(MyProjectM.Areas.Identity.IdentityHostingStartup))]
namespace MyProjectM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<AuthContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("AuthContextConnection")));

                services.AddDefaultIdentity<MyProjectMUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<AuthContext>();
            });
        }
    }
}