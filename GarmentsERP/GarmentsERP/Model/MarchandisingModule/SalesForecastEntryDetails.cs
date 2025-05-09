using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SalesForecastEntryDetails
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public int SalesForecastMasterId { get; set; }
        public int CYQntyTarget { get; set; }
        public int CYValueTarget { get; set; }
        public int CYTargetMint { get; set; }
        public int PYQntyTarget { get; set; }
        public int PYValueTarget { get; set; }
        public int PYTargetMint { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }
    }
}
