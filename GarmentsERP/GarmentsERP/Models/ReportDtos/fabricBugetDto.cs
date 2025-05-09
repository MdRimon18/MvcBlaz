using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsERP.Models.ReportDtos
{
    public class fabricBugetDto
    {
        public int? BuyerProfileId { get; set; }
        public int? YearId { get; set; }
        public int? MonthId { get; set; }
        public int?JobNoId { get; set; }
        public int? FabricSourceId { get; set; }
        public string StyleRef { get; set; }
        public string JobOrPoLevel { get; set; }
    }
}