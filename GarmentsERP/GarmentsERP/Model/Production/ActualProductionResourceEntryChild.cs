using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class ActualProductionResourceEntryChild
    {
        public int Id { get; set; }
        public string Fromdate { get; set; }
        public string ToDate { get; set; }
        public double ManPowerOrline { get; set; }
        public double OperatorOrline { get; set; }
        public double HelperOrline { get; set; }
        public string StylRef { get; set; }
        public string LineChief { get; set; }
        public double ActiveMachineline { get; set; }
        public double TargetHourline { get; set; }
        public double WorkingHour { get; set; }
        public double Capacity { get; set; }
        public double TargetEff { get; set; }
        public string ExtraHourSMVAd { get; set; }
        public int MasterId { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


    }
}
