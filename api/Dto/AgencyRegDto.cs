using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AgencyRegDto
    {
        public string? name {get;set;}
        public string? type {get;set;}
        public string? description {get;set;}
        public string? email {get;set;}
        public string? password {get;set;}

        public string? code {get;set;}
    }
}