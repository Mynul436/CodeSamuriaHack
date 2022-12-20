using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace core.Interfaces
{
    public interface ITokenService
    {
        Tuple<String, DateTime> CreateToken(string user);
    }
}