using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class CostComponenetsMasterDetails
    {
        // public int Id { get; set; }
        [Key]
        public int Id { get; set; }
        public int CostComponetId { get; set; }
        public int PreCostingId { get; set; }
        
       public string CostComponentName { get; set; }
        public double? BudgetedCost { get; set; }
        public double? QPrice { get; set; }
    }
}
