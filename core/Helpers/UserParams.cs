namespace core.Helpers
{
    public class UserParams : PaginationParams
    {
        public int TypeId {get;set;} = -1;
        public double LowPrices {get;set;} = 0;
        public double HighPrices {get;set;} = 2000000000;


        public string? Name {get;set;} = "-1";
        public string? District {get;set;} = "-1";
        public string? SubDistrict {get;set;} = "-1";
        public string? OrderByPrices {get;set;}

        
    }
}