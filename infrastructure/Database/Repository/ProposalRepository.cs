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
    public class ProposalRepository : Repository<Proposals>, IProjectProposalRepository
    {
        public ProposalRepository(DataContext context) : base(context)
        {
        }
    }
}