using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Admin
{
    public class LoginHistory
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string LogDate { get; set; }
        public string LoginTime { get; set; }
        public string LogoutDate { get; set; }
        public string LogoutTime { get; set; }
        public string Duration { get; set; }
        public string LoginStatus { get; set; }


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
