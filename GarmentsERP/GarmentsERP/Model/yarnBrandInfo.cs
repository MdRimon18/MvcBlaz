using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public partial class yarnBrandInfo
    {
       
             
        [Key]
        public int yarnBrandId { get; set; }
        public string yarnBrandName { get; set; }
        public int sequenceNo { get; set; }
        public string status { get; set; }

    
    }
}
