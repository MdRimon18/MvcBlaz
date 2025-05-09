using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class RollwiseGreyFabricOrderToOrderTransferEntryDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int Sl { get; set; }
        public string BarcodeNo { get; set; }
        public string RollNo { get; set; }
        public string ProgramNo { get; set; }
        public string ProductId { get; set; }
        public string FabricDescription { get; set; }
        public string YoRCount { get; set; }
        public string YoRBrand { get; set; }
        public string YoRLot { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
        public string StitchLength { get; set; }
        public string RollWgt { get; set; }


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
