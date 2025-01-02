using Dapper;
using System.Data;
using Domain.Entity.Settings;
using Domain.DbContex;
using Domain.Entity;

namespace Domain.Services.Inventory
{
	public class ProductSpecificationService
	{
		private readonly IDbConnection _db;


		public ProductSpecificationService(DbConnectionDapper db)
		{
			_db = db.GetDbConnection();

		}
		public async Task<IEnumerable<ProductSpecifications>> Get(long? ProdSpcfctnId, string? ProdSpcfctnKey, long? ProductId,string? SpecificationName,string? SpecificationDtls, int? PageNumber, int? PageSize)
		{
			try
			{
				var parameters = new DynamicParameters();

				parameters.Add("@ProdSpcfctnId", ProdSpcfctnId);
				parameters.Add("@ProdSpcfctnKey", ProdSpcfctnKey);
				parameters.Add("@ProductId", ProductId);
				parameters.Add("@SpecificationName", SpecificationName);
				parameters.Add("@SpecificationDtls", SpecificationDtls);

				parameters.Add("@PageNumber", PageNumber);
				parameters.Add("@PageSize", PageSize);

				return await _db.QueryAsync<ProductSpecifications>("ProdSpecifications_get_Sp", parameters, commandType: CommandType.StoredProcedure);

			}
			catch (Exception ex)
			{

				return Enumerable.Empty<ProductSpecifications>();
			}
		}

		public async Task<ProductSpecifications> GetById(long ProdSpcfctnId)

		{
			var _productSpecifications = await (Get(ProdSpcfctnId,null,null,null, null, 1, 1));
			return _productSpecifications.FirstOrDefault();
		}

		public async Task<ProductSpecifications> GetByKey(string ProdSpcfctnKey)

		{
			var _productSpecifications = await (Get(null, ProdSpcfctnKey,null,null, null, 1, 1));
			return _productSpecifications.FirstOrDefault();
		}


		public async Task<long> SaveOrUpdate(ProductSpecifications _productSpecifications)
		{
			try
			{
				if (_productSpecifications.ProdSpcfctnId > 0)
				{
					EntityHelper.SetUpdateAuditFields(_productSpecifications);
				}
				else
				{
					EntityHelper.SetCreateAuditFields(_productSpecifications);
				}

				var parameters = new DynamicParameters();

				parameters.Add("@ProdSpcfctnId", _productSpecifications.ProdSpcfctnId);
				parameters.Add("@ProdSpcfctnKey", _productSpecifications.ProdSpcfctnKey);
				parameters.Add("@ProductId", _productSpecifications.ProductId);
				parameters.Add("@SpecificationName", _productSpecifications.SpecificationName);
				parameters.Add("@SpecificationDtls", _productSpecifications.SpecificationDtls);

				//parameters.Add("@EntryDateTime", _productSpecifications.EntryDateTime);
				//parameters.Add("@EntryBy", _productSpecifications.EntryBy);
				//parameters.Add("@LastModifyDate", _productSpecifications.LastModifyDate);
				//parameters.Add("@LastModifyBy", _productSpecifications.LastModifyBy);
				//parameters.Add("@DeletedDate", _productSpecifications.DeletedDate);
				//parameters.Add("@DeletedBy", _productSpecifications.DeletedBy);
				//parameters.Add("@Status", _productSpecifications.Status);
				parameters.Add("@SuccessOrFailId", dbType: DbType.Int32, direction: ParameterDirection.Output);
				await _db.ExecuteAsync("ProductSpecifications_InsertOrUpdate_SP", parameters, commandType: CommandType.StoredProcedure);

				return (long)parameters.Get<int>("@SuccessOrFailId");
			}
			catch (Exception ex)
			{
				// Handle the exception (e.g., log the error)
				Console.WriteLine($"An error occurred while adding order: {ex.Message}");
				return 0;
			}
		}

		public async Task<bool> Delete(long ProdSpcfctnId)
		{
			var _productSpecifications = await (Get(ProdSpcfctnId, null,null, null, null, 1, 1));
			var deleteObj = _productSpecifications.FirstOrDefault();
			long DeletedSatatus = 0;
			if (deleteObj != null)
			{
				deleteObj.DeletedDate = DateTime.UtcNow;
				deleteObj.Status = "Deleted";
				DeletedSatatus = await SaveOrUpdate(deleteObj);
			}

			return DeletedSatatus > 0;
		}
	}
}
