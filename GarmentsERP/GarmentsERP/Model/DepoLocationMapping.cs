using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class DepoLocationMapping
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int UltimateCountryId { get; set; }
        public string CountryDepoName { get; set; }
        public string status { get; set; }
        [NotMapped]
        public string CountryName { get; set; } 
        [NotMapped]
        public string UltimateCountryName { get; set; }
    }
}
