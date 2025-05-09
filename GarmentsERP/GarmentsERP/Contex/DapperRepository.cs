using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GarmentsERP.Models;


namespace GarmentsERP.Repositories
{
    public class DapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        // CartoonConsumption CRUD Operations
        public async Task<IEnumerable<CartoonConsumption>> GetCartoonConsumptions()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CartoonConsumption>("SELECT * FROM CartoonConsumptions");
        }

        public async Task<CartoonConsumption> GetCartoonConsumption(int id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<CartoonConsumption>(
                "SELECT * FROM CartoonConsumptions WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> AddCartoonConsumption(CartoonConsumption cartoonConsumption)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            // Add other properties as parameters
            foreach (var prop in typeof(CartoonConsumption).GetProperties().Where(p => p.Name != "Id"))
            {
                parameters.Add($"@{prop.Name}", prop.GetValue(cartoonConsumption));
            }

            await connection.ExecuteAsync(
                "INSERT INTO CartoonConsumptions (" + string.Join(", ", typeof(CartoonConsumption).GetProperties().Where(p => p.Name != "Id").Select(p => p.Name)) + ") " +
                "VALUES (" + string.Join(", ", typeof(CartoonConsumption).GetProperties().Where(p => p.Name != "Id").Select(p => $"@{p.Name}")) + "); " +
                "SELECT @Id = SCOPE_IDENTITY();",
                parameters);

            return parameters.Get<int>("@Id");
        }

        public async Task UpdateCartoonConsumption(CartoonConsumption cartoonConsumption)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", cartoonConsumption.Id);
            // Add other properties as parameters
            foreach (var prop in typeof(CartoonConsumption).GetProperties().Where(p => p.Name != "Id"))
            {
                parameters.Add($"@{prop.Name}", prop.GetValue(cartoonConsumption));
            }

            await connection.ExecuteAsync(
                "UPDATE CartoonConsumptions SET " + string.Join(", ", typeof(CartoonConsumption).GetProperties().Where(p => p.Name != "Id").Select(p => $"{p.Name} = @{p.Name}")) +
                " WHERE Id = @Id",
                parameters);
        }

        public async Task DeleteCartoonConsumption(int id)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync("DELETE FROM CartoonConsumptions WHERE Id = @Id", new { Id = id });
        }

        public async Task<bool> CartoonConsumptionExists(int id)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<bool>(
                "SELECT COUNT(1) FROM CartoonConsumptions WHERE Id = @Id", new { Id = id });
        }

        // Stored Procedure Methods
        public async Task<IEnumerable<BnkRefExportInvoiceLcOrScConectivity_Result>> BnkRefExportInvoiceLcOrScConectivity()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BnkRefExportInvoiceLcOrScConectivity_Result>(
                "BnkRefExportInvoiceLcOrScConectivity", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BtbLcAndFileConnectivity_Result>> BtbLcAndFileConnectivity()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BtbLcAndFileConnectivity_Result>(
                "BtbLcAndFileConnectivity", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ColorWiseQuantityByOrderId_Result>> ColorWiseQuantityByOrderId(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ColorWiseQuantityByOrderId_Result>(
                "ColorWiseQuantityByOrderId",
                new { OrderId = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CommissionCostPivotTblV2_Result>> CommissionCostPivotTblV2()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CommissionCostPivotTblV2_Result>(
                "CommissionCostPivotTblV2", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CommrclCostPivotTbl_Result>> CommrclCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CommrclCostPivotTbl_Result>(
                "CommrclCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CommrclCostPivotTblv2_Result>> CommrclCostPivotTblv2()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CommrclCostPivotTblv2_Result>(
                "CommrclCostPivotTblv2", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ConversionCostPivotTbl_Result>> ConversionCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ConversionCostPivotTbl_Result>(
                "ConversionCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CostComponentHorizontalResult_Result>> CostComponentHorizontalResult()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CostComponentHorizontalResult_Result>(
                "CostComponentHorizontalResult", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CountComposition_Result>> CountComposition()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CountComposition_Result>(
                "CountComposition", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CountriesInStringByPoId_Result>> CountriesInStringByPoId()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CountriesInStringByPoId_Result>(
                "CountriesInStringByPoId", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmbelConsumtionTotalNAvgCaluculation_Result>> EmbelConsumtionTotalNAvgCaluculation()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<EmbelConsumtionTotalNAvgCaluculation_Result>(
                "EmbelConsumtionTotalNAvgCaluculation", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmbelCostPivotTbl_Result>> EmbelCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<EmbelCostPivotTbl_Result>(
                "EmbelCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricBookingAllJobQntyByBkngId_Result>> FabricBookingAllJobQntyByBkngId()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricBookingAllJobQntyByBkngId_Result>(
                "FabricBookingAllJobQntyByBkngId", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricConsumtionTotalNAvgCaluculation_Result>> FabricConsumtionTotalNAvgCaluculation()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricConsumtionTotalNAvgCaluculation_Result>(
                "FabricConsumtionTotalNAvgCaluculation", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricCostPivotTbl_Result>> FabricCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricCostPivotTbl_Result>(
                "FabricCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricWiseCnspmtnBudget_Result>> FabricWiseCnspmtnBudget()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricWiseCnspmtnBudget_Result>(
                "FabricWiseCnspmtnBudget", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<getEmbelBookingQnty_Result>> GetEmbelBookingQnty(string bookingNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<getEmbelBookingQnty_Result>(
                "getEmbelBookingQnty",
                new { BookingNo = bookingNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEmbelCostTotalQtyByEmbelCostNPoId_Result>> GetEmbelCostTotalQtyByEmbelCostNPoId()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetEmbelCostTotalQtyByEmbelCostNPoId_Result>(
                "GetEmbelCostTotalQtyByEmbelCostNPoId", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<getEmbelTotalBookingQnty_Result>> GetEmbelTotalBookingQnty()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<getEmbelTotalBookingQnty_Result>(
                "getEmbelTotalBookingQnty", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<getEmblBookingQnty_Result>> GetEmblBookingQnty(int? bookingNoId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<getEmblBookingQnty_Result>(
                "getEmblBookingQnty",
                new { BookingNoId = bookingNoId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricPurchaseCostByPrecostingId_Result>> GetFabricPurchaseCostByPrecostingId()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricPurchaseCostByPrecostingId_Result>(
                "GetFabricPurchaseCostByPrecostingId", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetItemNameInStringByOrderId_Result>> GetItemNameInStringByOrderId(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetItemNameInStringByOrderId_Result>(
                "GetItemNameInStringByOrderId",
                new { orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetItemNColorNSizeByPoId_Result>> GetItemNColorNSizeByPoId()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetItemNColorNSizeByPoId_Result>(
                "GetItemNColorNSizeByPoId", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetOrg_Shipment_DateInStringByOrderId_Result>> GetOrg_Shipment_DateInStringByOrderId(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetOrg_Shipment_DateInStringByOrderId_Result>(
                "GetOrg_Shipment_DateInStringByOrderId",
                new { orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetPoNoNameInStringByOrderId_Result>> GetPoNoNameInStringByOrderId(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetPoNoNameInStringByOrderId_Result>(
                "GetPoNoNameInStringByOrderId",
                new { orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTrimCostTotalQtyByTrimCostNPoId_Result>> GetTrimCostTotalQtyByTrimCostNPoId()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetTrimCostTotalQtyByTrimCostNPoId_Result>(
                "GetTrimCostTotalQtyByTrimCostNPoId", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<getTrimsBookingQnty_Result>> GetTrimsBookingQnty(int? bookingNoId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<getTrimsBookingQnty_Result>(
                "getTrimsBookingQnty",
                new { BookingNoId = bookingNoId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InitialConsumtionFunction_Result>> InitialConsumtionFunction()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<InitialConsumtionFunction_Result>(
                "InitialConsumtionFunction", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PiAndWorkOrderConnectivityFunction_Result>> PiAndWorkOrderConnectivityFunction()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<PiAndWorkOrderConnectivityFunction_Result>(
                "PiAndWorkOrderConnectivityFunction", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProcessCostComponentDetails_Result>> ProcessCostComponentDetails(int? precostingKey)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ProcessCostComponentDetails_Result>(
                "ProcessCostComponentDetails",
                new { PrecostingKey = precostingKey },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProcessDocSubmissiontoBank_Result>> ProcessDocSubmissiontoBank()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ProcessDocSubmissiontoBank_Result>(
                "ProcessDocSubmissiontoBank", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProcessEmbelCostForBkng_Result>> ProcessEmbelCostForBkng(int? jobNoId, int? buyerId, int? yearId, int? embelTypeId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ProcessEmbelCostForBkng_Result>(
                "ProcessEmbelCostForBkng",
                new { JobNoId = jobNoId, BuyerId = buyerId, YearId = yearId, EmbelTypeId = embelTypeId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProcessInvoiceInfo_Result>> ProcessInvoiceInfo()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ProcessInvoiceInfo_Result>(
                "ProcessInvoiceInfo", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProcessTrimsCostForBkng_Result>> ProcessTrimsCostForBkng(string jobNoIds)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ProcessTrimsCostForBkng_Result>(
                "ProcessTrimsCostForBkng",
                new { JobNoIds = jobNoIds },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<IEnumerable<ProcessYarnInfoByPrecostingIdAfterBkng_Result>> ProcessYarnInfoByPrecostingIdAfterBkng(int? orderId, int? precostingId, int? pfbMasterId)
        //{
        //    using var connection = CreateConnection();
        //    return await connection.QueryAsync<ProcessYarnInfoByPrecostingIdAfterBkng_Result>(
        //        "ProcessYarnInfoByPrecostingIdAfterBkng",
        //        new { OrderId = orderId, PrecostingId = precostingId, PfbMasterId = pfbMasterId },
        //        commandType: CommandType.StoredProcedure);
        //}
        public async Task<IEnumerable<ProcessYarnInfoByPrecostingIdAfterBkng_Result>> ProcessYarnInfoByPrecostingIdAfterBkng(int? orderId, int? precostingId, int? pfbMasterId)
{
    using var connection = CreateConnection();

    var sql = "SELECT * FROM dbo.ProcessYarnInfoByPrecostingIdAfterBkng(@OrderId, @PrecostingId, @PfbMasterId)";
    
    return await connection.QueryAsync<ProcessYarnInfoByPrecostingIdAfterBkng_Result>(
        sql,
        new { OrderId = orderId, PrecostingId = precostingId, PfbMasterId = pfbMasterId },
        commandType: CommandType.Text);
}

        public async Task<IEnumerable<ProcessYarnInfoByPrecostingIdAfterBkngWithFabric_Result>> ProcessYarnInfoByPrecostingIdAfterBkngWithFabric(int? orderId, int? precostingId, int? pfbMasterId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ProcessYarnInfoByPrecostingIdAfterBkngWithFabric_Result>(
                "ProcessYarnInfoByPrecostingIdAfterBkngWithFabric",
                new { OrderId = orderId, PrecostingId = precostingId, PfbMasterId = pfbMasterId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TrimsConsumtionTotalNAvgCaluculation_Result>> TrimsConsumtionTotalNAvgCaluculation()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TrimsConsumtionTotalNAvgCaluculation_Result>(
                "TrimsConsumtionTotalNAvgCaluculation", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<trimsCostPivotTbl_Result>> TrimsCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<trimsCostPivotTbl_Result>(
                "trimsCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<trimsCostPivotTblV2_Result>> TrimsCostPivotTblV2()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<trimsCostPivotTblV2_Result>(
                "trimsCostPivotTblV2", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<WashCostPivotTbl_Result>> WashCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<WashCostPivotTbl_Result>(
                "WashCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<WashCostPivotTblv2_Result>> WashCostPivotTblv2()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<WashCostPivotTblv2_Result>(
                "WashCostPivotTblv2", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnCostPivotTbl_Result>> YarnCostPivotTbl()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnCostPivotTbl_Result>(
                "YarnCostPivotTbl", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnCostWithLacra_Result>> YarnCostWithLacra()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnCostWithLacra_Result>(
                "YarnCostWithLacra", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnCostWithOutLacra_Result>> YarnCostWithOutLacra()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnCostWithOutLacra_Result>(
                "YarnCostWithOutLacra", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BankLoanPayment_Result>> BankLoanPayment()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BankLoanPayment_Result>(
                "BankLoanPayment", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BankLoanStatment_Result>> BankLoanStatment(string bankRef)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BankLoanStatment_Result>(
                "BankLoanStatment",
                new { BankRef = bankRef },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BankOrBilRefWithRealization_Result>> BankOrBilRefWithRealization()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BankOrBilRefWithRealization_Result>(
                "BankOrBilRefWithRealization", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BtbLcReport_Result>> BtbLcReport(string fileNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BtbLcReport_Result>(
                "BtbLcReport",
                new { FileNo = fileNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BtbStatment_Result>> BtbStatment(string fileNo, int? invoiceId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<BtbStatment_Result>(
                "BtbStatment",
                new { FileNo = fileNo, InvoiceId = invoiceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CdAccountStatementRpt_Result>> CdAccountStatementRpt(int? realizeId, int? bankRefOrBilId, string internalFileNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CdAccountStatementRpt_Result>(
                "CdAccountStatementRpt",
                new { RealizeId = realizeId, BankRefOrBilId = bankRefOrBilId, InternalFileNo = internalFileNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CollarNCuffRpt_Result>> CollarNCuffRpt(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CollarNCuffRpt_Result>(
                "CollarNCuffRpt",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CollarRpt_Result>> CollarRpt(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CollarRpt_Result>(
                "CollarRpt",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ColorAndSizeWiseBreakDownRpt_Result>> ColorAndSizeWiseBreakDownRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ColorAndSizeWiseBreakDownRpt_Result>(
                "ColorAndSizeWiseBreakDownRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ColorAndSizeWiseBreakDownRptV2_Result>> ColorAndSizeWiseBreakDownRptV2(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ColorAndSizeWiseBreakDownRptV2_Result>(
                "ColorAndSizeWiseBreakDownRptV2",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CommercialCostRpt_Result>> CommercialCostRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CommercialCostRpt_Result>(
                "CommercialCostRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CommissionCostRpt_Result>> CommissionCostRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CommissionCostRpt_Result>(
                "CommissionCostRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ConversionCostRpt_Result>> ConversionCostRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ConversionCostRpt_Result>(
                "ConversionCostRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CuffRibRpt_Result>> CuffRibRpt(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CuffRibRpt_Result>(
                "CuffRibRpt",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CuffRpt_Result>> CuffRpt(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<CuffRpt_Result>(
                "CuffRpt",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAllOfferingCost(int? offeringCostId)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DeleteAllOfferingCost",
                new { OfferingCostId = offeringCostId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteEmbellishmentWODetailsChild(int? id)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DeleteEmbellishmentWODetailsChild",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteFromOrderByOrderAutoId(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DeleteFromOrderByOrderAutoId",
                new { OrderId = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeletePartialFabricBookingItemDtlsChilds(int? id)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DeletePartialFabricBookingItemDtlsChilds",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteTrimsBookingItemDtlsChild(int? id)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DeleteTrimsBookingItemDtlsChild",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteYarnCostByFabricIdNStripeRefrnc(int? fabricId)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DeleteYarnCostByFabricIdNStripeRefrnc",
                new { FabricId = fabricId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmbelishmentBookingJobWiseRpt_Result>> EmbelishmentBookingJobWiseRpt(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<EmbelishmentBookingJobWiseRpt_Result>(
                "EmbelishmentBookingJobWiseRpt",
                new { BookingId = bookingId, BuyerId = buyerId, jobNoId = jobNoId, poNoId = poNoId, styleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmbelishmentBookingPoWiseRpt_Result>> EmbelishmentBookingPoWiseRpt(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<EmbelishmentBookingPoWiseRpt_Result>(
                "EmbelishmentBookingPoWiseRpt",
                new { BookingId = bookingId, BuyerId = buyerId, jobNoId = jobNoId, poNoId = poNoId, styleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmbellishmentCostRpt_Result>> EmbellishmentCostRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<EmbellishmentCostRpt_Result>(
                "EmbellishmentCostRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ExportFileNumbers_Result>> ExportFileNumbers()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ExportFileNumbers_Result>(
                "ExportFileNumbers", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ExportFileNumbersV2_Result>> ExportFileNumbersV2()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ExportFileNumbersV2_Result>(
                "ExportFileNumbersV2", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ExportInvoiceByLcBudget_Result>> ExportInvoiceByLcBudget(int? lcId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ExportInvoiceByLcBudget_Result>(
                "ExportInvoiceByLcBudget",
                new { LcId = lcId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ExportInvoiceByScBudget_Result>> ExportInvoiceByScBudget(int? scId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ExportInvoiceByScBudget_Result>(
                "ExportInvoiceByScBudget",
                new { ScId = scId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ExportLcStatementRpt_Result>> ExportLcStatementRpt(int? realizeId, int? bankRefOrBilId, string internalFileNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ExportLcStatementRpt_Result>(
                "ExportLcStatementRpt",
                new { RealizeId = realizeId, BankRefOrBilId = bankRefOrBilId, InternalFileNo = internalFileNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ExportScOrLcReport_Result>> ExportScOrLcReport(string filno)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ExportScOrLcReport_Result>(
                "ExportScOrLcReport",
                new { Filno = filno },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricBookingJobWiseRpt_Result>> FabricBookingJobWiseRpt(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricBookingJobWiseRpt_Result>(
                "FabricBookingJobWiseRpt",
                new { BookingId = bookingId, BuyerId = buyerId, jobNoId = jobNoId, poNoId = poNoId, styleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricBookingRptByDiaNFinisCons_Result>> FabricBookingRptByDiaNFinisCons(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricBookingRptByDiaNFinisCons_Result>(
                "FabricBookingRptByDiaNFinisCons",
                new { BookingId = bookingId, BuyerId = buyerId, jobNoId = jobNoId, poNoId = poNoId, styleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricCostRpt_Result>> FabricCostRpt(int? cmnCompanyId, string styleRef, int? orderId, int? poNo, int? buyer)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricCostRpt_Result>(
                "FabricCostRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, OrderId = orderId, PoNo = poNo, Buyer = buyer },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FabricPriceCalculation_Result>> FabricPriceCalculation(int? offeringCostId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FabricPriceCalculation_Result>(
                "FabricPriceCalculation",
                new { OfferingCostId = offeringCostId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FcbrStatementBalanceFileWise_Result>> FcbrStatementBalanceFileWise(int? bankRefId, string filNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FcbrStatementBalanceFileWise_Result>(
                "FcbrStatementBalanceFileWise",
                new { BankRefId = bankRefId, FilNo = filNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FCBRStatementRpt_Result>> FCBRStatementRpt(int? bankRefId, string fileNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FCBRStatementRpt_Result>(
                "FCBRStatementRpt",
                new { BankRefId = bankRefId, FileNo = fileNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FileActivitesNdHistoryGet_Result>> FileActivitesNdHistoryGet(string fileNo, string fileNumbers)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FileActivitesNdHistoryGet_Result>(
                "FileActivitesNdHistoryGet",
                new { FileNo = fileNo, FileNumbers = fileNumbers },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FileActivitesNdHistoryGetByParticular_Result>> FileActivitesNdHistoryGetByParticular(string fileNo, string particular, int? particularId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FileActivitesNdHistoryGetByParticular_Result>(
                "FileActivitesNdHistoryGetByParticular",
                new { FileNo = fileNo, Particular = particular, ParticularId = particularId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> FileActivitesNdHistoryInsertOrUpdate(int? id, string fileNo, string particular, int? particularId, double? particularBudget, string accountType, string targetFileNo, double? sendingAmount, double? openingAmount, double? requestAmount, double? confirmedAmount, int? usesModuleStatus, int? fileStatus, int? entryBy, DateTime? entryDate, string remarks, string parentParticular, int? parentParticularId)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "FileActivitesNdHistoryInsertOrUpdate",
                new
                {
                    Id = id,
                    FileNo = fileNo,
                    Particular = particular,
                    ParticularId = particularId,
                    ParticularBudget = particularBudget,
                    AccountType = accountType,
                    TargetFileNo = targetFileNo,
                    SendingAmount = sendingAmount,
                    OpeningAmount = openingAmount,
                    RequestAmount = requestAmount,
                    ConfirmedAmount = confirmedAmount,
                    UsesModuleStatus = usesModuleStatus,
                    FileStatus = fileStatus,
                    EntryBy = entryBy,
                    EntryDate = entryDate,
                    Remarks = remarks,
                    ParentParticular = parentParticular,
                    ParentParticularId = parentParticularId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FileJobsNumbers_Result>> FileJobsNumbers(string fileNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FileJobsNumbers_Result>(
                "FileJobsNumbers",
                new { FileNo = fileNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FlatKnitCollarRpt_Result>> FlatKnitCollarRpt(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FlatKnitCollarRpt_Result>(
                "FlatKnitCollarRpt",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FlatKnitCuffRpt_Result>> FlatKnitCuffRpt(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<FlatKnitCuffRpt_Result>(
                "FlatKnitCuffRpt",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GarmentsCalculation_Result>> GarmentsCalculation(int? offeringCostId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GarmentsCalculation_Result>(
                "GarmentsCalculation",
                new { OfferingCostId = offeringCostId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCMDetailsRpt_Result>> GetCMDetailsRpt(int? jobNoId, string styleRef)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetCMDetailsRpt_Result>(
                "GetCMDetailsRpt",
                new { JobNoId = jobNoId, StyleRef = styleRef },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetcnsmptnTrimsCstByPreCstNIndxNo_Result>> GetcnsmptnTrimsCstByPreCstNIndxNo(int? precostingId, int? trimsIndexNo, int? trimsId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetcnsmptnTrimsCstByPreCstNIndxNo_Result>(
                "GetcnsmptnTrimsCstByPreCstNIndxNo",
                new { PrecostingId = precostingId, TrimsIndexNo = trimsIndexNo, TrimsId = trimsId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetcnsmptnWashCstByPreCstNIndxNo_Result>> GetcnsmptnWashCstByPreCstNIndxNo(int? precostingId, int? washIndexNo, int? washId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetcnsmptnWashCstByPreCstNIndxNo_Result>(
                "GetcnsmptnWashCstByPreCstNIndxNo",
                new { PrecostingId = precostingId, WashIndexNo = washIndexNo, WashId = washId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCollarNCuffByFabricCstId_Result>> GetCollarNCuffByFabricCstId(int? fabricCostId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetCollarNCuffByFabricCstId_Result>(
                "GetCollarNCuffByFabricCstId",
                new { FabricCostId = fabricCostId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<getColorByOrderId_Result>> GetColorByOrderId(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<getColorByOrderId_Result>(
                "getColorByOrderId",
                new { OrderId = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetColorSizeSensitivityByPreCstNIndxNo_Result>> GetColorSizeSensitivityByPreCstNIndxNo(int? precostingId, int? fabricIndexNo, int? fabricId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetColorSizeSensitivityByPreCstNIndxNo_Result>(
                "GetColorSizeSensitivityByPreCstNIndxNo",
                new { PrecostingId = precostingId, FabricIndexNo = fabricIndexNo, FabricId = fabricId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<string>> GetCompanyName()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<string>(
                "getCompanyName",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetConversionBudgetByProcess_Result>> GetConversionBudgetByProcess(int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId, int? processId, int? pFBId, int? yPOBookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetConversionBudgetByProcess_Result>(
                "GetConversionBudgetByProcess",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId, ProcessId = processId, PFBId = pFBId, YPOBookingId = yPOBookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetConversionCostFabricDescDDL_Result>> GetConversionCostFabricDescDDL(int? precostingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetConversionCostFabricDescDDL_Result>(
                "GetConversionCostFabricDescDDL",
                new { PrecostingId = precostingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEmbelCostBudgetByJobLevel_Result>> GetEmbelCostBudgetByJobLevel(int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId, int? embelTypeId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetEmbelCostBudgetByJobLevel_Result>(
                "GetEmbelCostBudgetByJobLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId, EmbelTypeId = embelTypeId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEmbelCostBudgetByPoLevel_Result>> GetEmbelCostBudgetByPoLevel(int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId, int? embelTypeId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetEmbelCostBudgetByPoLevel_Result>(
                "GetEmbelCostBudgetByPoLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId, EmbelTypeId = embelTypeId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEmblCstCnsmtnByPreCstNIndxNo_Result>> GetEmblCstCnsmtnByPreCstNIndxNo(int? precostingId, int? emblIndexNo, int? emblId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetEmblCstCnsmtnByPreCstNIndxNo_Result>(
                "GetEmblCstCnsmtnByPreCstNIndxNo",
                new { PrecostingId = precostingId, EmblIndexNo = emblIndexNo, EmblId = emblId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricColorSensitivitiesByFabricId_Result>> GetFabricColorSensitivitiesByFabricId(int? fabricId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricColorSensitivitiesByFabricId_Result>(
                "GetFabricColorSensitivitiesByFabricId",
                new { FabricId = fabricId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricConsumptionByFabricId_Result>> GetFabricConsumptionByFabricId(int? fabricId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricConsumptionByFabricId_Result>(
                "GetFabricConsumptionByFabricId",
                new { FabricId = fabricId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricConsumptionByPreCstNIndxNo_Result>> GetFabricConsumptionByPreCstNIndxNo(int? precostingId, int? fabIndexNo, int? fabricId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricConsumptionByPreCstNIndxNo_Result>(
                "GetFabricConsumptionByPreCstNIndxNo",
                new { PrecostingId = precostingId, FabIndexNo = fabIndexNo, FabricId = fabricId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricCostBudgetByJobLevel_Result>> GetFabricCostBudgetByJobLevel(int? buyerId, int? jobNoId, string styleRef, int? yearId, string jobOrPoLevel, int? fabricSourceId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricCostBudgetByJobLevel_Result>(
                "GetFabricCostBudgetByJobLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, StyleRef = styleRef, YearId = yearId, JobOrPoLevel = jobOrPoLevel, FabricSourceId = fabricSourceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricCostBudgetByPoLevel_Result>> GetFabricCostBudgetByPoLevel(int? cmnCompanyId, int? buyerId, string jobNo, int? jobNoId, string poNo, int? poId, string styleRef, int? yearId, string jobOrPoLevel)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricCostBudgetByPoLevel_Result>(
                "GetFabricCostBudgetByPoLevel",
                new { CmnCompanyId = cmnCompanyId, BuyerId = buyerId, JobNo = jobNo, JobNoId = jobNoId, PoNo = poNo, PoId = poId, StyleRef = styleRef, YearId = yearId, JobOrPoLevel = jobOrPoLevel },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFabricCostConsumptionForShortFabric_Result>> GetFabricCostConsumptionForShortFabric(int? precosting, int? poId, int? fabricCostId, string color, string gmtsSizes)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFabricCostConsumptionForShortFabric_Result>(
                "GetFabricCostConsumptionForShortFabric",
                new { Precosting = precosting, PoId = poId, FabricCostId = fabricCostId, Color = color, GmtsSizes = gmtsSizes },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetFileNumbersUnique_Result>> GetFileNumbersUnique()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetFileNumbersUnique_Result>(
                "GetFileNumbersUnique", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetGatePassRpt_Result>> GetGatePassRpt(int? getPassId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetGatePassRpt_Result>(
                "GetGatePassRpt",
                new { GetPassId = getPassId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetInitialConsumption_Result>> GetInitialConsumption(int? precostingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetInitialConsumption_Result>(
                "GetInitialConsumption",
                new { PrecostingId = precostingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<string>> GetLocationName()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<string>(
                "getLocationName",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMenu_Result>> GetMenu(int? userId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetMenu_Result>(
                "GetMenu",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetOrderProfitabilityRpt_Result>> GetOrderProfitabilityRpt(int? jobNoId, string styleRef)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetOrderProfitabilityRpt_Result>(
                "GetOrderProfitabilityRpt",
                new { JobNoId = jobNoId, StyleRef = styleRef },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetServiceBookingAllMasterDtlsByProcessId_Result>> GetServiceBookingAllMasterDtlsByProcessId(int? processId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetServiceBookingAllMasterDtlsByProcessId_Result>(
                "GetServiceBookingAllMasterDtlsByProcessId",
                new { ProcessId = processId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetServiceBookingRpt_Result>> GetServiceBookingRpt(int? buyerId, int? jobNoId, string styleRef, int? year, string monthName, int? processId, int? pFBId, int? yPOBookingId, int? woId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetServiceBookingRpt_Result>(
                "GetServiceBookingRpt",
                new { BuyerId = buyerId, JobNoId = jobNoId, StyleRef = styleRef, Year = year, MonthName = monthName, ProcessId = processId, PFBId = pFBId, YPOBookingId = yPOBookingId, WoId = woId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetShortFabricBookingRpt_Result>> GetShortFabricBookingRpt(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetShortFabricBookingRpt_Result>(
                "GetShortFabricBookingRpt",
                new { BookingId = bookingId, BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetShortFabricCostBudgetByJobLevel_Result>> GetShortFabricCostBudgetByJobLevel(int? buyerId, int? jobNoId, string styleRef, int? yearId, string jobOrPoLevel, int? fabricSourceId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetShortFabricCostBudgetByJobLevel_Result>(
                "GetShortFabricCostBudgetByJobLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, StyleRef = styleRef, YearId = yearId, JobOrPoLevel = jobOrPoLevel, FabricSourceId = fabricSourceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetShortTrimsCostBudgetByJobLevel_Result>> GetShortTrimsCostBudgetByJobLevel(int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetShortTrimsCostBudgetByJobLevel_Result>(
                "GetShortTrimsCostBudgetByJobLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTblInitialOrderView_Result>> GetTblInitialOrderView(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetTblInitialOrderView_Result>(
                "GetTblInitialOrderView",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTrimsBookingV3Rpt_Result>> GetTrimsBookingV3Rpt(int? buyerId, int? jobNoId, string styleRef, int? yearId, string jobOrPoLevel, int? groupId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetTrimsBookingV3Rpt_Result>(
                "GetTrimsBookingV3Rpt",
                new { BuyerId = buyerId, JobNoId = jobNoId, StyleRef = styleRef, YearId = yearId, JobOrPoLevel = jobOrPoLevel, GroupId = groupId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTrimsCostBudgetByJobLevel_Result>> GetTrimsCostBudgetByJobLevel(int? buyerId, int? jobNoId, string jobNoIds, int? poNoId, string styleRef, int? yearId, int? groupId, string groupIds)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetTrimsCostBudgetByJobLevel_Result>(
                "GetTrimsCostBudgetByJobLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, JobNoIds = jobNoIds, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId, GroupId = groupId, GroupIds = groupIds },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTrimsCostBudgetByJobLevelV2_Result>> GetTrimsCostBudgetByJobLevelV2(int? buyerId, int? jobNoId, int? poNoId, string jobNoIds, string styleRef, int? yearId, int? groupId, string groupIds)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetTrimsCostBudgetByJobLevelV2_Result>(
                "GetTrimsCostBudgetByJobLevelV2",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, JobNoIds = jobNoIds, StyleRef = styleRef, YearId = yearId, GroupId = groupId, GroupIds = groupIds },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTrimsCostBudgetByPoLevel_Result>> GetTrimsCostBudgetByPoLevel(int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId, int? groupId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetTrimsCostBudgetByPoLevel_Result>(
                "GetTrimsCostBudgetByPoLevel",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId, GroupId = groupId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetYarnConsOptimaizationStripeColor_Result>> GetYarnConsOptimaizationStripeColor(int? fabricId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetYarnConsOptimaizationStripeColor_Result>(
                "GetYarnConsOptimaizationStripeColor",
                new { FabricId = fabricId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetYarnCountDtermntnOrFabDesc_Result>> GetYarnCountDtermntnOrFabDesc(int? cmnCompanyId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetYarnCountDtermntnOrFabDesc_Result>(
                "GetYarnCountDtermntnOrFabDesc",
                new { CmnCompanyId = cmnCompanyId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetYarnDyeingWorkOrderByProcessId_Result>> GetYarnDyeingWorkOrderByProcessId(int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId, int? processId, int? pFBId, int? yPOBookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetYarnDyeingWorkOrderByProcessId_Result>(
                "GetYarnDyeingWorkOrderByProcessId",
                new { BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId, ProcessId = processId, PFBId = pFBId, YPOBookingId = yPOBookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetYarnPurchaseOrderDetails_Result>> GetYarnPurchaseOrderDetails(int? yPOBookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetYarnPurchaseOrderDetails_Result>(
                "GetYarnPurchaseOrderDetails",
                new { YPOBookingId = yPOBookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetYarnPurchaseRpt_Result>> GetYarnPurchaseRpt(int? buyerId, int? jobNoId, string styleRef, int? yearId, int? yPOBookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<GetYarnPurchaseRpt_Result>(
                "GetYarnPurchaseRpt",
                new { BuyerId = buyerId, JobNoId = jobNoId, StyleRef = styleRef, YearId = yearId, YPOBookingId = yPOBookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ImportFileNumbers_Result>> ImportFileNumbers()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ImportFileNumbers_Result>(
                "ImportFileNumbers", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<isFabricBookingDiaOrFinsConsWiseOrNot_Result>> IsFabricBookingDiaOrFinsConsWiseOrNot(int? bookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<isFabricBookingDiaOrFinsConsWiseOrNot_Result>(
                "isFabricBookingDiaOrFinsConsWiseOrNot",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PartialFabBkngHelprForSrcngOrderId_Result>> PartialFabBkngHelprForSrcngOrderId(int? fabricBookingMasterId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<PartialFabBkngHelprForSrcngOrderId_Result>(
                "PartialFabBkngHelprForSrcngOrderId",
                new { FabricBookingMasterId = fabricBookingMasterId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PiInfoGetByBtbId_Result>> PiInfoGetByBtbId(int? btbId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<PiInfoGetByBtbId_Result>(
                "PiInfoGetByBtbId",
                new { BtbId = btbId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PreCostingRpt_Result>> PreCostingRpt(int? cmnCompanyId, string styleRef, int? orderId, int? poNo, int? buyer)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<PreCostingRpt_Result>(
                "PreCostingRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, OrderId = orderId, PoNo = poNo, Buyer = buyer },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<processInvcForbillingById_Result>> ProcessInvcForbillingById(int? invoiceId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<processInvcForbillingById_Result>(
                "processInvcForbillingById",
                new { InvoiceId = invoiceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ServicebkngAopBookingQuantity_Result>> ServicebkngAopBookingQuantity(int? serviceBookingId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ServicebkngAopBookingQuantity_Result>(
                "ServicebkngAopBookingQuantity",
                new { ServiceBookingId = serviceBookingId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ServicebkngAopRpt_Result>> ServicebkngAopRpt(int? serviceBookingId, int? fabricBookingId, int? orderAutoId, string styleRef, string refNo, int? poId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ServicebkngAopRpt_Result>(
                "ServicebkngAopRpt",
                new { ServiceBookingId = serviceBookingId, FabricBookingId = fabricBookingId, OrderAutoId = orderAutoId, StyleRef = styleRef, RefNo = refNo, PoId = poId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TopChartPreCostingRpt_Result>> TopChartPreCostingRpt(int? orderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TopChartPreCostingRpt_Result>(
                "TopChartPreCostingRpt",
                new { OrderId = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TrimCostsRpt_Result>> TrimCostsRpt(int? cmnCompanyId, string styleRef, int? initialOrderId, string jobNo, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TrimCostsRpt_Result>(
                "TrimCostsRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, InitialOrderId = initialOrderId, JobNo = jobNo, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TrimsBookingJobWiseRpt_Result>> TrimsBookingJobWiseRpt(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TrimsBookingJobWiseRpt_Result>(
                "TrimsBookingJobWiseRpt",
                new { BookingId = bookingId, BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TrimsBookingPoWiseRpt_Result>> TrimsBookingPoWiseRpt(int? bookingId, int? buyerId, int? jobNoId, int? poNoId, string styleRef, int? yearId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TrimsBookingPoWiseRpt_Result>(
                "TrimsBookingPoWiseRpt",
                new { BookingId = bookingId, BuyerId = buyerId, JobNoId = jobNoId, PoNoId = poNoId, StyleRef = styleRef, YearId = yearId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<WashCostRpt_Result>> WashCostRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<WashCostRpt_Result>(
                "WashCostRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnCostsRpt_Result>> YarnCostsRpt(int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, DateTime? toDate, DateTime? fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnCostsRpt_Result>(
                "YarnCostsRpt",
                new { CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnInformationByPrecostingIdOrOrdId_Result>> YarnInformationByPrecostingIdOrOrdId(int? precostingId, int? initialOrderId)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnInformationByPrecostingIdOrOrdId_Result>(
                "YarnInformationByPrecostingIdOrOrdId",
                new { PrecostingId = precostingId, InitialOrderId = initialOrderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnInformationForFabBkngRptWithoutStripeColor_Result>> YarnInformationForFabBkngRptWithoutStripeColor(int? fabricBookingId, int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, string toDate, string fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnInformationForFabBkngRptWithoutStripeColor_Result>(
                "YarnInformationForFabBkngRptWithoutStripeColor",
                new { FabricBookingId = fabricBookingId, CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnInformationForFabBkngRptWithStripeColor_Result>> YarnInformationForFabBkngRptWithStripeColor(int? fabricBookingId, int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, string toDate, string fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnInformationForFabBkngRptWithStripeColor_Result>(
                "YarnInformationForFabBkngRptWithStripeColor",
                new { FabricBookingId = fabricBookingId, CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<GetFabricConsumptionByFabricId_Result> GetFabricConsumptionByFabricIdAsync(int? fabricId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FabricId", fabricId, DbType.Int32);

                var result = await connection.QueryFirstOrDefaultAsync<GetFabricConsumptionByFabricId_Result>(
                    "GetFabricConsumptionByFabricId",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<IEnumerable<YarnInformationForFabBkngRptWithStripeColorSummary_Result>> YarnInformationForFabBkngRptWithStripeColorSummary(int? fabricBookingId, int? cmnCompanyId, string styleRef, string jobNo, int? initialOrderId, int? year, int? month, string toDate, string fromDate)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnInformationForFabBkngRptWithStripeColorSummary_Result>(
                "YarnInformationForFabBkngRptWithStripeColorSummary",
                new { FabricBookingId = fabricBookingId, CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo, InitialOrderId = initialOrderId, Year = year, Month = month, ToDate = toDate, FromDate = fromDate },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<YarnInformationForFabricBookingRpt_Result>> YarnInformationForFabricBookingRpt(int? fabricBookingId, int? cmnCompanyId, string styleRef, string jobNo)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<YarnInformationForFabricBookingRpt_Result>(
                "YarnInformationForFabricBookingRpt",
                new { FabricBookingId = fabricBookingId, CmnCompanyId = cmnCompanyId, StyleRef = styleRef, JobNo = jobNo },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AddPrecostingJobSelectionView>> GetAddPrecostingJobSelectionView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM AddPrecostingJobSelectionView";
            return await connection.QueryAsync<AddPrecostingJobSelectionView>(sql);
        }

        public async Task<IEnumerable<CommercialJobSelectionView>> GetCommercialJobSelectionView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM CommercialJobSelectionView";
            return await connection.QueryAsync<CommercialJobSelectionView>(sql);
        }

        public async Task<IEnumerable<ImportDocumentAccptance_Views>> GetImportDocumentAccptanceViews()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM ImportDocumentAccptance_Views";
            return await connection.QueryAsync<ImportDocumentAccptance_Views>(sql);
        }

        public async Task<IEnumerable<MultipleJobWiseEmbelsTblView>> GetMultipleJobWiseEmbelsTblViews()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM MultipleJobWiseEmbelsTblView";
            return await connection.QueryAsync<MultipleJobWiseEmbelsTblView>(sql);
        }

        public async Task<IEnumerable<PiEbellishmentMaster_view>> GetPiEbellishmentMasterView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM PiEbellishmentMaster_view";
            return await connection.QueryAsync<PiEbellishmentMaster_view>(sql);
        }

        public async Task<IEnumerable<PiTrimsMaster_view>> GetPiTrimsMasterView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM PiTrimsMaster_view";
            return await connection.QueryAsync<PiTrimsMaster_view>(sql);
        }

        public async Task<IEnumerable<PiYarnMaster_view>> GetPiYarnMasterView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM PiYarnMaster_view";
            return await connection.QueryAsync<PiYarnMaster_view>(sql);
        }

        public async Task<IEnumerable<PrecostingView>> GetPrecostingView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM PrecostingViews";
            return await connection.QueryAsync<PrecostingView>(sql);
        }

        public async Task<IEnumerable<ProformaModal_view>> GetProformaModalView()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM ProformaModal_view";
            return await connection.QueryAsync<ProformaModal_view>(sql);
        }

        public async Task<IEnumerable<View_BankLoan>> GetViewBankLoan()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_BankLoan";
            return await connection.QueryAsync<View_BankLoan>(sql);
        }

        public async Task<IEnumerable<View_BtbMarginLc>> GetViewBtbMarginLc()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_BtbMarginLc";
            return await connection.QueryAsync<View_BtbMarginLc>(sql);
        }

        public async Task<IEnumerable<View_BuyerProfile>> GetViewBuyerProfile()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_BuyerProfile";
            return await connection.QueryAsync<View_BuyerProfile>(sql);
        }

        public async Task<IEnumerable<View_FabricCost>> GetViewFabricCost()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_FabricCost";
            return await connection.QueryAsync<View_FabricCost>(sql);
        }

        public async Task<IEnumerable<View_fabricCostConsumption>> GetViewFabricCostConsumption()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_fabricCostConsumption";
            return await connection.QueryAsync<View_fabricCostConsumption>(sql);
        }

        public async Task<IEnumerable<View_PartialFabricBookingItemDtlsChilds>> GetViewPartialFabricBookingItemDtlsChilds()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_PartialFabricBookingItemDtlsChilds";
            return await connection.QueryAsync<View_PartialFabricBookingItemDtlsChilds>(sql);
        }

        public async Task<IEnumerable<View_PaymentBankLoan>> GetViewPaymentBankLoan()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_PaymentBankLoan";
            return await connection.QueryAsync<View_PaymentBankLoan>(sql);
        }

        public async Task<IEnumerable<View_SupplierProfiles>> GetViewSupplierProfiles()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM View_SupplierProfiles";
            return await connection.QueryAsync<View_SupplierProfiles>(sql);
        }
    }
}