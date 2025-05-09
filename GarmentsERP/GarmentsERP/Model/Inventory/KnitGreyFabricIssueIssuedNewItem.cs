using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class KnitGreyFabricIssueIssuedNewItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int BodyPart { get; set; }
        public string YarnLot { get; set; }
        public string Fabric { get; set; }
        public int Gsm { get; set; }
        
        public double DiaWidth { get; set; }
        public int YarnCount { get; set; }
        public string StitchLength { get; set; }
        public string Brand { get; set; }
        public double McDia { get; set; }
        public string McGauge { get; set; }
        public double NoOfRoll { get; set; }
        public string ShiftName { get; set; }
        public int GreyReceiveQnty { get; set; }
        public int MachineNo { get; set; }
        public double Rate { get; set; }
        public string Floor { get; set; }
        public double Amount { get; set; }
        public string Room { get; set; }
        public string FabricColor { get; set; }
        public string Rack { get; set; }
        public int ColorRange { get; set; }
        public string Shelf { get; set; }
        public string RejectFabricReceive { get; set; }
        public string BinBox { get; set; }


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
