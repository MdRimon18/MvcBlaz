using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class MaterialOrGoodsParking
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public int PartyType { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public string ReceiveFrom { get; set; }
        public string Department { get; set; }
        public string InDate { get; set; }
        public string InTimeStart { get; set; }
        public string InTimeEnd { get; set; }
        public string Section { get; set; }
        public string Attention { get; set; }
        public string Challanno { get; set; }
        public string CarriedBy { get; set; }
        public string PiWoReqReference { get; set; }


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
