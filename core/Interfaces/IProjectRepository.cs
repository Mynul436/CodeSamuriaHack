
using core.Entities.Model;
using core.Helpers;

namespace core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<PagedList<Project>> getProjectList();

        Task<PagedList<Proposals>> getProposedProject(string code);

        Task<PagedList<Project>> GetProjectsCitizen(double longitide, double latitude, double radious);

        Task<PagedList<Proposals>> GetProposalList(string code);
        
    }
}