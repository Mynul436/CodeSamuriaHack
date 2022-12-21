using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ProposalAddAROdto
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
        public DateTime appropriate {get;set;}

    }
}