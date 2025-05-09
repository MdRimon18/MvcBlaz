using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class SalesContractEntry
    {
        public int Id { get; set; }
        public int Beneficiary { get; set; }
        public string InternalFileNo { get; set; }
        public string BankFileNo { get; set; }
        public string Year { get; set; }
        public string ContractNumber { get; set; }
        public double ContractValue { get; set; }
        public int CurrencyId { get; set; }
        public string ContractDate { get; set; }
        public string ConvertibleTo { get; set; }
        public int BuyerProfileId { get; set; }
        public string ApplicantNameId { get; set; }
        public string NotifyingParty { get; set; }
        public string Consignee { get; set; }
        public int LienBank { get; set; }
        public string LienDate { get; set; }
        public string LastShipmentDate { get; set; }
        public string ExpiryDate { get; set; }
        public double Tolerance { get; set; }
        public int ShippingMode { get; set; }
        public string PayTerm { get; set; }
        public double Tenor { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public string ContractSource { get; set; }
        public string PortofEntry { get; set; }
        public string PortofLoading { get; set; }
        public string PortofDischarge { get; set; }
        public string ShippingLine { get; set; }
        public double DocPresentDays { get; set; }
        public double ClaimAdjustment { get; set; }
        public double BtbLimit { get; set; }
        public double ForeignComn { get; set; }
        public double LocalComn { get; set; }
        public string ConvertedFrom { get; set; }
        public string TransferedBTBLC { get; set; }
        public string DiscountClauses { get; set; }
        public string BlClause { get; set; }
        public int ExportItemCategory { get; set; }
        public string Remarks { get; set; }
        public string ImportBTB { get; set; }
        public string ImportBTBId { get; set; }


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
        public string Currency { get; set; }

        [NotMapped]
        public string ExportItemCategoryName { get; set; }

        [NotMapped]
        public string ShippingModeName { get; set; }

        [NotMapped]
        public string NotifyingPartyName { get; set; }

        [NotMapped]
        public string ConsigneeName { get; set; }

        [NotMapped]
        public string LienBankName { get; set; }

        [NotMapped]
        public string BuyerName { get; set; }

        [NotMapped]
        public string BeneficiaryName { get; set; }



    }
}
