using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ConsumptionEntryFormForTrimsCost
    {
        public int Id { get; set; }
        public int PoNoId { get; set; }
        public int TrimCostId { get; set; }
        public string poName { get; set; }
        public int PrecostingId { get; set; }
        public int GmtsItemId { get; set; }
        public int Country { get; set; }
        public string Countries { get; set; }
        public string GmtsColor { get; set; }
        public string Gmtssizes { get; set; }
        public string ItemSizes { get; set; }
        public double Cons { get; set; }
        public double Ex { get; set; }
        public double TotCons { get; set; }

        public double Rate { get; set; }
        public double Amount { get; set; }
        public double TotalQty { get; set; }

        public double TotalAmount { get; set; }
        public double Placement { get; set; }
        public double Pcs { get; set; }
        public double viewModelTotalQuantity { get; set; }

        public string ItemColor { get; set; }
        public string RefNo { get; set; }
        public decimal? PerAccessories { get; set; }
        public int? TrimsIndexNo { get; set; }
        public string mesurmentDescription { get; set; }
    }
}
