using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class Proposals : BaseEntity
    {
        public string? name {get;set;}
        public string? location {get;set;}
        public double latitude {get;set;}
        public double longitude {get;set;}
        public string? exec {get;set;}
        public double cost {get;set;}
        public double timespan {get;set;}
        public string? project_id {get;set;}
        public string? goal {get;set;}
        public DateTime  proposal_date{get;set;}

       // name,location,latitude,longitude,exec,cost,timespan,project_id,goal,proposal_date
    }
}