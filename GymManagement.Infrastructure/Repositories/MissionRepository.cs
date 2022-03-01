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
    public class MissionRepository : RepositoryBase<Mission>, IMissionRepository
    {
        public MissionRepository(GymManagementDbContext context) : base(context)
        {

        }
    }
}
