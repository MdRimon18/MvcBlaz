﻿using Dapper;
 
using System.Data;
using Domain.Entity.Settings;
using Domain.CommonServices;
using Domain.DbContex;
using Domain.Entity;
using Domain.Services.Shared;

namespace Domain.Services.Inventory
{
    public class InvoiceTypeService
    {
        private readonly IDbConnection _db;


        public InvoiceTypeService(DbConnectionDapper db)
        {
            _db = db.GetDbConnection();

        }
        public async Task<IEnumerable<InvoiceType>> Get(long? InvoiceTypeId, string? InvoiceTypeKey, int? LanguageId, string? InvoiceTypeName, int? pagenumber, int? pageSize)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@InvoiceTypeId", InvoiceTypeId);
                parameters.Add("@InvoiceTypeKey", InvoiceTypeKey);

                parameters.Add("@LanguageId", LanguageId);
                parameters.Add("@InvoiceTypeName", InvoiceTypeName);
               
                parameters.Add("@page_number", pagenumber);
                parameters.Add("@page_size", pageSize);

                return await _db.QueryAsync<InvoiceType>("invoice_type_Get_SP", parameters, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                return Enumerable.Empty<InvoiceType>();
            }
        }

        public async Task<InvoiceType> GetById(long InvoiceTypeId)

        {
            var invoiceType = await (Get(InvoiceTypeId, null, null, null, 1, 1));
            return invoiceType.FirstOrDefault();
        }

        public async Task<InvoiceType> GetByKey(string InvoiceTypeKey)

        {
            var invoiceType = await (Get(null, InvoiceTypeKey, null, null, 1, 1));
            return invoiceType.FirstOrDefault();
        }


        public async Task<long> Save(InvoiceType invoiceType)
        {
            try
            {
                EntityHelper.SetCreateAuditFields(invoiceType);
                var parameters = new DynamicParameters();

                parameters.Add("@InvoiceTypeId", dbType: DbType.Int64, direction: ParameterDirection.Output);

                parameters.Add("@LanguageId", invoiceType.LanguageId);
                parameters.Add("@InvoiceTypeName", invoiceType.InvoiceTypeName);
                ParameterHelper.AddAuditParameters(invoiceType, parameters);

                await _db.ExecuteAsync("invoice_type_Insert_SP", parameters, commandType: CommandType.StoredProcedure);



                return parameters.Get<long>("@InvoiceTypeId");
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                Console.WriteLine($"An error occurred while adding order: {ex.Message}");
                return 0;
            }
        }


        public async Task<bool> Update(InvoiceType invoiceType)
        {
            EntityHelper.SetUpdateAuditFields(invoiceType);
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceTypeId", invoiceType.InvoiceTypeId);

            parameters.Add("@LanguageId", invoiceType.LanguageId);
            parameters.Add("@InvoiceTypeName", invoiceType.InvoiceTypeName);

            ParameterHelper.AddAuditParameters(invoiceType, parameters);

            parameters.Add("@success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _db.ExecuteAsync("invoice_type_Update_SP",
                  parameters, commandType: CommandType.StoredProcedure);

            int success = parameters.Get<int>("@success");
            return success > 0;
        }


        public async Task<bool> Delete(long InvoiceTypeId)
        {
            var invoiceType = await (Get(InvoiceTypeId, null, null, null, 1, 1));
            var deleteObj = invoiceType.FirstOrDefault();
            bool isDeleted = false;
            if (deleteObj != null)
            {
                EntityHelper.SetDeleteAuditFields(deleteObj);
                
                isDeleted = await Update(deleteObj);
            }

            return isDeleted;
        }
    }
}

