using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserAllowedScopes
    {
        public int ID { get; set; }

        public string ClientId { get; set; }

        public int aPIID { get; set; }
 
        public int scopesStatus { get; set; }
 
    }
}
