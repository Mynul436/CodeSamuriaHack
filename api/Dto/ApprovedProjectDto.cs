using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ApprovedProjectDto
    {
        public DateTime startdate {get;set;}
        public double completion {get;set;}
        public double actual_cost {get;set;}
        public string project_id {get;set;}
    }
}