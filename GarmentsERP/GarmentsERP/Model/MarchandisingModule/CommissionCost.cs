using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class CommissionCost
    {
        public int Id { get; set; }
        public int PrecostingId { get; set; }
        public string Particulars { get; set; }
        public string CommnBase { get; set; }
        public double CommnRate { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
    }
}
