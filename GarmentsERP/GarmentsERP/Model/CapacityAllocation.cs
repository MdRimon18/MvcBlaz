using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class CapacityAllocation
    {
        [Key]
        public int Id { get; set; }
        public int Company { get; set; }
        public int Location { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public int YearName { get; set; }
        [NotMapped]
        public string MonthName { get; set; }
    }
}
