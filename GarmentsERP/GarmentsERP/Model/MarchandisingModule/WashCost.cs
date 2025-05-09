using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class WashCost
    {
       
        public int Id { get; set;}
        public int PrecostingId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int CountryId { get; set; }
        public double ConsOneDznGmts { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        [Column(TypeName = "bigint")]
        public int? IndexNo { get; set; }
    }
}
