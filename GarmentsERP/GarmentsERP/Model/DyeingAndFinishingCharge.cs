using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class DyeingAndFinishingCharge
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ConstCompo { get; set; }
        public string ProcessType { get; set; }
        public string ProcessName { get; set; }
        public string Color { get; set; }
        public string WidthDiatype { get; set; }
        public string InHouseRate { get; set; }
        public int UOMId { get; set; }
        public string Ratetype { get; set; }
        public string CustomerRate { get; set; }
        public string SubconBuyer { get; set; }
        public string Status { get; set; }

    }
}
