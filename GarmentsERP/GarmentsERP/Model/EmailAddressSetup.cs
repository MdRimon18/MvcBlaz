using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class EmailAddressSetup
    {
        [Key]
        public int Id {get;set;}
        public string UserType {get;set;}
        public string RecipientName {get;set;}
        public string EmailAddress {get;set;}


    }
}
