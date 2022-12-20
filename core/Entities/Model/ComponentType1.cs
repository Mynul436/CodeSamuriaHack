using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class ComponentType1 : BaseEntity
    {
       // project_id,executing_agency,component_id,component_type
        public string? project_id {get;set;}
        public string? executing_agency {get;set;}
        public string? component_id {get;set;}
        public string? component_type {get;set;}
    }
}