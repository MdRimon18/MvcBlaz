using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarmentsERP.Model
{
    public partial class InputPannelPodetails
    {
       
        [Key]
        public int Input_Pannel_ID { get; set; }
        public int? Po_details_ID { get; set; }
        public int? CountryID { get; set; }
        public string Country_Type { get; set; }
        public string Cutt_off_Date { get; set; }
        public string Cutt_off { get; set; }
        public string Country_Shipment_date { get; set; }
        public string Remarks { get; set; }
        public int? Packing_ID { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string PackingName { get; set; }
        public int? Uom { get; set; }
        public string EntryDate { get; set; }
        public int? EntryBy { get; set; }






    }
}
