using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class SewingLine
    {
        [Key]
        public int Id {get;set;}
        public int CompanyId {get;set;}
        public int LocationId {get;set;}
        public int FloorId {get;set;}
        public int SewingLineSequence {get;set;}
        public string LineName {get;set;}
        public string SewingGroup {get;set;}
        public string Status {get;set;}
        [NotMapped]
        public string CompanyName { get;set;}
        [NotMapped]
        public string LocationName { get;set;}
        [NotMapped]
        public string FloorName { get;set;}
    }
}
