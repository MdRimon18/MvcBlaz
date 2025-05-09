using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class WovenFinishFabricIssueNewEntry
    {
        public int Id { get; set; }
        public int MatserId { get; set; }
        public string StoreName { get; set; }
        public string NoofRoll { get; set; }
        public string BatchByLot { get; set; }
        public string FabricDescription { get; set; }
        public double IssueQnty { get; set; }
        public int Uom { get; set; }
        public int GarmentsItem { get; set; }
        public int CuttingUnitNo { get; set; }


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
