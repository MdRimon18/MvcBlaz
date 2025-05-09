using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class DiscountMethod
    {
        [Key]
        public int Id { get; set; }
        public string DiscountMethodName { get; set; }
        public string status { get; set; }
    }
}
