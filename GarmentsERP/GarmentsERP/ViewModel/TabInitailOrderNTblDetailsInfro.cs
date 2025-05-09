using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GarmentsERP.ViewModel
{
    public class TabInitailOrderNTblDetailsInfro
    {
      
        public string jobNo { get; set; }
        public int Id{ get; set; }
        public string PoNo { get; set; }
        public  string Item { get; set; }
        public string BodyPart { get; set; }
        public string Contruction { get; set; }
        public string Composition { get; set; }
        public string GSM { get; set; }
        public string FabricNature { get; set; }
        public string FabricSource { get; set; }
        public string UOM { get; set; }
        public string Gmts_color { get;  set; }
        public string Items_color { get;  set; }
        public double? woQnty { get;  set; }
        public double? Dia { get;  set; }
        public double? Adj_Qnty { get;  set; }
        public double? Ac_wo_qnty { get;  set; }
        public double? Rate { get;  set; }
        public double? Amount { get;set; }
        public int bookingMasterId { get;set; }

       
    }
}
