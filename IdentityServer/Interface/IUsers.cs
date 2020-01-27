using IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Interface
{
    public interface IUsers
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>

        public List<Users> GetUsers();


    }
}
