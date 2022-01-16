using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Caixa.Data;

using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

namespace Caixa
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        partial void OnConfigureServices(IServiceCollection services);

        partial void OnConfiguringServices(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            OnConfiguringServices(services);

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAny",
                    x =>
                    {
                        x.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(isOriginAllowed: _ => true)
                        .AllowCredentials();
                    });
            });
            var oDataBuilder = new ODataConventionModelBuilder();

            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Bar>("Bars");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Branch>("Branches");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.DayBarBranch>("DayBarBranches");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.DayBranch>("DayBranches");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.EmpWarehouse>("EmpWarehouses");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Employee>("Employees");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.ListEmployee>("ListEmployees");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Order>("Orders");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Product>("Products");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.ProductsInBar>("ProductsInBars");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>("ProductsInWarehouses");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.ProductsOrder>("ProductsOrders");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.RestockBar>("RestockBars");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.RestockWarehouse>("RestockWarehouses");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Schedule>("Schedules");
            oDataBuilder.EntitySet<Caixa.Models.SqlProjectFinal.Warehouse>("Warehouses");

            this.OnConfigureOData(oDataBuilder);


            var model = oDataBuilder.GetEdmModel();
            services.AddControllers().AddOData(opt => { 
              opt.AddRouteComponents("odata/SqlProjectFinal", model).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
            });

            

            services.AddDbContext<Caixa.Data.SqlProjectFinalContext>(options =>
            {
              options.UseSqlServer(Configuration.GetConnectionString("SqlProjectFinalConnection"));
            });

            services.AddRazorPages();

            OnConfigureServices(services);
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void OnConfigureOData(ODataConventionModelBuilder builder);
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            OnConfiguring(app, env);
            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    return next();
                });
            }
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            IServiceProvider provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();
            app.UseCors("AllowAny");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            OnConfigure(app, env);
        }
    }


}
