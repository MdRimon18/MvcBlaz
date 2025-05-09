using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class FinishFabricRollReceiveByStoreDetails
    {
        public int Id { get; set; }
        public int SL { get; set; }
        public int MasterId { get; set; }
        public string BarcodeNo { get; set; }
        public string RollNo { get; set; }
        public string BatchNo { get; set; }
        public string BodyPart { get; set; }
        public string Construction { get; set; }
        public string Composition { get; set; }
        public string Color { get; set; }
        public string Gsm { get; set; }
        public string Dia { get; set; }
        public string RollQty { get; set; }
        public string RejectQty { get; set; }
        public string GreyWgt { get; set; }
        public string Room { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
        public string DiaWidthType { get; set; }
        public string Year { get; set; }
        public string JobNo { get; set; }
        public string Buyer { get; set; }
        public string OrderNo { get; set; }
        public string ProductId { get; set; }
        public string SystemId { get; set; }


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
