//using GarmentsERP.Models;
//using GarmentsERP.Models.ReportDtos;
 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace GarmentsERP.Controllers.Garments.Commercial.ViewsNspController
//{
//    [RoutePrefix("api/CommercialSpNViews")]
//    public class CommercialSpNViewsController : ApiController
//    {
        
//        private GarmentsERPEntities db = new GarmentsERPEntities();
//        TextileERPEntities TextileErp = new TextileERPEntities();
//        [Route("btbMarginLc")]
//        // api/CommercialSpNViews/btbMarginLc
//        public IEnumerable<View_BtbMarginLc> btbMarginLc()
//        {
//            try
//            {
//                return db.View_BtbMarginLc;
//            }
//            catch (Exception e)
//            {

//                throw;
//            }
            
//        }

//        [HttpGet]
//        [Route("GetYarnPurchaseOrderDetails/{id}")]
//        //api/CommercialSpNViews/GetYarnPurchaseOrderDetails/1
//        public IEnumerable<GetYarnPurchaseOrderDetails_Result> GetYarnPurchaseOrderDetails(int id)
//        {
//            var result = db.GetYarnPurchaseOrderDetails(id);
//            return result;
//        }
//        [HttpGet]
//        [Route("PiInfoGetByBtbId/{id}")]
//        //api/CommercialSpNViews/PiInfoGetByBtbId/1
//        public IEnumerable<PiInfoGetByBtbId_Result> PiInfoGetByBtbId(int id)
//        {
//            var result = db.PiInfoGetByBtbId(id);
//            return result;
//        }

//        [HttpGet]
//        [Route("CommercialJobSelectionView")]
//        //api/CommercialSpNViews/CommercialJobSelectionView
//        public IEnumerable<CommercialJobSelectionView> CommercialJobSelectionView()
//        {
//            var result = db.CommercialJobSelectionViews;
//            return result;
//        }
//        [HttpGet]
//        [Route("ExportInvoiceByLcBudget/{id}")]
//        //api/CommercialSpNViews/ExportInvoiceByLcBudget/1
//        public IEnumerable<ExportInvoiceByLcBudget_Result> ExportInvoiceByLcBudget(int id)
//        {
//            var result = db.ExportInvoiceByLcBudget(id);
//            return result;
//        }
//        [HttpGet]
//        [Route("ExportInvoiceByScBudget/{id}")]
//        //api/CommercialSpNViews/ExportInvoiceByScBudget/1
//        public IEnumerable<ExportInvoiceByScBudget_Result> ExportInvoiceByScBudget(int id)
//        {
//            var result = db.ExportInvoiceByScBudget(id);
//            return result;
//        }

//        [HttpGet]
//        [Route("processInvcForbillingById/{invoiceId}")]
//        //api/CommercialSpNViews/processInvcForbillingById/1
//        public IEnumerable<processInvcForbillingById_Result> processInvcForbillingById(int invoiceId)
//        {
//            var result = db.processInvcForbillingById(invoiceId);
//            return result;
//        }
//        [HttpGet]
//        [Route("ProcessDocSubmissiontoBank")]
//        //api/CommercialSpNViews/ProcessDocSubmissiontoBank
//        public IEnumerable<ProcessDocSubmissiontoBank_Result> ProcessDocSubmissiontoBank()
//        {
//            var result = db.ProcessDocSubmissiontoBank();
//            return result;
//        }
//        [HttpGet]
//        [Route("bankLoanDisplay")]
//        //api/CommercialSpNViews/bankLoanDisplay
//        public IEnumerable<View_BankLoan> bankLoanDisplay()
//        {
//            var result = db.View_BankLoan;
//            return result;
//        }
//        [HttpGet]
//        [Route("ImportDocumentAccptance_Views")]
//        //api/CommercialSpNViews/ImportDocumentAccptance_Views
//        public IEnumerable<ImportDocumentAccptance_Views> ImportDocumentAccptance_Views()
//        {
//            var result = db.ImportDocumentAccptance_Views;
//            return result;
//        }
        
        
//        [HttpGet]
//        [Route("FcbrStatementBalanceFileWise/{id}")]
//        //[Route("CommercialSpNViews/FcbrStatementBalanceFileWise/1
//        public IEnumerable<FcbrStatementBalanceFileWise_Result> FcbrStatementBalanceFileWise(int id)
//        {
//            var result = db.FcbrStatementBalanceFileWise(id, "");
//            return result;
//        }
//        [HttpGet]
//        [Route("BankOrBilRefWithRealization")]
//        //[Route("CommercialSpNViews/BankOrBilRefWithRealization")]
//        public IEnumerable<BankOrBilRefWithRealization_Result> BankOrBilRefWithRealization()
//        {
//            var result = db.BankOrBilRefWithRealization();
//            return result;
//        }
//        [HttpGet]
//        [Route("ImportFileNumbers")]
//        //[Route("CommercialSpNViews/ImportFileNumbers")]
//        public IEnumerable<ImportFileNumbers_Result> ImportFileNumbers()
//        {
//            var result = db.ImportFileNumbers();
//            return result;
//        }
//        [HttpGet]
//        [Route("ExportFileNumbers")]
//        //[Route("CommercialSpNViews/ExportFileNumbers")]
//        public IEnumerable<ExportFileNumbers_Result> ExportFileNumbers()
//        {
//            var result = db.ExportFileNumbers();
//            return result;
//        }
       
//        [HttpGet]
//        [Route("PiTrimsMaster_view")]
//        //[Route("CommercialSpNViews/PiTrimsMaster_view")]
//        public IEnumerable<PiTrimsMaster_view> PiTrimsMaster_view()
//        {
//            var result = db.PiTrimsMaster_view;
//            return result;
//        }
//        [HttpGet]
//        [Route("PiEbellishmentMaster_view")]
//        //[Route("CommercialSpNViews/PiEbellishmentMaster_view")]
//        public IEnumerable<PiEbellishmentMaster_view> PiEbellishmentMaster_view()
//        {
//            var result = db.PiEbellishmentMaster_view;
//            return result;
//        }
//        [HttpGet]
//        [Route("PiYarnMaster_view")]
//        //[Route("CommercialSpNViews/PiYarnMaster_view")]
//        public IEnumerable<PiYarnMaster_view> PiYarnMaster_view()
//        {
//            var result = db.PiYarnMaster_view;
//            return result;
//        }
//        [HttpGet]
//        [Route("ProformaModal_view")]
//        //[Route("CommercialSpNViews/PiYarnMaster_view")]
//        public IEnumerable<ProformaModal_view> ProformaModal_view()
//        {
//            var result = db.ProformaModal_view;
//            return result;
//        }
//        [HttpGet]
//        [Route("ExportFileNumbersV2")]
//        //[Route("CommercialSpNViews/ExportFileNumbersV2 ")]
//        public IEnumerable<ExportFileNumbersV2_Result> ExportFileNumbersV2()
//        {
//            var result = db.ExportFileNumbersV2();
//            return result;
//        }
//        [HttpGet]
//        [Route("View_PaymentBankLoan/{id}")]
//        //api/CommercialSpNViews/View_PaymentBankLoan
//        public IEnumerable<View_PaymentBankLoan> View_PaymentBankLoan(int id)
//        {
//            List<View_PaymentBankLoan> paymentBankLoanById =  db.View_PaymentBankLoan.Where(w => w.LdNoId ==id).ToList();
//            var result = paymentBankLoanById;
//            return result;
//        }

//        [HttpGet]
//        [Route("GetFileNumbersUnique")]
//        //[Route("CommercialSpNViews/GetFileNumbersUnique")]
//        public IEnumerable<GetFileNumbersUnique_Result> GetFileNumbersUnique()
//        {
//            var result = db.GetFileNumbersUnique();
//            return result;
//        }

//        [HttpGet]
//        [Route("GetBuyerNameUnique")]
//        //[Route("CommercialSpNViews/GetBuyerNameUnique")]
//        public IEnumerable<GetBuyerNameUnique_Result> GetBuyerNameUnique()
//        {
//            var result = TextileErp.GetBuyerNameUnique();
//            return result;
//        }
//        [HttpGet]
//        [Route("GetSupplierNameUnique")]
//        //[Route("CommercialSpNViews/GetBuyerNameUnique")]
//        public IEnumerable<GetSupplierNameUnique_Result> GetSupplierNameUnique()
//        {
//            var result = TextileErp.GetSupplierNameUnique();
//            return result;
//        }

//        [HttpPost]
//        [Route("FileJobsNumbers")]
//        //[Route("CommercialSpNViews/FileJobsNumbers/")]
//        public IEnumerable<FileJobsNumbers_Result> FileJobsNumbers(FileNoDto fileNumbers)
//        {
//            var result = db.FileJobsNumbers(fileNumbers.FileNo);
//            return result;
//        }

//        [HttpPost]
//        [Route("FileActivitesNdHistoryGet")]
//        //[Route("CommercialSpNViews/FileActivitesNdHistoryGet")]
//        public IEnumerable<FileActivitesNdHistoryGet_Result> FileActivitesNdHistoryGet(FileActivitesNdHistoryDto fileNumbers)
//        {
//            var result = db.FileActivitesNdHistoryGet(fileNumbers.FileNo,fileNumbers.FileNumbers);
//            return result;
//        }

//        [HttpGet]
//        [Route("View_BuyerProfile")]
//        // api/CommercialSpNViews/View_BuyerProfile
//        public IEnumerable<View_BuyerProfile> View_BuyerProfile()
//        {
//            try
//            {
//                return db.View_BuyerProfile;
//            }
//            catch (Exception e)
//            {

//                throw;
//            }

//        }
//        [HttpGet]
//        [Route("View_SupplierProfiles")]
//        // api/CommercialSpNViews/View_SupplierProfiles
//        public IEnumerable<View_SupplierProfiles> View_SupplierProfiles()
//        {
//            try
//            {
//                return db.View_SupplierProfiles;
//            }
//            catch (Exception e)
//            {

//                throw;
//            }

//        }

//        [HttpPost]
//        [Route("FileActivitesNdHistoryGetByParticular")]
//        // api/CommercialSpNViews/FileActivitesNdHistoryGetByParticular
//        public IEnumerable<FileActivitesNdHistoryGetByParticular_Result> FileActivitesNdHistoryGetByParticular(FileNoDto fileNo)
//        {
//            var result = db.FileActivitesNdHistoryGetByParticular(fileNo.FileNo, fileNo.Particular,fileNo.ParticularId);
//            return result;
//        }

//        [HttpGet]
//        [Route("view_exportLCEntries_list")]
//        // api/CommercialSpNViews/view_exportLCEntries_list
//        public IEnumerable<view_exportLCEntries_list> view_exportLCEntries_list()
//        {
//            try
//            {
//                return db.view_exportLCEntries_list;
//            }
//            catch (Exception e)
//            {

//                throw;
//            }

//        }
//        [HttpGet]
//        [Route("view_salesContractEntry_list")]
//        // api/CommercialSpNViews/view_salesContractEntry_list
//        //public IEnumerable<view_salesContractEntry_list> view_salesContractEntry_list()
//        //{
//        //    try
//        //    {
//        //        return db.view_salesContractEntry_list;
//        //    }
//        //    catch (Exception e)
//        //    {

//        //        throw;
//        //    }

//        //}
//        //[HttpGet]
//        //[Route("view_exportInvoice_list")]
//        //// api/CommercialSpNViews/view_exportInvoice_list
//        //public IEnumerable<view_exportInvoice_list> view_exportInvoice_list()
//        //{
//        //    try
//        //    {
//        //        return db.view_exportInvoice_list;
//        //    }
//        //    catch (Exception e)
//        //    {

//        //        throw;
//        //    }

//        //}
//        [HttpGet]
//        [Route("view_doc_Submission_To_Buyers_list")]
//        // api/CommercialSpNViews/view_doc_Submission_To_Buyers_list
//        //public IEnumerable<view_doc_Submission_To_Buyers_list> view_doc_Submission_To_Buyers_list()
//        //{
//        //    try
//        //    {
//        //        return db.view_doc_Submission_To_Buyers_list;
//        //    }
//        //    catch (Exception e)
//        //    {

//        //        throw;
//        //    }

//        //}
//        //[HttpGet]
//        //[Route("view_export_Proceeds_Realizations_list")]
//        //// api/CommercialSpNViews/view_export_Proceeds_Realizations_list
//        //public IEnumerable<view_export_Proceeds_Realizations_list> view_export_Proceeds_Realizations_list()
//        //{
//        //    try
//        //    {
//        //        return db.view_export_Proceeds_Realizations_list;
//        //    }
//        //    catch (Exception e)
//        //    {

//        //        throw;
//        //    }

//        //}
//    }
          
//}
