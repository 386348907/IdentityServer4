using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class APIS
    {

        public int ID { get; set; }

        [MaxLength(100)]
        public string apiName { get; set; }
        [MaxLength(50)]
        public string apiDisplayName { get; set; }


        /// <summary>
        /// API所属服务分组
        /// </summary>
        [MaxLength(50)]
        public string Group { get; set; }

        /// <summary>
        /// API所属服务名称
        /// </summary>
        [MaxLength(50)]
        public string FServiceName { get; set; }

        /// <summary>
        /// API所属服务名称
        /// </summary>
        [MaxLength(50)]
        public string FServiceID { get; set; }

        /// <summary>
        /// AP状态
        /// </summary>
        public int apiStart { get; set; }




    }
}
