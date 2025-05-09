using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GarmentsERP.Model.MarchandisingModule;
namespace GarmentsERP.Model
{
    public partial class Suplier
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersionDesignation { get; set; }
        public string SuplierType { get; set; }
        public int? SuplyItemId { get; set; }
        public string Nominated { get; set; }

       
    }
}
