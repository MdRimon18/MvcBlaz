using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class AddConsumptionFormForGmtWashCost
    {
        public int Id { get; set; }
        public int PrecostingId { get; set; }
        public int WashCostId { get; set; }
        public int PoId { get; set; }
        public string PoNo { get; set; }
        public int Country { get; set; }
        public string Countries { get; set; }
        public int GmtsItem { get; set; }
        public string GmtsColor { get; set; }
        public string Gmtssizes { get; set; }
        public double Cons { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double? sizeQnty { get; set; }
        public string RefNo { get; set; }
      
        public int? WashIndexNo { get; set; }
    }
}
