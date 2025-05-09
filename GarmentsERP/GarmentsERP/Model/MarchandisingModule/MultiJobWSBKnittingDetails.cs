using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class MultiJobWSBKnittingDetails
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int MultiJobWSBKnittingId { get; set; }
        public int ProcessId { get; set; }
        public string Sensitivity { get; set; }
        public string ProgramNo { get; set; }
        public string JobNo { get; set; }
        public string PoNumber { get; set; }
        public int FabricDescriptionId { get; set; }
        public string ArtworkNo { get; set; }
        public string Ycount { get; set; }
        public string Lot { get; set; }
        public string Brand { get; set; }
        public string GmtsColor { get; set; }
        public string ItemColor { get; set; }
        public string ItemSize { get; set; }
        public string FabMapping { get; set; }
        public string MorcDiaXGG { get; set; }
        public string FinDia { get; set; }
        public string FinGSM { get; set; }
        public string Slength { get; set; }
        public string DeliveryStartDate { get; set; }
        public string DeliveryEndDate { get; set; }
        public int UomId { get; set; }
        public double WoQnty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double PlanCutQnty { get; set; }
        public string Remark { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
