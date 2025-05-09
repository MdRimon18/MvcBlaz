using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.PlanningModule
{
    public class CutandLayEntryRatioWiseDetails
    {
        public int Id { get; set; }
        public int PoId { get; set; }
        public double OrderCutNo { get; set; }
        public string ShipDate { get; set; }
        public int GarmentsItemId { get; set; }
        public string GarmentsColor { get; set; }
        public string Batch { get; set; }
        public string Plies { get; set; }
        public double SizeRatio { get; set; }
        public double MarkerQnty { get; set; }
        public double Orderqty { get; set; }
        public double TotalLayqty { get; set; }
        public double Laybalanceqty { get; set; }
        public double CutandLayEntryRatioWiseMasterId { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
