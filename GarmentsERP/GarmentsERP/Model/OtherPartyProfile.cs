using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class OtherPartyProfile
    { 
        [Key]
        public int     Id {get;set;}
        public string  OtherPartyName {get;set;}
        public string  ShortName {get;set;}
        public string  Address	{get;set;}
        public string  ContactPerson {get;set;}
        public int     CountryNameId { get; set; }
        public string  Designation {get;set;}
        public string  Remark {get;set;}
        public string  ContactNo {get;set;}
        public string  Status {get;set;}
        public string  Email {get;set;}
        public string  URLName {get;set;}
        public string  ImageName {get;set;}
        public string  ImagePathName { get; set; }
    }
}
