using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportLCEntry
    {
        public int Id { get; set; }
        public int Beneficiary { get; set; }
        public string InternalFileNo { get; set; }
        public string Year { get; set; }
        public string LcNumber { get; set; }
        public double LcValue { get; set; }
        public string LcDate { get; set; }
        public int CurrencyId { get; set; }
        public int ApplicantNameId { get; set; }
        public string NotifyingParty { get; set; }
        public string Consignee { get; set; }
        public string IssuingBank { get; set; }
        public int LienBank { get; set; }
        public string LienDate { get; set; }
        public string LastShipmentDate { get; set; }
        public string LcExpiryDate { get; set; }
        public double Tolerance { get; set; }
        public int ShippingModeId { get; set; }
        public string PayTerm { get; set; }
        public double Tenor { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public string LcSource { get; set; }
        public string PortofEntry { get; set; }
        public string PortofLoading { get; set; }
        public string PortofDischarge { get; set; }
        public string ShippingLine { get; set; }
        public double DocPresentDays { get; set; }
        public double BtbLimitPercentage { get; set; }
        public double ForeignComnPercentage { get; set; }
        public double LocalComnPercentage { get; set; }
        public string TransferingBankRef { get; set; }
        public string Transferable { get; set; }
        public string ReplacementLC { get; set; }
        public string TransferingBank { get; set; }
        public string NegotiatingBank { get; set; }
        public string NominatedShipLine { get; set; }
        public string ReImbursingBank { get; set; }
        public string ClaimAdjustment { get; set; }
        public string ExpiryPlace { get; set; }
        public string Reason { get; set; }
        public string BlClause { get; set; }
        public string ReimbursementClauses { get; set; }
        public string DiscountClauses { get; set; }
        public int ExportItemCategory { get; set; }
        public string Remarks { get; set; }
        public string SystemID { get; set; }
        public string ImportBTB { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }
        public string ImportBTBId { get; set; }


        [NotMapped]
        public string BeneficiaryName { get; set; }
    }
}
