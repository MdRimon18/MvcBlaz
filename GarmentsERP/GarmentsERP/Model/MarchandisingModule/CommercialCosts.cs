using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class CommercialCosts
    {
        [Key]
            public int Id {get;set;}
            public string Item {get;set;}
            public int PrecostingId { get;set;}
            public double RateIn {get;set;}
            public double Amount {get;set;}
            public string Status {get;set;}
    }
}
