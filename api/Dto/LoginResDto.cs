using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class LoginResDto
    {
        public string Id {get;set;}
        public string name {get;set;}
        public string role {get;set;}
        public string token {get;set;}
        public string code {get;set;}
    }
}