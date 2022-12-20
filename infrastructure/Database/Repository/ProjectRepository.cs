using core.Entities.Model;
using core.Helpers;
using core.Interfaces;
using infrastructure.Database.Generic;
using infrastructure.Database.StoreContext;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Database.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {

        private readonly DataContext _context;
        public ProjectRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Project>> getProjectList()
        {
            var query = _context.Projects.AsQueryable();

    

            var projects = await PagedList<Project>.CreateAsync(query, 1, 10);


           
            return projects;
        }
    }
}