using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Entities.Model;

namespace core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IProjectRepository ProjectRepository {get;}
        IProjectProposalRepository ProposalRepository{get;}
        IAgencyRepository AgencyRepository {get;}

        ILocationConstraintRepository LocationConstraintRepository {get;}

        IUserTypeRepository UserTypeRepository {get;}
        IComponentType ComponentTypeRepository {get;}

        IRepository<Citizen> CitizenRepository {get;}
        IRepository<ProjectRatting> RattingRepository{get;}

        IRepository<Constraint> Constraints {get;}
   
        Task CommitAsync();
        Task RollbackAsync();        
    }
}