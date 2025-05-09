using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    //public partial class TblUserInfo
    //{

    //    [Key]
    //    public int UserID { get; set; }
    //    public string FullName { get; set; }
    //    public string Email { get; set; }
    //    public string Contact { get; set; }
    //    public DateTime? RegDate { get; set; }
    //    public string UserName { get; set; }
    //    public string UserPassword { get; set; }
    //    public int? UserTypeID { get; set; }
    //    public int? DeptId { get; set; }

        
    //}


    public class TblUserInfo
    {
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string RegDate { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserTypeID { get; set; }
        public int DeptId { get; set; }
        public bool IsApproved { get; set; }

        public string Status { get; set; }

        public string EntryDate { get; set; }
       
        public string ApprovedDate { get; set; }


    }
}
