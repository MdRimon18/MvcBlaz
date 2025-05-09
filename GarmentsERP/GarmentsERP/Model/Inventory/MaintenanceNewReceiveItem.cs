using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class MaintenanceNewReceiveItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ItemCategoryId { get; set; }
        public double RecvQnty { get; set; }
        public string BookCurrency { get; set; }
        public string Room { get; set; }
        public int ItemGroup { get; set; }
        public double Rate { get; set; }
        public string WarrantyExpDate { get; set; }
        public string Rack { get; set; }
        public int ItemDescription { get; set; }
        public double IlePercentage { get; set; }
        public string SerialNo { get; set; }
        public string Self { get; set; }
        public int Uom { get; set; }
        public double Amount { get; set; }
        public double BalByPIByOrdByReqQnty { get; set; }
        public string BinByBox { get; set; }
        public string GlobalStock { get; set; }
        public string Brand { get; set; }
        public int Origin { get; set; }
        public string Model { get; set; }
        public string Comments { get; set; }


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
