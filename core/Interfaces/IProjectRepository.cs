
using core.Entities.Model;
using core.Helpers;

namespace core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<PagedList<Project>> getProjectList();
    }
}