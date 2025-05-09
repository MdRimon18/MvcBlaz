using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class CurrencyConversionRate
    {
               [Key]
                public int Id {get;set;}
                public int Currency {get;set;}
                public int  ConversionRate {get;set;}
                public int MarketingRate{ get;set;}
                public string Date {get;set;}

    }
}
