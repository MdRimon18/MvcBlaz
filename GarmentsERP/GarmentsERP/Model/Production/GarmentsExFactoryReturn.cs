using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class GarmentsExFactoryReturn
    {
        public int Id { get; set; }
        public string ReturnNo { get; set; }
        public int Location { get; set; }
        public string DeliveryChallanNo { get; set; }
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
        public string Forwarder { get; set; }
        public string ReturnDate { get; set; }
        public string JobNo { get; set; }
        public string Remarks { get; set; }
        public string OrderNo { get; set; }


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
