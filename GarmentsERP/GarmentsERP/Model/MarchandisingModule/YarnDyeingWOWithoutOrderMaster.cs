using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class YarnDyeingWOWithoutOrderMaster
    {
        public int Id { get; set; }
        public string YarnDyeingWoNo { get; set; }
        public int YarnDyeingFactory { get; set; }
        public string BookingDate { get; set; }
        public string Attention { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public string GorYIssueStart { get; set; }
        public string GorYIssueEnd { get; set; }
        public string DorYDeliveryStart { get; set; }
        public string DorYDeliveryEnd { get; set; }
        public int ItemCategoryId { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
