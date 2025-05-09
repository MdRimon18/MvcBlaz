using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class UOM
    {
        [Key]
        public int Id { get; set; }
        public string UomName { get; set; }
        public string status { get; set; }
       
    }
}
