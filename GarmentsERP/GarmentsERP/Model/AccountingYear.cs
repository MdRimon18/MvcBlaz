using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class AccountingYear
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int StartingYear { get; set; }
        public int CurrentYear { get; set; }
        public string StartingMonth { get; set; }
        public string EndingMonth { get; set; }
        public string PeriodName { get; set; }
        public string IsActive { get; set; }
    }
}
