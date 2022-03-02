using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddApplicationServices(this IServiceCollection services )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
