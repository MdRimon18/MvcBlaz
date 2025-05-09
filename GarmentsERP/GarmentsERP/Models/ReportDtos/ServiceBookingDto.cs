using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsERP.Models.ReportDtos
{
    public class ServiceBookingDto
    {
        public int? BuyerId { get; set; }
        public int? JobNoId { get; set; }
        public int? PoNoId { get; set; }
        public string StyleRef { get; set; }
        public int? YearId { get; set; }
        public string MonthName { get; set; }
        public int? ProcessId { get; set; }
        public int? PfbId { get; set; }
        public int? YpoBookingId { get; set; }
        public int? WorkOrderId { get; set; }


    }
}