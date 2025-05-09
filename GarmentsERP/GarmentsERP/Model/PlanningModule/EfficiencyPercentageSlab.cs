using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.PlanningModule
{
    public class EfficiencyPercentageSlab
    {
        public int Id { get; set; }
        public double LowerLimitForSMVRange { get; set; }
        public double UpperLimitForSMVRange { get; set; }
        public double LowerLimitForOrderQty { get; set; }
        public double UpperLimitForOrderQty { get; set; }
        public double NewOrderForEfficiency { get; set; }
        public double RepeatOrderForEfficiency { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
