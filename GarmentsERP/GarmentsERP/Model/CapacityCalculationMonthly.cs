using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class CapacityCalculationMonthly
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string DayStatus { get; set; }
        public int NoOfLine { get; set; }
        public double CapacityMinutes { get; set; }
        public double CapacityPcs { get; set; }
        public int CapacityCalculationId { get; set; }
        public string CapacityCalculationYear { get; set; }
        public string CapacityCalculationMonth { get; set; }
        public double Manpower { get; set; }
    }
}
