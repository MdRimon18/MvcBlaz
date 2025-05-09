using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class PolyEntry
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string Style { get; set; }
        public int ItemId { get; set; }
        public double OrderQnty { get; set; }
        public string WorkOrder { get; set; }
        public string Source { get; set; }
        public int PolyCompanyId { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public string ProducedBy { get; set; }
        public string PolyDate { get; set; }
        public string PolyLineNo { get; set; }
        public double ReportingHour { get; set; }
        public string Supervisor { get; set; }
        public double QcPassQty { get; set; }
        public double AlterQty { get; set; }
        public double SpotQty { get; set; }
        public double RejectQty { get; set; }
        public string ChallanNo { get; set; }
        public string SysChln { get; set; }
        public string Remarks { get; set; }


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
