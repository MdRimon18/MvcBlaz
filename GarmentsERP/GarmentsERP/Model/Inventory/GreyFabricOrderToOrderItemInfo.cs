using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GreyFabricOrderToOrderItemInfo
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ItemCategory { get; set; }
        public string YbyCount { get; set; }
        public string YbyBrand { get; set; }
        public int ItemDescription { get; set; }
        public string YbyLot { get; set; }
        public double TransferedQty { get; set; }
        public string TransferedUnit { get; set; }
        public string FromRack { get; set; }
        public string ToRack { get; set; }
        public string Roll { get; set; }
        public string FromShelf { get; set; }
        public string ToShelf { get; set; }
        public string FromProg { get; set; }
        public string StitchLength { get; set; }
        public string CurrentStockOrder { get; set; }


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
