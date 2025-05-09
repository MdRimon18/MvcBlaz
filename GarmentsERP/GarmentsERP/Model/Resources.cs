using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class Resources
    {
        [Key]
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string status { get; set; }
    }
}
