using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class QuotationInquery
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BuyerId { get; set; }
        public string StyleRefName { get; set; }
        public string Season { get; set; }
        public string InqRcvdDate { get; set; }
        public string Status { get; set; }
        public string BuyerInquiryNo { get; set; }
        public int DealingMerchantId { get; set; }
        public int GmtsItemId { get; set; }
        public string BulkEstShipDate { get; set; }
        public string Fabrication { get; set; }
        public double BulkOfferQty { get; set; }
        public string BodyColor { get; set; }
        public string TargetReqQuotDate { get; set; }
        public string TargetSampSubDate { get; set; }
        public string ActualSampSendDate { get; set; }
        public string DepartmentName { get; set; }
        public string ActualQuotDate { get; set; }
        public double BuyerTargetPrice { get; set; }
        public double BuyerSubmitPrice { get; set; }
        public string Remarks { get; set; }
        public string  FileName {get;set;}
        public string  FilePath {get;set;}
        public string  ImageName {get;set;}
        public string  ImagePath {get;set;}
        [NotMapped]
        public string CompanyName { get;set;}
        [NotMapped]
        public string BuyerName { get;set;}
      


    }
}
