using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class TNATaskPercent
    {
        [Key]
        public int Id { get; set; }
        public int TaskNameId { get; set; }
        public int BuyerNameId { get; set; }
        public double StartPercent { get; set; }
        public double NoticeBefore { get; set; }
        public double EndPercent { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string TaskName { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        
    }
}
