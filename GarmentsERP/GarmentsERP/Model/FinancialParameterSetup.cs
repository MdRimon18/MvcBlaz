using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class FinancialParameterSetup
    {
        [Key]
        public int   Id {get;set;}
        public int  CompanyId { get;set;}
        public string  ApplyingPeriod { get;set;}
        public string To { get;set;}
        public double BEPCM { get;set;}
        public double AskingCM { get;set;}
        public double AskingProfit {get;set;}
        public double NoOfFactoryMachine {get;set;}
        public double MonthlyCMExpense {get;set;}
        public double WorkingHour {get;set;}
        public double CostPerMinute {get;set;}
        public double ActualCM {get;set;}
        public double AskingAVGRate {get;set;}
        public string Status {get;set;}
        public double MaxProfi {get;set;}
        public double DepreciationAndAmortization {get;set;}
        public double InterestExpenses {get;set;}
        public double IncomeTax {get;set;}
        public double OperatingExpenses {get;set;}
        [NotMapped]
        public string CompanyName { get;set;}
    }
}
