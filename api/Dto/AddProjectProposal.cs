using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AddProjectProposal
    {        
        public string? name {get;set;}
        public string? location {get;set;}
        public double latitude {get;set;}
        public double longitude {get;set;}
        public string? code {get;set;}
        public double cost {get;set;}
        public double timespan {get;set;}
        public string? goal {get;set;}
    }
}