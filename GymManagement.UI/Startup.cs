using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GymManagement.Application.DependencyContainers;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Services;
using GymManagement.Infrastructure.DependencyContainers;

namespace GymManagement.UI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IExerciseProgramService, ExerciseProgramService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IAuthService, AuthService>();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}