using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SalesForecastEntry
    {
        public int  Id { get; set; }
        public int BuyerId { get; set; }
        public int AgentId { get; set; }
        public int TeamLeaderId { get; set; }
        public string Designation { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }
    }
}
