using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class Constraint : BaseEntity
    {
        public string? code {get;set;}
        public int max_limit {get;set;}
        public string? constraint_type {get;set;}
    }
}