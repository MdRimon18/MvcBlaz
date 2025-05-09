using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class CapacityCalculationYearly
    {
        [Key]
        public int Id { get; set; }
        public string Month { get; set; }
        public int WorkingDay { get; set; }
        public double CapacityMinutes { get; set; }
        public double CapacityPcs { get; set; }
        public int CapacityCalculationId { get; set; }
        public string CapacityCalculationYear { get; set; }
        public string CapacityCalculationMonth { get; set; }
    }
}
