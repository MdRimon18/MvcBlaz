using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class NewReceiveItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int YarnCount { get; set; }
        public string Brand { get; set; }
        public double BookCurrency { get; set; }
        public int Floor { get; set; }
        public int CompositionDDLOne { get; set; }
        public double CompositionDDLTwo { get; set; }
        public int CompositionValueOne { get; set; }
        public double CompositionValueTwo { get; set; }
        public double RecvQnty { get; set; }
        public double NoOfBag { get; set; }
        public string Room { get; set; }
        public int Uom { get; set; }
        public double NoOfConePerBag { get; set; }
        public string Rack { get; set; }
        public double Rate { get; set; }
        public double RateAvg { get; set; }
        public double RateDch { get; set; }
        
        public string YarnType { get; set; }
        public double NoOfLooseCone { get; set; }
        public string Shelf { get; set; }
        public int Color { get; set; }
        public double IlePercentage { get; set; }
        public double WeightPerBag { get; set; }
        public double BinBox { get; set; }
        public double LotBatch { get; set; }
        public double Amount { get; set; }
        public double WghtCone { get; set; }
        public string Remarks { get; set; }
        public int BuyerId { get; set; }
        public double BalPIOrdQnty { get; set; }
        public string ProductCode { get; set; }
        public int OverRecvQnty { get; set; }


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
