using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class StoreLocation
    {
        [Key]
public int Id {get;set;}
public string StoreName {get;set;}
public int CompanyName {get;set;}
public int Location {get;set;}
public string ItemCategoryId {get;set;}
public string Status {get;set;}
[NotMapped]
public string Company { get;set;}
[NotMapped]
public string LocationName { get;set;}
    }
}
