using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Admin
{
    public class MenuManagement
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ApprovalMenu { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public string RootMenu { get; set; }
        public string RootMenuUnder { get; set; }
        public double Sequence { get; set; }


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
