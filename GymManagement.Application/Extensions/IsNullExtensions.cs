using GymManagement.Application.Exceptions;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Extensions
{
    public static class IsNullExtensions
    {
        public static void IfIsNullThrowNotFoundException(this BaseEntity entity, string name, object key = null)
        {
            if (entity is null)
            {
                throw new NotFoundException(name, key);
            }
        }
    }
}
