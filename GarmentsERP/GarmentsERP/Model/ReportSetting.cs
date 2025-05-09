using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ReportSetting
    {
        [Key]
        public int  Id { get; set; }
     public int CompanyId { get; set; }
     public int ModuleId { get; set; }
     public int ReportId { get; set; }
     public int ReportFormatId { get; set; }
     public string Status { get; set; }
    }
}
