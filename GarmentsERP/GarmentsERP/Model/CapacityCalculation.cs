using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class CapacityCalculation
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CapacitySource { get; set; }
        public int Location { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public double ManOrMachinePerLine { get; set; }
        public double BasicSAM { get; set; }
        public double Efficiency { get; set; }

        public string FinType { get; set; }
        public double Smv { get; set; }
        public double WoHrs { get; set; }
    }
}
