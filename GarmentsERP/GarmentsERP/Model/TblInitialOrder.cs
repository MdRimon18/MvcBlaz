using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace GarmentsERP.Model
{
    public partial class TblInitialOrder
    {
        [Key]
        public int OrderAutoID { get; set; }
        public string JobNo { get; set; }
        public int CompanyID { get; set; }
        public int? LocationID { get; set; }
        public int? BuyerID { get; set; }
        public string Style_Ref { get; set; }
        public string Style_Description { get; set; }
        public int? Prod_DeptID { get; set; }
        public int? Sub_DeptID { get; set; }
        public int? CurrencyID { get; set; }
        public int? RegionID { get; set; }
        public int? Product_CatID { get; set; }
        public int? Team_Leader_ID { get; set; }
        public int? Dealing_Merchant_ID { get; set; }
        public string BH_Merchant { get; set; }
        public string Remarks { get; set; }
        public int? Shipment_Mode_ID { get; set; }
        public int Order_Uom_ID { get; set; }
        public double SMV { get; set; }
        public int? Packing_ID { get; set; }
        public int? Season_ID { get; set; }
        public int? Agent_ID { get; set; }
        public int UserID { get; set; }
        public string Repeat_No_Job { get; set; }
        public string Order_Number { get; set; }
        public string OrderImagePath { get; set; }
        public int? factory_merchant { get; set; }
        public double? JobQuantity { get; set; }
        public double? AvgUnitPrice { get; set; }
        public double? TotalPrice { get; set; }

        public string Status { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
       

        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string ProdDeptName { get; set; }
        [NotMapped]
        public string ProdCatName { get; set; }
        [NotMapped]
        public string TeamLeaderName { get; set; }
        [NotMapped]
        public string DealingMerchandName { get; set; }
        [NotMapped]
        public string OrderUomName { get; set; }

        [NotMapped]
        public string PackingName { get; set; }
    }
}
