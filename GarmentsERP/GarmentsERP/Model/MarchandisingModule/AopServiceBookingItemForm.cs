using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class AopServiceBookingItemForm
    {
        public int Id { get; set; }
        public int ServiceBookingForAopv2MasterId { get; set; }
        public int FabricCostMasterId { get; set; }
        public int FabricDesPreCostId { get; set; }
        public string FabricDescription { get; set; }
        public int PreCostingId { get; set; }
        public string JobNo { get; set; }
        public string PoNumber { get; set; }
        public string BodyPart { get; set; }
        public string ColorType { get; set; }
        public string Construction { get; set; }
        public string Composition { get; set; }
        public double Gsm { get; set; }
        public string Dia { get; set; }
        public string GmtsColor { get; set; }
        public string ItemColor { get; set; }
        public string FinDia { get; set; }
        public string PrintingColor { get; set; }
        public string ArtworkNo { get; set; }
        public string DeliveryStartDate { get; set; }
        public string DeliveryEndDate { get; set; }
        public double BlaQnty { get; set; }
        public double WoQnty { get; set; }
        public string Uom { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double PlanCutQnty { get; set; }


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
