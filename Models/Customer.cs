using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcPeoject.Models
{
    public class Customer
    {
        [Key]
        [StringLength(50)]
        public string guid { get; set; }

        [StringLength(50)]
        public string sceneguid { get; set; }

        [StringLength(200)]
        public string customername { get; set; }

        [StringLength(10)]
        public string isinclude { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(20)]
        public string longitude { get; set; }

        [StringLength(20)]
        public string latitude { get; set; }

        [StringLength(20)]
        public string province { get; set; }

        [StringLength(20)]
        public string city { get; set; }

        [StringLength(20)]
        public string district { get; set; }

        [StringLength(50)]
        public string copyvalue { get; set; }
    }
}
