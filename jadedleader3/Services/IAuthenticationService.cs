using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jadedleader3.Services
{
    public interface IAuthenticationService<T>
    {

        bool Authenticate(string username, string password, string filePath);

    }
}
