using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class YarnCountDeterminationChild
    {
        [Key]
        public int Id { get; set; }
        public int CompositionId { get; set; }
        public double Percentage { get; set; }
        public int YarnCountId { get; set; }
        public string Type { get; set; }
        public int YarnCountDeterminationMasterId { get; set; }
        [NotMapped]
        public string CompositionName { get; set; }
    }
}
