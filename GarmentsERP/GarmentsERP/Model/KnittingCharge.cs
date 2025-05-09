using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class KnittingCharge
    {
        [Key]
        public int Id { get; set; }
        public int  CompanyName {get;set;}
        public int  BodyPartId {get;set;}
        public string  ConstructionComposition {get;set;}
        public string  GSM {get;set;}
        public string  Gauge {get;set;}
        public string  YarnDescription {get;set;}
        public int  InHouseRate {get;set;}
        public string  CustomerRate {get;set;}
        public string SubconBuyer {get;set;}
        public int  UOMId {get;set;}
        public string  Status { get; set; }

    }
}

  
   
    
    
   

    
  