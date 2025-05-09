using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class MailRecipientGroup
    {
        [Key]
        public int Id {get;set;}
        public int CompanyName {get;set;}
        public string MailItem {get;set;}
        public string YouHaveSelected {get;set;}
        public string Status {get;set;}
    }
}
