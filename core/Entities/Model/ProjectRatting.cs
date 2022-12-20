using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class ProjectRatting : BaseEntity
    {
        public string? feedback {get;set;}
        public int ratting {get;set;}
        public string project_id {get;set;}
    }
}