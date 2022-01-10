using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Hosting;

using TableEmployee.Data;

namespace TableEmployee
{
  public partial class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    partial void OnConfigureServices(IServiceCollection services);

    partial void OnConfiguringServices(IServiceCollection services);

    public void ConfigureServices(IServiceCollection services)
    {
      OnConfiguringServices(services);

      services.AddOptions();
      services.AddLogging(logging =>
      {
          logging.AddConsole();
          logging.AddDebug();
      });

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
      services.AddMvc(options =>
      {
          options.EnableEndpointRouting = false;

          options.OutputFormatters.Add(new TableEmployee.Data.XlsDataContractSerializerOutputFormatter());
          options.FormatterMappings.SetMediaTypeMappingForFormat("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

          options.OutputFormatters.Add(new TableEmployee.Data.CsvDataContractSerializerOutputFormatter());
          options.FormatterMappings.SetMediaTypeMappingForFormat("csv", "text/csv");
      }).AddNewtonsoftJson();

      services.AddAuthorization();
      
              var oDataBuilder = new ODataConventionModelBuilder();

              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Bar>("Bars");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Branch>("Branches");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.DayBarBranch>("DayBarBranches");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.DayBranch>("DayBranches");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Employee>("Employees");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.ListEmployee>("ListEmployees");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Order>("Orders");

              var product = oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Product>("Products");
              product.EntityType.HasKey(entity => new {
                entity.id_product, entity.name
              });

              var productsInBar = oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.ProductsInBar>("ProductsInBars");
              productsInBar.EntityType.HasKey(entity => new {
                entity.id_product, entity.name
              });
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.ProductsInWarehouse>("ProductsInWarehouses");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.ProductsOrder>("ProductsOrders");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.ProductsToRestock>("ProductsToRestocks");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Schedule>("Schedules");
              oDataBuilder.EntitySet<TableEmployee.Models.SqlProjectFinal.Warehouse>("Warehouses");

          this.OnConfigureOData(oDataBuilder);


          var model = oDataBuilder.GetEdmModel();
          services.AddControllers().AddOData(opt => {
            opt.AddRouteComponents("odata/SqlProjectFinal", model).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
          });


      services.AddHttpContextAccessor();

      services.AddDbContext<TableEmployee.Data.SqlProjectFinalContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("SqlProjectFinalConnection"));
      });

      OnConfigureServices(services);
    }

    partial void OnConfigure(IApplicationBuilder app);


    partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);
    partial void OnConfigureOData(ODataConventionModelBuilder builder);

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      OnConfiguring(app, env);

      IServiceProvider provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();
      app.UseCors("AllowAny");
      app.Use(async (context, next) => {
          if (context.Request.Path.Value == "/__ssrsreport" || context.Request.Path.Value == "/ssrsproxy") {
            await next();
            return;
          }
          await next();
          if ((context.Response.StatusCode == 404 || context.Response.StatusCode == 401) && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.Contains("/odata")) {
              context.Request.Path = "/index.html";
              await next();
          }
      });

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseDeveloperExceptionPage();

      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

          endpoints.MapControllers();
          endpoints.MapFallbackToFile("index.html");
      });

      if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RADZEN")) && env.IsDevelopment())
      {
        app.UseSpa(spa =>
        {
          spa.Options.SourcePath = "../client";
          spa.UseAngularCliServer(npmScript: "start -- --port 8000 --open");
        });
      }

      OnConfigure(app);
      OnConfigure(app, env);
    }
  }
}
