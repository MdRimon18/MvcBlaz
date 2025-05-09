using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class TermsNConditionSubTable
    {
        [Key]
        public int Id { get; set; }
        public int TermsNConditionId { get; set; }
        public int PageId { get; set; }
        public string PageNames { get; set; }
    }
}
