using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class BuyerProfile
    {
        [Key]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ShortName { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string ExportersRef { get; set; }
        public string Email { get; set; }
        public string HttpWww { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string AddressThree { get; set; }
        public string AddressFour { get; set; }
        public int CountryId { get; set; }
        public string PartyTypeIds { get; set; }
        public string TagCompany { get; set; }
        public string LinkToSupplier { get; set; }
        public int CreditLimitDays { get; set; }
        public int CrditLimitAmount { get; set; }
        public string CrditLimitAmountType { get; set; }
        public int DiscountMethod { get; set; }
        public string SecuirityDeducted { get; set; }
        public string VatToBeDeducted { get; set; }
        public string AitToBeDeducted { get; set; }
        public string Remark { get; set; }
        public int MarketingTeamId { get; set; }
        public double SewingEffiMkt { get; set; }
        public double SewingEffiPlaning { get; set; }
        public double DeffdLcCost { get; set; }
        public string CutOffUsed { get; set; }
        public string ControlDelivery { get; set; }
        public int DeliveryBufferDays { get; set; }
        public double MinQuotedProfit { get; set; }
        public double MinBudgetedProfit { get; set; }
        public string Status { get; set; }
        public string CommercialInvoice { get; set; }
        public string TagSample { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string EntryDate { get; set; }
        public int? EntryBy { get; set; }



    }
}
