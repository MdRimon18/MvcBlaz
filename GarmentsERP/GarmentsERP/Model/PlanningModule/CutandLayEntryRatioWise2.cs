using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.PlanningModule
{
    public class CutandLayEntryRatioWise2
    {
        public int Id { get; set; }
        public string CuttingNumber { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }

        public double TableNo { get; set; }
        public string CadMarkerlength { get; set; }
        public double CadMarkerWidthOrDia { get; set; }
        public double CadFabricWidthOrDia { get; set; }
        public double CadGsm { get; set; }
        public string JobNo { get; set; }
        public int YearId { get; set; }
        public string Batch { get; set; }
        public int BuyerProfileId { get; set; }
        public string PlanStartDate { get; set; }
        public double StartTimeHour { get; set; }
        public double StartTimeMinute { get; set; }
        public string PlanEndDate { get; set; }
        public double EndTimeHour { get; set; }
        public double EndTimeMinute { get; set; }
        public string WidthOrDiaType { get; set; }

        public double CadMarkerConsOrDzn { get; set; }
        public string StyleRef { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
