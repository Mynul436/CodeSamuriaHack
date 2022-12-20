using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class User : BaseEntity
    {
        public string Name{get;set;}
        public string Email{get;set;}


        public string Role{get;set;}
    }
}