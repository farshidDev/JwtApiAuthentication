using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApiAuthenticationApp.Classes
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
