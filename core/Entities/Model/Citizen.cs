using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities.Model
{
    public class Citizen : BaseEntity
    {
        public string name {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public string role = "CIT";
    }
}