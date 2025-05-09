using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class KnittingProduction
    {
        public int Id { get; set; }
        public string ProductionBasis { get; set; }
        public string ProductionDate { get; set; }
        public string ReceiveChallanNo { get; set; }
        public string FabBookingOrKnitPlan { get; set; }
        public string KnittingSource { get; set; }
        public string YarnIssueChNo { get; set; }
        public string YarnIssued { get; set; }
        public string JobNo { get; set; }
        public string BuyerId { get; set; }
        public string ServiceBookingBased { get; set; }
        public string StoreName { get; set; }
        public string Remarks { get; set; }
        public int BodyPartId { get; set; }
        public string Uom { get; set; }
        public int FabricDescriptionId { get; set; }
        public string FabricDescription { get; set; }
        public double Gsm { get; set; }
        public string Brand { get; set; }
        public string DiaOrWidth { get; set; }
        public string ShiftName { get; set; }
        public string StitchLength { get; set; }
        public string McGauge { get; set; }
        public double McDia { get; set; }
        public int ProdFloor { get; set; }
        public double NoofRoll { get; set; }
        public int MachineNo { get; set; }
        public double GreyProdQnty { get; set; }
        public string Operator { get; set; }
        public string FabricColor { get; set; }
        public double Room { get; set; }
        public int ColorRangeId { get; set; }
        public string Rack { get; set; }
        public double RejectFabricReceive { get; set; }
        public double Shelf { get; set; }
        public double YarnLot { get; set; }
        public double BinOrBox { get; set; }
        public string YarnCountId { get; set; }
        public double Size { get; set; }


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
