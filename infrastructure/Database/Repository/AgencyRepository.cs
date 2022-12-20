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
    public class AgencyRepository : Repository<Agency>, IAgencyRepository
    {
        public AgencyRepository(DataContext context) : base(context)
        {
        }
    }
}