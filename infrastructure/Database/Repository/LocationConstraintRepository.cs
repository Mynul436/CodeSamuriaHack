using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities.Model;
using core.Interfaces;
using infrastructure.Database.Generic;
using infrastructure.Database.StoreContext;

namespace infrastructure.Database.Repository
{
    public class LocationConstraintRepository : Repository<LocationContrainst>, ILocationConstraintRepository
    {
        public LocationConstraintRepository(DataContext context) : base(context)
        {
        }
    }
}