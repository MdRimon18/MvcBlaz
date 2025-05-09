using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class Months
    {
        [Key]
        public int Id { get; set; }
        public string MonthName { get; set; }
        public int MonthNumber { get; set; }
        public string status { get; set; }
    }
}
