using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class LabTestRateChart
    {
        [Key]
                public int Id  {get;set;}
                public string TestCatagory {get;set;}
                public string TestFor {get;set;}
                public string TestItem {get;set;}
                public double Rate {get;set;}
                public double Upcharge {get;set;}
                public double UpchargeAmout {get;set;}
                public double NetRate {get;set;}
                public int Currency {get;set;}
                public int TestingCompany {get;set;}
                [NotMapped]
                public string CompanyName { get;set;} 
                 [NotMapped]
                public string CurrencyName { get;set;}
    }
}
