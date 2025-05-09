using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class WovenFinishRollIssueReturnDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int Sl { get; set; }
        public string BarcodeNo { get; set; }
        public string RollNo { get; set; }
        public int BodyPart { get; set; }
        public string ConstructionOrComposition { get; set; }
        public string Gsm { get; set; }
        public string Dia { get; set; }
        public string Color { get; set; }
        public string RollWgt { get; set; }
        public int Buyer { get; set; }
        public string JobNo { get; set; }
        public string OrderNo { get; set; }
        public string FileNo { get; set; }
        public int KnitCompany { get; set; }
        public string MachineNo { get; set; }
        public string ProgramOrBookingOrPiNo { get; set; }
        public string ProductionBasis { get; set; }


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
