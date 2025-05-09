using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ProductionFloor
    {
           [Key]
            public int Id {get;set;}
            public int Company {get;set;}
            public int Location {get;set;}
            public int Floor {get;set;}
            public int FloorSequence {get;set;}
            public int ProductionProcessId {get;set;}
            public string Status {get;set;}
            [NotMapped]
            public string CompanyName { get;set;}

            [NotMapped]
            public string LocationName { get;set;} 

            [NotMapped]
            public string ProductionProcessName { get;set;}  
        
            [NotMapped]
            public string FloorName { get;set;}


    }
}
