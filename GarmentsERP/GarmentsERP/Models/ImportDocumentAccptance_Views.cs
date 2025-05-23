//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarmentsERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImportDocumentAccptance_Views
    {
        public int Id { get; set; }
        public int BtbOrMarginLcMasterId { get; set; }
        public string LCNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public int IssuingBank { get; set; }
        public string InvoiceDate { get; set; }
        public string DocumentValue { get; set; }
        public double LCValue { get; set; }
        public int LCCurrency { get; set; }
        public string ShipmentDate { get; set; }
        public string CompanyAccDate { get; set; }
        public int SupplierId { get; set; }
        public string BankAccDate { get; set; }
        public string BankRef { get; set; }
        public int Importer { get; set; }
        public string AcceptanceTime { get; set; }
        public string RetireSource { get; set; }
        public string PayTerm { get; set; }
        public string EDFTenor { get; set; }
        public string Remarks { get; set; }
        public string LCType { get; set; }
        public double ExchangeRate { get; set; }
        public string Status { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }
        public string BankName { get; set; }
        public string CurrencyName { get; set; }
        public string SupplierName { get; set; }
        public string ImporterName { get; set; }
        public string PiNumbers { get; set; }
        public string ItemCategories { get; set; }
        public Nullable<double> TotalPiValue { get; set; }
        public Nullable<double> TotalCurrAcptncValue { get; set; }
        public Nullable<double> TotalCummulAcptncValue { get; set; }
        public Nullable<double> TotalNetMrrValue { get; set; }
        public Nullable<double> TotalBalance { get; set; }
        public string BLOrCargoNo { get; set; }
        public string BLOrCargoDate { get; set; }
        public Nullable<int> ShipmentMode { get; set; }
        public string DocumentStatus { get; set; }
        public string CopyDocReceiveDate { get; set; }
        public string OriginalDocReceiveDate { get; set; }
        public string DocumenttoCAndF { get; set; }
        public string FeederVessel { get; set; }
        public string MotherVessel { get; set; }
        public string ETADate { get; set; }
        public string ICReceivedDate { get; set; }
        public string ShippingBillNo { get; set; }
        public string Incoterm { get; set; }
        public string IncotermPlace { get; set; }
        public string PortofLoading { get; set; }
        public string PortofDischarge { get; set; }
        public string InternalFileNo { get; set; }
        public string BillOfEntryNo { get; set; }
        public string BillOfEntryDate { get; set; }
        public string PSIReferenceNo { get; set; }
        public string MaturityDate { get; set; }
        public string ContainerNo { get; set; }
        public string PackageQuantity { get; set; }
        public Nullable<int> PackageQuantityUOM { get; set; }
        public string EDFPaidDate { get; set; }
        public string ETDActual { get; set; }
        public string ETAAdvice { get; set; }
        public string ETAActual { get; set; }
        public string ContainerStatus { get; set; }
        public string ContainerSize { get; set; }
        public string ReleaseDate { get; set; }
        public string ClickToAddFile { get; set; }
        public string Shipment_Mode { get; set; }
        public string Packing_Name { get; set; }
    }
}
