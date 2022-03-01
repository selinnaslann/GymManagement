using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.Repositories
{
    public class EmployeeDetailsRepository: RepositoryBase<EmployeeDetail>, IEmployeeDetailRepository
    {
        public EmployeeDetailsRepository(GymManagementDbContext context) : base(context)
        {

        }
    }
}
