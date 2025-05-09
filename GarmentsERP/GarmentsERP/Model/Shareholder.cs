using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class Shareholder
    {
        [Key]
        public int Id { get; set; }
    public string IdNo { get; set; }
    public string Name { get; set; }
    public string BoAccountId { get; set; }
        [NotMapped]
    public string Fatherhusband { get; set; }
    public string MothersName { get; set; }
    public string Profession { get; set; }
    public string Organization { get; set; }
    public string Designation { get; set; }
    public string NationalId { get; set; }
    public string Tin { get; set; }
    public string Vat { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Status { get; set; }

        //for present address
    public string PlotNoPr { get; set; }
    public string LevelNoPr { get; set; }
    public string RoadNoPr { get; set; }
    public string BlockNoPr { get; set; }
    public int CountryIdPr { get; set; }
    public string ProvincePr { get; set; }
    public string CityOrTownPr { get; set; }
    public string ZipCodePr { get; set; }

        //for permanent address
    public string PlotNoPe { get; set; }
    public string LevelNoPe { get; set; }
    public string RoadNoPe { get; set; }
    public string BlockNoPe { get; set; }
    public int CountryIdPe { get; set; }
    public string ProvincePe { get; set; }
    public string CityOrTownPe { get; set; }
    public string ZipCodePe { get; set; }
   
    }
}
