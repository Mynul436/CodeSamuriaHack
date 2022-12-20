using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class Agency : BaseEntity
    {
        public string? code {get;set;}
        public string? name {get;set;}
        public string? type {get;set;}
        public string? description {get;set;}

        public string? email {get;set;}
        public string? password {get;set;}
    }
}