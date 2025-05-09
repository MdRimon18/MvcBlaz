using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class FinishFabricRollIssueDetails
    {
        public int Id { get; set; }
        public string MasterId { get; set; }
        public string Sl { get; set; }
        public string BarcodeNo { get; set; }
        public string RollNo { get; set; }
        public string BatchNo { get; set; }
        public string ProductId { get; set; }
        public int GmtItem { get; set; }
        public string BodyPart { get; set; }
        public string ConstructionByComposition { get; set; }
        public string Dia { get; set; }
        public string Color { get; set; }
        public string RollWgt { get; set; }
        public string Buyer { get; set; }
        public string JobNo { get; set; }
        public string OrderNo { get; set; }
        public string ProgramByBookingByPINo { get; set; }
        public string Basis { get; set; }


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
