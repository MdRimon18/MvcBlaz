using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsReceiveEntryMultiRefNewEntry
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string WoByPI { get; set; }
        public int OrderUOM { get; set; }
        public double Amount { get; set; }
        public int ItemGroup { get; set; }
        public double ReceiveQnty { get; set; }
        public double RejectQnty { get; set; }
        public int ItemDescription { get; set; }
        public double Rate { get; set; }
        public int BookKeepingCurrency { get; set; }
        public string BrandBySupRef { get; set; }
        public double IlePercentage { get; set; }
        public double BalancePIBtOrderQnty { get; set; }
        public int BuyerOrder { get; set; }
        public string ItemColor { get; set; }
        public string PaymentForOverRcvQty { get; set; }
        public string ItemSize { get; set; }
        public string ColorBySizeBalance { get; set; }


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
