using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class WovenFinishFabricNewReceiveItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int BodyPart { get; set; }
        public double Amount { get; set; }
        public string FabricType { get; set; }
        public string BookCurrency { get; set; }
        public string FabricDesc { get; set; }
        public string BalancePIByWO { get; set; }
        public string Color { get; set; }
        public string Roll { get; set; }
        public string Width { get; set; }
        public int CuttingUnitName { get; set; }
        public string Weight { get; set; }
        public string Room { get; set; }
        public string BatchByLot { get; set; }
        public string Rack { get; set; }
        public int Uom { get; set; }
        public string Shelf { get; set; }
        public double RecvQnty { get; set; }
        public string BinByBox { get; set; }
        public double Rate { get; set; }
        public string IleParcentage { get; set; }
        public string ProductID { get; set; }
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
