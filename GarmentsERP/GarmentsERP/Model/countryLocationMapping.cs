using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class countryLocationMapping
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string UltimateCountryName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
    }
}
