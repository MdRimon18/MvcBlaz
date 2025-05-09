using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsERP.Models.ReportDtos
{
    public class TrimCostDtos
    {
        public int? BuyerProfileId { get; set; }
        public int? YearId { get; set; }
        public int? MonthId { get; set; }
        public int? JobNoId { get; set; }
        public int? PoNoId { get; set; }
        public int? GroupId { get; set; }
        public int? EmbelTypeId { get; set; }
        // public int? FabricSourceId { get; set; }
        public string StyleRef { get; set; }
        public string JobOrPoLevel { get; set; }
        public string JobNoIds { get; set; }
        public string GroupIds { get; set; }
    }
}