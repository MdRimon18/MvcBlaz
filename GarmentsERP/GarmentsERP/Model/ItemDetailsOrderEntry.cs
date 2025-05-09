using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class ItemDetailsOrderEntry
    {
        [Key]
        public int id { get; set; }
        public int? order_entry_id { get; set; }
        public string item { get; set; }
        public double? ratio { get; set; }
        public double? sew_smv_pcs { get; set; }
        public double? cut_smv_pcs { get; set; }
        public double? fin_smv_pcs { get; set; }
        public string complexity { get; set; }
        public string print { get; set; }
        public string embro_yes_no { get; set; }
        public double? embro_number { get; set; }
        public string wash_yes_no { get; set; }
        public double? wash_number { get; set; }
        public string sp_works_yes_no { get; set; }
        public double? sp_works_number { get; set; }
        public string gmts_dyeing_yes_no { get; set; }
        public double? gmts_dyeing_number { get; set; }
        public string aop_yes_no { get; set; }
        public double? aop_number { get; set; }
    }
}
