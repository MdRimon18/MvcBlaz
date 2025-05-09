using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class YarnReceive  
    {
        public int Id { get; set; }
        public string MrNumber{ get; set; }
        public int CompanyId { get; set; }
        public string ReceiveBasis { get; set; }
        public string ReceivePurpose { get; set; }
        public string ReceiveDate { get; set; }
        public string ChallanNo { get; set; }
        public string StoreName { get; set; }
        public string WoOrPI { get; set; }
        public int SupplierId { get; set; }
        public string LoanParty { get; set; }
        public int CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public string Source { get; set; }
        public string LcNo { get; set; }
        public string IssueChallanNo { get; set; }
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
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string SupplierName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }


    }
}
