using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using FastReport.Web;
using GarmentsERP.Model;
//using FastReport.Data;
using System.IO;
//using FastReport.Export.PdfSimple;
using System.Net.Http;

//using jsreport.AspNetCore;

//using jsreport.Client;


namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
      // [MiddlewareFilter(typeof(JsReportPipeline))]

       
        [HttpGet("[action]/{buyerID}")]
        public IActionResult ShowReport(string buyerID)
        {
            //HttpContext.JsReportFeature().Recipe(Recipe.PhantomPdf);
          //  WebReport WebReport = new WebReport();
            
          //  var rs = new ReportingService("https://rimon.jsreportonline.net/templates/tRYuxCZ", "rimoncse18@gmail.com", "01722810048rrrr");
          //   var report = rs.RenderByNameAsync("Invoice", new { country = "sweden" });
            //var report = rs.RenderByNameAsync("Invoice");
           // using (var fs = System.IO.File.Create("Out.pdf"))
           // {
             //   report.Result.Content.CopyTo(fs);
               // report.Content.CopyTo(fs);
               
            //}
            var connString = DBConnection.ConnectionString;
            try
            {
                //Calling report with function parameters
                //Reports object initialization
              //  WebReport.Width = "1000";
              //  WebReport.Height = "1000";
              //  WebReport.Reports.Load("App_Data/rptBuyerProfile.frx"); // Load the report into the WebReport object
              //  WebReport.Reports.Dictionary.Connections[0].ConnectionString = connString;

                //Set value to report parameters
              //  WebReport.Reports.SetParameterValue("BuyerId", Convert.ToInt32(buyerID));
              //  WebReport.Reports.Prepare();

               
            }
            catch (Exception ex)
            {
                ViewBag.WebReport = ex.Message;
            }
            //System.Data.DataSet dataSet = new System.Data.DataSet(); // Create a data source
            //dataSet.ReadXml("App_Data/nwind.xml"); // Open the xml database
            //WebReport.Reports.RegisterData(dataSet, "NorthWind"); // Registering the data source in the report
            //WebReport.Mode = WebReportMode.Designer; // Set the web report object mode - designer display
            //WebReport.DesignerLocale = "en";
            //WebReport.DesignerPath = @"Views/Reports/ShowReport.cshtml"; // We set the URL of the online designer
            //WebReport.DesignerSaveCallBack = @"api/Reports/SaveDesignedReport"; // Set the view URL for the report save method
            //WebReport.Debug = true;
          //  ViewBag.WebReport = WebReport; // pass the report to View

    

            return View();
           
        }

        [HttpGet("[action]/{buyerID}")]
        public IActionResult ExportPDF(string buyerID)
        {
        //    WebReport WebReport = new WebReport();
            var connString = DBConnection.ConnectionString;
          
                //Calling report with function parameters
                //Reports object initialization
             //   WebReport.Width = "1000";
              //  WebReport.Height = "1000";
              //  WebReport.Reports.Load("App_Data/rptBuyerProfile.frx"); // Load the report into the WebReport object
             //   WebReport.Reports.Dictionary.Connections[0].ConnectionString = connString;

                //Set value to report parameters
           //     WebReport.Reports.SetParameterValue("BuyerId", Convert.ToInt32(buyerID));
           //     WebReport.Reports.Prepare();

               
                 
                // save file in stream
                Stream stream = new MemoryStream();
             //   WebReport.Reports.Export(new PDFSimpleExport(), stream);
                stream.Position = 0;
            

            return File(stream, "application/zip", "BuyerProfiles.pdf");








        }

        [HttpGet("[action]/{buyerID}")]
        public IActionResult ExportExcle(string buyerID)
        {
          //  WebReport WebReport = new WebReport();
            var connString = DBConnection.ConnectionString;

            //Calling report with function parameters
            //Reports object initialization
            //WebReport.Width = "1000";
            //WebReport.Height = "1000";
           // WebReport.Reports.Load("App_Data/rptBuyerProfile.frx"); // Load the report into the WebReport object
           // WebReport.Reports.Dictionary.Connections[0].ConnectionString = connString;

            //Set value to report parameters
           // WebReport.Reports.SetParameterValue("BuyerId", Convert.ToInt32(buyerID));
           // WebReport.Reports.Prepare();



            // save file in stream
            Stream stream = new MemoryStream();
         //   WebReport.Reports.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;


            return File(stream, "application/zip", "BuyerProfiles.pdf");








        }
    }
}