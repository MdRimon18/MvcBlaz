using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class TermsNCondition
    {
        [Key]
        public int Id { get; set; }
        public string TermsnCondition { get; set; }
        public string MoreTermsNCondition { get; set; }
        public string status { get; set; }
    }
}
