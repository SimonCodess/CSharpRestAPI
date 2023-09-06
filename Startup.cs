using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestAPI_Work.Data;
using RestAPI_Work.Models.DBModels;
using RestAPI_Work.Repositories;
using RestAPI_Work.Services;
using System.Linq;
using System.Text.Json.Serialization;

namespace RestAPI_Work
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGarageService, GarageService>();
            services.AddScoped<IGarageRepository, GarageRepository>();
            services.AddScoped<IMachineService, MachineService>();
            services.AddScoped<IMachineRepository, MachineRepository>();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestAPI_Work", Version = "v1.1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestAPI_Work v1"));

            SeedData(context);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Garages.Any())
            {
                context.Garages.Add(new Garage { Name = "Garage 1" });
                context.Garages.Add(new Garage { Name = "Garage 2" });
                context.SaveChanges();  

                var firstGarage = context.Garages.First();  
                context.Machines.Add(new Machine { Name = "Machine 1", Garage = firstGarage });
                context.Machines.Add(new Machine { Name = "Machine 2", Garage = firstGarage });

                context.SaveChanges();  
            }
        }
    }
}
