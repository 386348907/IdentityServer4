using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 

namespace Models
{
    public class UserSecret
    {

        public int ID { get; set; }

        [MaxLength(100)]
        public string secretName { get; set; }

        /// <summary>
        /// 加密类型
        /// </summary>
        [MaxLength(30)]
        public string pwType { get; set; }


        [MaxLength(50)]
        public string clientId { get; set; }


    }
}
