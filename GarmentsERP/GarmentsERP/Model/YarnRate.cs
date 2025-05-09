using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class YarnRate
    {
        [Key]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int YarnCountId { get; set; }
        public int CompositionId { get; set; }
        public double Percentage { get; set; }
        public int Type { get; set; }
        public double RateOrKg { get; set; }
        public string EffectiveDate { get; set; }

        [NotMapped]
        public string SupplierName { get; set; }
        [NotMapped]
        public string TypeName { get; set; }
        [NotMapped]
        public string CompositionName { get; set; }    
        [NotMapped]
        public string YarnCountName { get; set; }

    }
}
