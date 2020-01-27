using IdentityServer.Interface;
using IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.RInterface
{
    public class RUsers : IUsers
    {
        public List<Users> GetUsers()
        {

            return new List<Users> {
            new Users("张三","123","1")
            };
 
            throw new NotImplementedException();
        }
    }
}
