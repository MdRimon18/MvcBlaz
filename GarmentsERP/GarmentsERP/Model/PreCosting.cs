using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GarmentsERP.Model.MarchandisingModule;
namespace GarmentsERP.Model
{
    public partial class PreCosting
    {
        [Key]
        public int PrecostingId { get; set; }
        public int? OrderId { get; set; }
        public string CostingDate { get; set; }
        public string Incoterm { get; set; }
        public string IncotermPlace { get; set; }
        
        public string PoId { get; set; }
        public int? BuyerId { get; set; }
        public int? QuotationId { get; set; }
        public int? ApprovedId { get; set; }
        public int? currencyId { get; set; }
        public int? jobQty { get; set; }
        public int? companyId { get; set; }
        public int? orderUOMId { get; set; }
        public int? RegionId { get; set; }
        public int? BudgetMinuite { get; set; }

        public double? eR { get; set; }
        public double? CutSMV { get; set; }
        public double? CutEfficiency { get; set; }
        public double? SewSMV { get; set; }
        public double? SewEfficiency { get; set; }



        public string StyleRef { get; set; }
        public string StyleDesc { get; set; }
        public string Remark { get; set; }
        public string agent { get; set; }
        public string machineLine { get; set; }
        public string prodLineHr { get; set; }
        public string ReadyToApproved { get; set; }
        public string imagesPath { get; set; }
        public string Fileno { get; set; }
        public string internalRef { get; set; }
        public string CopyFrom { get; set; }
        public string Unapproverequest { get; set; }

        public string Status { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovalDate { get; set; }
        public int? ApprovalStatus { get; set; }
        public int? ApprovedById { get; set; }

        //public string AgmApprovalDate { get; set; }
        //public bool AgmApproval { get; set; }
        //public string ApprovedByAgmUserId { get; set; }

        //public string GmApprovalDate { get; set; }
        //public bool GmApproval { get; set; }
        //public string ApprovedByGmUserId { get; set; }

        //public string MdApprovalDate { get; set; }
        //public bool MdApproval { get; set; }
        //public string ApprovedByMdUserId { get; set; }

        public double? CostingPer { get; set; }

        [NotMapped]
        public string jobNo { get; set; }
        [NotMapped]
        public int OrderAutoID { get; set; }
        [NotMapped]
        public string PoNames { get; set; }
        [NotMapped]
        public string ApprovedByName { get; set; }
        [NotMapped]
        public string ApprovalStatusName { get; internal set; }
    }

    //public class StatusNames
    //{
    //    public int Id { get; set; }
    //    public string StatusName { get; set; }
    //}
}
