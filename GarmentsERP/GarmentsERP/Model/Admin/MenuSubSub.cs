using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Admin
{
    public class MenuSubSub
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentMenuMainId { get; set; }
        public int ParentOrMenuSubId { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool Visibility { get; set; }
        public string UserId { get; set; }
        public int SubSubMenuId { get; set; }
        public bool Save { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Approve { get; set; }

    }
}
