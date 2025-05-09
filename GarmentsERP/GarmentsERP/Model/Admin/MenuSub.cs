using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Admin
{
    public class MenuSub
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SubMenuId { get; set; }
        public int ParenOrMainMenuId { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool Visibility { get; set; }
        public string UserId { get; set; }
       

        

       


    }
}
