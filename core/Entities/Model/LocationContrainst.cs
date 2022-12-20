using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class LocationContrainst : BaseEntity
    {
        public double latitude {get;set;}
        public double longitude {get;set;}
        public int max_projects {get;set;}
    }
}