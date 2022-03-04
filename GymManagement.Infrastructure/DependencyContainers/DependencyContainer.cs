using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Contexts;
using GymManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Infrastructure.UnitOfWorks;

namespace GymManagement.Infrastructure.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<GymManagementDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("mssql")));
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IEmployeeDetailRepository, EmployeeDetailsRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IExerciseProgramRepository, ExerciseProgramRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IMissionRepository, MissionRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IWorkerContractRepository, WorkerContractRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
    

