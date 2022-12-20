using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AddFeedBackRatting
    {
        public string? feedback {get;set;}
        public int ratting {get;set;}

        public string? project_id{get;set;}

    }
}