using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class SampleProductionTeam
    { 
            [Key]
            public int Id {get;set;}
            public string TeamName {get;set;}
            public int Location {get;set;}
            public int NumberofMembers {get;set;}
            public int? TeamEfficiency {get;set;}
            public string Status {get;set;}
        [NotMapped]
            public string LocationName { get;set;}
    }
}
