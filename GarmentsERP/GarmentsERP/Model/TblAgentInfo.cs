using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblAgentInfo
    {
        [Key]

        public int AgentID { get; set; }
        public string Agent_Name { get; set; }

      
    }
}
