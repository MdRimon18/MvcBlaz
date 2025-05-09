using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class BodyPartEntry
    {
        [Key]
        public int Id { get; set; }
        public string BodyPartFullName { get; set; }
        public string BodyPartShortName { get; set; }
        public string EntryPages { get; set; }
        public string BodyPartType { get; set; }
        public string status { get; set; }
    }
}
