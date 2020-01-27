using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class Users
    {

        public Users(string uName,string password,string status) {

            uName = uName;
            password = password;
            status = status;


        }

        public int ID { get; set; }

        public string uName { get; set; }

        public string password { get; set; }

        public int status { get; set; }

 
    }
}
