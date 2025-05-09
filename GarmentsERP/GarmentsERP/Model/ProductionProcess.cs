using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ProductionProcess
    {
        [Key]
        public int Id { get; set; }
        public string ProductionProcessName { get; set; }
        public string status { get; set; }
    }
}
