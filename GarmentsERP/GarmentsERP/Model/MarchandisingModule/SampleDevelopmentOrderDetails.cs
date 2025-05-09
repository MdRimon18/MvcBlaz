using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SampleDevelopmentOrderDetails
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string StyleName { get; set; }
        public string ProductDept { get; set; }
        public string ArticleNumber { get; set; }
        public int GarmentsItemId { get; set; }
        public int ProductCategoryId { get; set; }
        public int RegionId { get; set; }
        public int AgentId { get; set; }
        public int TeamLeaderId { get; set; }
        public int DealingMerchantId { get; set; }
        public string BHMerchant { get; set; }
        public string EstShipDate { get; set; }
        public string Season { get; set; }
        public string Remarks { get; set; }
        public string Images { get; set; }
        public string File { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }
    }
}
