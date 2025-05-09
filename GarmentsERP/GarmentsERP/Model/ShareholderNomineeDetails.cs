using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ShareholderNomineeDetails
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public double Ratio { get; set; }
        public double Amount { get; set; }
        public int ShareholderId { get; set; }
    }
}
