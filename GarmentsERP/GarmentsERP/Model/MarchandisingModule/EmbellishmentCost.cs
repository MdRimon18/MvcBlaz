using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class EmbellishmentCost
    {
        public int Id { get; set; }
        public int PrecostingId { get; set; }
        public string EmbelName { get; set; }
        public int EmbelTypeId { get; set; }
        public string ReportType { get; set; }
        public int BodyPartId { get; set; }
        public int CountryId { get; set; }
        public int SupplierId { get; set; }
        public double Cons { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public string Status { get; set; }
        public bool IsEmbellishmentCostBooking { get; set; }
        [Column(TypeName = "bigint")]
        public int? IndexNo { get; set; }
                  
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string JobName { get; set; }
        [NotMapped]
        public string FileNo { get; set; }
       
        [NotMapped]
        public string InternalRef { get; set; }
        [NotMapped]
        public string UomName { get; set; } 
        [NotMapped]
        public string GmtsItemName { get; set; }
        [NotMapped]
        public string EmbellTypeName { get; set; }   
        [NotMapped]
        public string BodyPartEntry { get; set; }
        [NotMapped]
        public int OrderAutoId { get; set; }
        [NotMapped]
        public string OrderNo { get; set; }
        [NotMapped]
        public int embellishmentCostId { get; set; }
        [NotMapped]
        public int PoDeptId { get; set; }
    }
}
