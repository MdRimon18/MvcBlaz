using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Admin
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyLocationId { get; set; }
        public string StrId { get; set; }
        public string BuyerIds { get; set; }
        public string SupplierIds { get; set; }
        public string ItemCategoryIds { get; set; }
        public string HomeGraph { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


    }
}
