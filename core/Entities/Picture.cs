using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Picture : BaseEntity
    {
        public int ProductId {get;set;}
       


        
        public byte[] photo{get;set;}
    }
}