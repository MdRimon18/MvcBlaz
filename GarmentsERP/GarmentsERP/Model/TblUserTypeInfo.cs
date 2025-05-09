using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblUserTypeInfo
    {
        [Key]

        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        
    }
}
