using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ConsumptionEntryForm
    {
        public int Id { get; set; }
        public int PoNoId { get; set; }
        public int PrecostingId { get; set; }
        public int FabricCostId { get; set; }
        public string Color { get; set; }
        public string GmtsSizes { get; set; }
        public string Dia { get; set; }
        public string ItemSizes { get; set; }
        public double FinishCons { get; set; }
        public double ProcessLoss { get; set; }
        public double GreyCons { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double Pcs { get; set; }
        public double TotalQty { get; set; }
        public double TotalAmount { get; set; }
        public double? SizeQuantity { get; set; }
        public double? JobQnty { get; set; }
        [Column(TypeName = "bigint")]
        public int?  FabricIndexNo { get; set; }
        public string Remarks { get; set; }
        public string RefNo { get; set; }

        [NotMapped]
        public string PoName { get; set; }
        
    }
}
