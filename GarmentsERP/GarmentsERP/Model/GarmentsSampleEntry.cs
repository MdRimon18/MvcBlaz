using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class GarmentsSampleEntry
    {
        [Key]

        public int	Id {get;set;}
        public string SampleName {get;set;} 
	    public int  SampleTypeId { get;set;}
	    public string  Status { get;set;}
        [NotMapped]
	    public string SampleTypeName { get;set;}
    }
}
