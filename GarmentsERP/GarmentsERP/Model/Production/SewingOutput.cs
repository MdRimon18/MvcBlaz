using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class SewingOutput
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int SewCompanyId { get; set; }
        public string OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string JobNo { get; set; }
        public string Style { get; set; }
        public int ItemId { get; set; }
        public double OrderQnty { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public string WorkOrder { get; set; }
        public string ProducedBy { get; set; }
        public string SewingDate { get; set; }
        public int SewingLineId { get; set; }
        public int ColorTypeId { get; set; }
        public double ReportingHour { get; set; }
        public string Supervisor { get; set; }
        public double QcPassQty { get; set; }
        public double AlterQty { get; set; }
        public double SpotQty { get; set; }
        public double RejectQty { get; set; }
        public string ChallanNo { get; set; }
        public string ShyChallanNo { get; set; }
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

        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string SewingCompanyName { get; set; }

        [NotMapped]
        public string BuyerName { get; set; }

        [NotMapped]
        public string LocationName { get; set; }

    }
}
