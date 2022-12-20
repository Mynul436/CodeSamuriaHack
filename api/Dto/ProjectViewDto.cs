using core.Entities.Model;

namespace api.Dto
{

    public class PLocation
    {
        public double Latitude {get;set;}
        public double Logitude {get;set;}
    }


    public class Agency{
        public int id {get;set;}
        public string Name {get;set;}
    }
    
    public class ProjectViewDto
    {
        public string? ProjectName {get;set;}
        public string CategoryName {get;set;}
        public int CategoryId {get;set;}

        public string Description {get;set;}

        public DateOnly StartTime {get;set;}
        public DateOnly CompletionTime {get;set;}

        public string TotalBudget{get;set;}

        public double CompletionPercentage {get;set;}

        public List<Agency>? AffiliatedAgencies {get;set;}
        public List<PLocation> Locations{get;set;}
       

    
    }
}