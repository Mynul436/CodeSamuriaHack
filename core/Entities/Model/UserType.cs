using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class UserType : BaseEntity
    {
        public string? code {get;set;}
        public string? committee {get;set;}
        public string? description{get;set;}
    }
}