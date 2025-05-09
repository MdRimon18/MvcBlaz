using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class SupplierProfile
    {
        [Key]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string ShortName { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string HttpWww { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string AddressThree { get; set; }
        public string AddressFour { get; set; }
        public string CountryId { get; set; }
        public string PartyTypeIds { get; set; }
        public string TagCompany { get; set; }
        public string LinkToBuyer { get; set; }
        public int CreditLimitDays { get; set; }
        public int CrditLimitAmount { get; set; }
        public string CrditLimitAmountType { get; set; }
        public int DiscountMethod { get; set; }
        public string SecuirityDeducted { get; set; }
        public string VatToBeDeducted { get; set; }
        public string AitToBeDeducted { get; set; }
        public string Remark { get; set; }
        public string Individual { get; set; }
        public string Status { get; set; }
        public string SupplierNature { get; set; }
        public string Image { get; set; }
        public string TagBuyer { get; set; }
        public string SupplierRef { get; set; }
        public string EntryDate { get; set; }
        public int? EntryBy { get; set; }
    }
}
