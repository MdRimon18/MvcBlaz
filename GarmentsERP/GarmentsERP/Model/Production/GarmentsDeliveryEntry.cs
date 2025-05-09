using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class GarmentsDeliveryEntry
    {
        public int Id { get; set; }
        public string ChallanNo { get; set; }
        public int Location { get; set; }
        public int TransportCompanyId { get; set; }
        public string ExFactoryDate { get; set; }
        public string TruckNo { get; set; }
        public string LockNo { get; set; }
        public string DriverName { get; set; }
        public string DlNo { get; set; }
        public string MobileNum { get; set; }
        public string DoNo { get; set; }
        public string GpNo { get; set; }
        public string FinalDestination { get; set; }
        public string CndFAgent { get; set; }
        public string ForwardingAgent { get; set; }
        public int DeliveryCompanyId { get; set; }
        public int DeliveryLocationId { get; set; }
        public int FloorId { get; set; }
        public string Attention { get; set; }
        public string Remarks { get; set; }
        public string OrderNo { get; set; }
        public string InsQtyValidation { get; set; }
        public double ExFactoryQnty { get; set; }
        public double TotalCartonQnty { get; set; }
        public string InvoiceNo { get; set; }
        public string LcOrsCNo { get; set; }
        public double QntyOrCtn { get; set; }
        public string Remarkss { get; set; }
        public string ShippingStatus { get; set; }
        public string ShippingMode { get; set; }


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
