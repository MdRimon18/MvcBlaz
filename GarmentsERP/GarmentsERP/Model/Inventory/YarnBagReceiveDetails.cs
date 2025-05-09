using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class YarnBagReceiveDetails
    {
        public int Id { get; set; }
        public string MasterId { get; set; }
        public double Lot { get; set; }
        public int Count { get; set; }
        public int Composition { get; set; }
        public double Parcentage { get; set; }
        public string YarnType { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string BagBarcodeNo { get; set; }
        public double WgtByCone { get; set; }
        public double ConeByBag { get; set; }
        public double BagWgt { get; set; }
        public double RateBykg { get; set; }
        public double IleCost { get; set; }
        public double Amount { get; set; }
        public string BookCurrency { get; set; }


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
