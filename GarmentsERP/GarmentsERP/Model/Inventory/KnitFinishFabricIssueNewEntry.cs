using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class KnitFinishFabricIssueNewEntry
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string StoreName { get; set; }
        public string BatchNo { get; set; }
        public string FabricDescription { get; set; }
        public int Uom { get; set; }
        public int SampleType { get; set; }
        public int BodyPart { get; set; }
        public int GarmentsItem { get; set; }
        public string Color { get; set; }
        public double IssueQnty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string NoOfRoll { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
        public string CuttingUnitNo { get; set; }
        public string FabricShade { get; set; }
        public string Remarks { get; set; }


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
