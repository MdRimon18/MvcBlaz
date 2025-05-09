using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GreyFabricIssueReturnRollWiseDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string Sl { get; set; }
        public string BarcodeNo { get; set; }
        public string RollNo { get; set; }
        public string Location { get; set; }
        public string ProductId { get; set; }
        public string BodyPart { get; set; }
        public string ConstructionbyComposition { get; set; }
        public string Gsm { get; set; }
        public string Dia { get; set; }
        public string StitchLength { get; set; }
        public string Color { get; set; }
        public string MachineNo { get; set; }
        public string RollWgt { get; set; }
        public string Buyer { get; set; }
        public string JobNo { get; set; }
        public string OrderbyFSONo { get; set; }
        public string KnitCompany { get; set; }
        public string Basis { get; set; }
        public string DelibyBookingbyPINobyTransNo { get; set; }


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
