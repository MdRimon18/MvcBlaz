using ClosedXML.Excel;
using GarmentsERP.Model;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace GarmentsERP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly GarmentERPContext _context;
        public WeatherForecastController(GarmentERPContext context)
        {
            _context = context;
        }

        [HttpGet]
        //public async Task<IActionResult>Get()
           public async Task<IEnumerable<int>>  Get()
        {
            List<int> numbers = new List<int>();

            // Add sample data to the list
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);
            numbers.Add(50);

            //return _context.BloodGroups.ToList();
            return numbers;
        }


 
          
         
    }
    //
    //public static class ContextExtensions
    //{
    //    public static string GetTableName<T>(this DbContext context) where T : class
    //    {
    //        ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

    //        return objectContext.GetTableName<T>();
    //    }

    //    public static string GetTableName<T>(this ObjectContext context) where T : class
    //    {
    //        string sql = context.CreateObjectSet<T>().ToTraceString();
    //        Regex regex = new Regex(@"FROM\s+(?<table>.+)\s+AS");
    //        Match match = regex.Match(sql);

    //        string table = match.Groups["table"].Value;
    //        return table;
    //    }
    //}
}
