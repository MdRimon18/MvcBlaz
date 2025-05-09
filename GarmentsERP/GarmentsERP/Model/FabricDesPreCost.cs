using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GarmentsERP.Model.MarchandisingModule;
namespace GarmentsERP.Model
{
    public partial class FabricDesPreCost
    {

        [Key]
        public int Id { get; set; }
        public string FabNature { get; set; }
        public string Construction { get; set; }
        public double? GsmWeight { get; set; }
        public string ColorRange { get; set; }
        public double? StichLength { get; set; }
        public double? ProcessLoss { get; set; }
        public string Composition { get; set; }
        public string FabricDescriptionDetails { get;  set; }
    }
}
