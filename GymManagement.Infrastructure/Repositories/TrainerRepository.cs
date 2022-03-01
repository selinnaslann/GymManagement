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
    public class TrainerRepository : RepositoryBase<Trainer>, ITrainerRepository
    {
        public TrainerRepository(GymManagementDbContext context) : base(context)
        {

        }
    }
}
