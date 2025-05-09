using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsERP.Models.ReportDtos
{
    public class ColorNSizeBreakdownReport
    {
       // public int Id { get; set; }
        public int BuyerProfileId { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public string JobNo { get; set; }
        public string PoNo { get; set; }
        public string FileNo { get; set; }
        public string StyleRef { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }


       // public string Status { get; set; }
 


    }
}