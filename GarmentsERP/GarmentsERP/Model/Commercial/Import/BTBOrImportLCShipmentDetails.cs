using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class BTBOrImportLCShipmentDetails
    {
        public int Id { get; set; }
        public string BLOrCargoNo { get; set; }
        public string BLOrCargoDate { get; set; }
        public int ShipmentMode { get; set; }
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
        public int PackageQuantityUOM { get; set; }
        public string EDFPaidDate { get; set; }
        public string ETDActual { get; set; }
        public string ETAAdvice { get; set; }
        public string ETAActual { get; set; }
        public string ContainerStatus { get; set; }
        public string ContainerSize { get; set; }
        public string ReleaseDate { get; set; }
        public string ClickToAddFile { get; set; }
        public int BTBOrImportLCInvoiceDetailsId { get; set; }


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
