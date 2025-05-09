using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class YarnBagReceive
    {
        public int Id { get; set; }
        public string MrrNumber { get; set; }
        public string ReceiveDate { get; set; }
        public string StoreName { get; set; }
        public string ChallanNo { get; set; }
        public string Purpose { get; set; }
        public string ReceiveBasis { get; set; }
        public string PiWONo { get; set; }
        public int CompanyId { get; set; }
        public string Source { get; set; }
        public int CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public int SupplierId { get; set; }
        public string BagBarcode { get; set; }


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
