using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class BTBORMarginLC
    {
        public int Id { get; set; }
        public string PiMasterId { get; set; }
        public string SystemID { get; set; }
        public int Importer { get; set; }
        public string ApplicationDate { get; set; }
        public int IssuingBank { get; set; }
        public int ItemCategory { get; set; }
        public string LCBasis { get; set; }
        public string ProFormaInvoice { get; set; }
        public double PIValue { get; set; }
        public int Supplier { get; set; }
        public string LCType { get; set; }
        public string LCNumberBankPart { get; set; }
        public string LCNumberYearPart { get; set; }
        public string LCNumberCatPart { get; set; }
        public string LCNumberSerialPart { get; set; }
        public string LCDate { get; set; }
        public string LastShipmentDate { get; set; }
    public string LCExpiryDate { get; set; }
    public double LCValue { get; set; }
    public string IncoTerm { get; set; }
    public string IncoTermPlace { get; set; }
    public string PayTerm { get; set; }
    public double Tenor { get; set; }
    public double TolerancePercentage { get; set; }
    public int DeliveryMode { get; set; }
    public string DocPresentDays { get; set; }
    public string PortofLoading { get; set; }
    public string PortofDischarge { get; set; }
    public string ETDDate { get; set; }
    public string LCANo { get; set; }
    public string LCAFNo { get; set; }
    public string IMPFormNo { get; set; }
    public string InsuranceCompany { get; set; }
    public string CoverNoteNo { get; set; }
    public string CoverNoteDate { get; set; }
    public string PSICompany { get; set; }
    public string MaturityFrom { get; set; }
    public double MarginDepositPercentage { get; set; }
    public int Origin { get; set; }
    public string ShippingMark { get; set; }
    public string GarmentsQntyAndUOM { get; set; }
    public string UDNo { get; set; }
    public string UDDate { get; set; }
    public string CreditToBeAdvised { get; set; }
    public string PartialShipment { get; set; }
    public string Transhipment { get; set; }
    public string AddConfirmationReq { get; set; }
    public string AddConfirmingBank { get; set; }
    public string BondedWarehouse { get; set; }
    public string Status { get; set; }
    public double UPASRatePercentage { get; set; }
    public string Remarks { get; set; }
    public int PivalueCurrency { get; set; }
    public int LCValueCurrency { get; set; }
    public double GarmentsQntyUOMValue { get; set; }
    public decimal? UdCost { get; set; }
    public decimal? LcAdviceCost { get; set; }


    public string StatusCheck { get; set; }

    public string EntryDate { get; set; }
    public string EntryBy { get; set; }

    public string ApprovedDate { get; set; }
    public string ApprovedBy { get; set; }
    public bool IsApproved { get; set; }

    public string ModifyiedDate { get; set; }
    public bool IsModifyied { get; set; }
    public string ModifyiedBy { get; set; }
    public string LcOrSc { get; set; }
    public string LcOrScIds { get; set; }
    public string LcOrScNumbers { get; set; }


        
        //[NotMapped]
        //public string SupplierName { get; set; } 
        //[NotMapped]
        //public string ImporterName { get; set; }
        //[NotMapped]
        //public string ItemCatName { get; set; }
        //[NotMapped]
        //public bool IsSelected { get; set; }


    }
}
