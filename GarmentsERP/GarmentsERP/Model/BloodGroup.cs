using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class BloodGroup
    {
        [Key]
        public int Id { get; set; }
        public string BloodGroupName { get; set; }
    }
}
