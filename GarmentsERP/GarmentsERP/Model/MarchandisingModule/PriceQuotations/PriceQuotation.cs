using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.PriceQuotations
{
    public class PriceQuotation
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int QuotationId { get; set; }
        public int BuyerId { get; set; }
        public string StyleRef { get; set; }
        public double RevisedNo { get; set; }
        public string ProdDept { get; set; }
        public string StyleDesc { get; set; }
        public string MlistNo { get; set; }
        public int CurrencyId { get; set; }
        public double Er { get; set; }
        public int AgentId { get; set; }
        public double OfferQty { get; set; }
        public int RegionId { get; set; }
        public int ColorRangeId { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public double MachineOrLine { get; set; }
        public double ProdLineHr { get; set; }
        public string CostingPer { get; set; }
        public string QuotDate { get; set; }
        public string OpDate { get; set; }
        public string Factory { get; set; }
        public int OrderUomId { get; set; }
        public string Images { get; set; }
        public string EstShipDate { get; set; }
        public double LeadTime { get; set; }
        public double SewSmv { get; set; }
        public double SewEffi { get; set; }
        public double CutSmv { get; set; }
        public double CutEfficiency { get; set; }
        public int SeasonId { get; set; }
        public int DealingMerchantId { get; set; }
        public string BhMerchant { get; set; }
        public string Approved { get; set; }
        public string ReadyToApprove { get; set; }
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


    }
}
