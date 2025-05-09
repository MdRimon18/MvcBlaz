using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportInvoiceUpdateShippingInformation
    {
        public int Id { get; set; }
        public string BlOrCargoNo { get; set; }
        public string BlOrCargoDate { get; set; }
        public int MasterId { get; set; }
        public string OriginalBLRevDate { get; set; }
        public string DocHandover { get; set; }
        public string CustomForwarderName { get; set; }
        public string Etd { get; set; }
        public string FeederVessel { get; set; }
        public string MotherVessel { get; set; }
        public string EtADate { get; set; }
        public string EtADestination { get; set; }
        public string IcReceivedDate { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public string ShippingBillNo { get; set; }
        public string ShippingBillDate { get; set; }
        public string PortofEntry { get; set; }
        public string PortofLoading { get; set; }
        public double PortofDischarge { get; set; }
        public string InternalFileNo { get; set; }
        public int ShippingMode { get; set; }
        public double FreightAmountBySupplier { get; set; }
        public string ExfactoryDate { get; set; }
        public string ActualShipDate { get; set; }
        public double FreightAmountByBuyer { get; set; }
        public double TotalCartonQnty { get; set; }
        public double NetWeight { get; set; }
        public double GrossWeight { get; set; }
        public string CategoryNo { get; set; }
        public string HsCode { get; set; }
        public string AdviceDate { get; set; }
        public double AdviceAmount { get; set; }
        public double PaidAmount { get; set; }
        public string IncentiveApplicable { get; set; }
        public string GsPNO { get; set; }
        public string GsPDate { get; set; }
        public double YarnConsOrPcs { get; set; }
        public string CoNO { get; set; }
        public string CoDate { get; set; }
        public string ContainerNo { get; set; }


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
