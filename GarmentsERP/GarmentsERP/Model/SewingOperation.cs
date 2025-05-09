using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class SewingOperation
    {
     [Key]  
public int Id {get;set;}
public string Operation {get;set;}
public int Rate {get;set;}
public int UOMId {get;set;} 
public int ResourceId {get;set;}
public int? OperatorSMV {get;set;}
public int? HelperSMV {get;set;}
public int? TotalSMV {get;set;}
public string Action {get;set;}
        [NotMapped]
public string UOMName { get;set;}
        [NotMapped]
 public string ResourceName { get;set;}

    }
}
