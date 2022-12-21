
using infrastructure.Database.StoreContext;

using core.Entities.Model;
using infrastructure.Database.Repository;
using core.Interfaces;
using infrastructure.Database.Generic;

namespace infrastructure.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IProjectRepository ProjectRepository => new ProjectRepository(_context);
        public IProjectProposalRepository ProposalRepository => new ProposalRepository(_context);
        public IAgencyRepository AgencyRepository =>  new AgencyRepository(_context);
        public ILocationConstraintRepository LocationConstraintRepository => new LocationConstraintRepository(_context);
        public IUserTypeRepository UserTypeRepository => new UserTypeRepository(_context);

        public IComponentType ComponentTypeRepository => new ComponentTypeRepository(_context);

        public IRepository<Citizen> CitizenRepository => new Repository<Citizen>(_context);

        public IRepository<ProjectRatting> RattingRepository => new Repository<ProjectRatting>(_context);

        public IRepository<Constraint> Constraints => new Repository<Constraint>(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}