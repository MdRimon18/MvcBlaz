using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class YarnCost
    {
 
            public int Id {get;set;}
            public int CountId { get;set;}  
            public int Comp1Id { get;set;}
            public int precostingId { get;set;}
            public double percentage { get;set;}
            public string Color { get;set;}
           // public string BodyColor { get;set;}
            public int TypeId { get;set;}
           public int? FabricCostId { get; set; }
        public float ConsQnty { get;set;}
            public int SupplierId { get;set;}
        public int? FabricDescId { get; set; }
        public int? FabricIndexNo { get; set; }
        public int? Serial { get; set; }
        public int? ColorTypeId { get; set; }
        public int? StripeClrId { get; set; }
        public int? YrnCnsStrpId { get; set; }
        public bool? isLoadFromStripeClr { get; set; }
        public float Rate { get;set;}
         public float Amount { get;set;}
           public bool IsBookingComplete { get; set; }

    }
}
