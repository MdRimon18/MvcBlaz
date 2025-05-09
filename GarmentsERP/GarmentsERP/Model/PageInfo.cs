using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class PageInfo
    {
        [Key]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageLink { get; set; }
        public string status { get; set; }
       
    }
}
