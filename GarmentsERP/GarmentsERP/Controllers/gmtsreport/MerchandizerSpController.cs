using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GarmentsERP.Models;
using GarmentsERP.Models.ReportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarmentsERP.Repositories;

namespace GarmentsERP.Controllers.GmtsReport
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MerchandizerSpController : ControllerBase
    {
        private readonly DapperRepository _db;

        public MerchandizerSpController(DapperRepository db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet("colorByOrderId/{orderId}")]
        public async Task<ActionResult<IEnumerable<getColorByOrderId_Result>>> ColorByOrderId(int orderId)
        {
            if (orderId <= 0)
                return BadRequest("Invalid order ID.");

            try
            {
                var result = await _db.GetColorByOrderId(orderId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving colors.");
            }
        }

        [HttpGet("get1/{id}")]
        public async Task<ActionResult<IEnumerable<string>>> Get1(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            try
            {
                // Placeholder implementation; replace with actual logic if needed
                return Ok(new string[] { "value2" });
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("get2")]
        public async Task<ActionResult<IEnumerable<string>>> Get2()
        {
            try
            {
                // Placeholder implementation; replace with actual logic if needed
                return Ok(new string[] { "g2" });
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost("GetFabricCostBudgetByJobLevel")]
        public async Task<ActionResult<IEnumerable<GetFabricCostBudgetByJobLevel_Result>>> GetFabricCostBudgetByJobLevel([FromBody] fabricBugetDto dto)
        {
            if (dto == null || !IsValidFabricBudgetDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetFabricCostBudgetByJobLevel(
                    dto.BuyerProfileId, dto.JobNoId, dto.StyleRef, dto.YearId, dto.JobOrPoLevel, dto.FabricSourceId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving fabric cost budget.");
            }
        }

        [HttpPost("GetShortFabricCostBudgetByJobLevel")]
        public async Task<ActionResult<IEnumerable<GetShortFabricCostBudgetByJobLevel_Result>>> GetShortFabricCostBudgetByJobLevel([FromBody] fabricBugetDto dto)
        {
            if (dto == null || !IsValidFabricBudgetDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetShortFabricCostBudgetByJobLevel(
                    dto.BuyerProfileId, dto.JobNoId, dto.StyleRef, dto.YearId, dto.JobOrPoLevel, dto.FabricSourceId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving short fabric cost budget.");
            }
        }

        [HttpPost("GetTrimCostBudgetByPoLevel")]
        public async Task<ActionResult<IEnumerable<GetTrimsCostBudgetByPoLevel_Result>>> GetTrimCostBudgetByPoLevel([FromBody] TrimCostDtos dto)
        {
            if (dto == null || !IsValidTrimCostDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetTrimsCostBudgetByPoLevel(
                    dto.BuyerProfileId, dto.JobNoId, dto.PoNoId, dto.StyleRef, dto.YearId, dto.GroupId);
                return Ok(result.Where(w => w.IsTrimBookingComplete == 0));
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving trim cost budget by PO level.");
            }
        }

        [HttpPost("GetTrimCostBudgetByJobLevel")]
        public async Task<ActionResult<IEnumerable<GetTrimsCostBudgetByJobLevelV2_Result>>> GetTrimCostBudgetByJobLevel([FromBody] TrimCostDtos dto)
        {
            if (dto == null || !IsValidTrimCostDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetTrimsCostBudgetByJobLevelV2(
                    dto.BuyerProfileId, dto.JobNoId, dto.PoNoId, dto.JobNoIds, dto.StyleRef, dto.YearId, dto.GroupId, dto.GroupIds);
                return Ok(result.Where(w => w.IsTrimBookingComplete == 0));
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving trim cost budget by job level.");
            }
        }

        [HttpPost("GetShortTrimCostBudgetByJobLevel")]
        public async Task<ActionResult<IEnumerable<GetShortTrimsCostBudgetByJobLevel_Result>>> GetShortTrimCostBudgetByJobLevel([FromBody] TrimCostDtos dto)
        {
            if (dto == null || !IsValidTrimCostDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetShortTrimsCostBudgetByJobLevel(
                    dto.BuyerProfileId, dto.JobNoId, dto.PoNoId, dto.StyleRef, dto.YearId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving short trim cost budget.");
            }
        }

        [HttpPost("GetEmbelCostBudgetByJobLevel")]
        public async Task<ActionResult<IEnumerable<GetEmbelCostBudgetByJobLevel_Result>>> GetEmbelCostBudgetByJobLevel([FromBody] TrimCostDtos dto)
        {
            if (dto == null || !IsValidTrimCostDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetEmbelCostBudgetByJobLevel(
                    dto.BuyerProfileId, dto.JobNoId, dto.PoNoId, dto.StyleRef, dto.YearId, dto.EmbelTypeId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving embellishment cost budget by job level.");
            }
        }

        [HttpPost("GetEmbelCostBudgetByPoLevel")]
        public async Task<ActionResult<IEnumerable<GetEmbelCostBudgetByPoLevel_Result>>> GetEmbelCostBudgetByPoLevel([FromBody] TrimCostDtos dto)
        {
            if (dto == null || !IsValidTrimCostDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetEmbelCostBudgetByPoLevel(
                    dto.BuyerProfileId, dto.JobNoId, dto.PoNoId, dto.StyleRef, dto.YearId, dto.EmbelTypeId);
                return Ok(result.Where(w => w.IsEmbellishmentCostBooking == 0));
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving embellishment cost budget by PO level.");
            }
        }

        [HttpGet("GetInitialConsumption/{precstId}")]
        public async Task<ActionResult<IEnumerable<GetInitialConsumption_Result>>> GetInitialConsumption(int precstId)
        {
            if (precstId <= 0)
                return BadRequest("Invalid precosting ID.");

            try
            {
                var result = await _db.GetInitialConsumption(precstId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving initial consumption.");
            }
        }
        [HttpGet("GetFabricCostConsumptionByFabricCstId/{fabricCstId}")]
        public async Task<ActionResult<IEnumerable<GetInitialConsumption_Result>>> GetFabricCostConsumptionByFabricCstId(int fabricCstId)
        {
            if (fabricCstId <= 0)
                return BadRequest("Invalid fabricCstId ID.");

            try
            {
                var result = await _db.GetFabricConsumptionByFabricIdAsync(fabricCstId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving initial consumption.");
            }
        }
        [HttpGet("DeleteOfferingCostByOfferingId/{OfferingId}")]
        public async Task<ActionResult<int>> DeleteOfferingCostByOfferingId(int OfferingId)
        {
            if (OfferingId <= 0)
                return BadRequest("Invalid offering ID.");

            try
            {
                var rowsAffected = await _db.DeleteAllOfferingCost(OfferingId);
                return Ok(rowsAffected);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting offering cost.");
            }
        }

        [HttpGet("GetTblInitialOrderView")]
        public async Task<ActionResult<IEnumerable<GetTblInitialOrderView_Result>>> GetTblInitialOrderView()
        {
            try
            {
                // Replace hard-coded dates with configurable or dynamic values
                var result = await _db.GetTblInitialOrderView(0, "", "", 0, 0, 0, null, null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving initial order view.");
            }
        }
        [HttpGet("PrecostingViews")]
        public async Task<ActionResult<IEnumerable<GetTblInitialOrderView_Result>>> PrecostingViews()
        {
            try
            {
                // Replace hard-coded dates with configurable or dynamic values
                var result = await _db.GetPrecostingView();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving initial order view.");
            }
        }
        [HttpGet("GetYarnCountDtermntnOrFabDesc")]
        public async Task<ActionResult<IEnumerable<GetYarnCountDtermntnOrFabDesc_Result>>> GetYarnCountDtermntnOrFabDesc()
        {
            try
            {
                var result = await _db.GetYarnCountDtermntnOrFabDesc(0);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving yarn count or fabric description.");
            }
        }

        [HttpGet("getFabDescFromFabricCost/{precostingId}")]
        public async Task<ActionResult<IEnumerable<GetConversionCostFabricDescDDL_Result>>> GetFabDescFromFabricCost(int precostingId)
        {
            if (precostingId <= 0)
                return BadRequest("Invalid precosting ID.");

            try
            {
                var result = await _db.GetConversionCostFabricDescDDL(precostingId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving fabric description.");
            }
        }

        [HttpPost("GetConversionBudgetByProcess")]
        public async Task<ActionResult<IEnumerable<GetConversionBudgetByProcess_Result>>> GetConversionBudgetByProcess([FromBody] ServiceBookingDto dto)
        {
            if (dto == null || !IsValidServiceBookingDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetConversionBudgetByProcess(
                    dto.BuyerId, dto.JobNoId, dto.PoNoId, dto.StyleRef, dto.YearId, dto.ProcessId, dto.PfbId, dto.YpoBookingId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving conversion budget by process.");
            }
        }

        [HttpGet("GetServiceBookingAllMasterDtlsByProcessId/{processId}")]
        public async Task<ActionResult<IEnumerable<GetServiceBookingAllMasterDtlsByProcessId_Result>>> GetServiceBookingAllMasterDtlsByProcessId(int processId)
        {
            if (processId <= 0)
                return BadRequest("Invalid process ID.");

            try
            {
                var result = await _db.GetServiceBookingAllMasterDtlsByProcessId(processId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving service booking master details.");
            }
        }

        [HttpGet("YarnInformationForFabricBookingRpt/{precostingId}")]
        public async Task<ActionResult<IEnumerable<ProcessYarnInfoByPrecostingIdAfterBkng_Result>>> YarnInformationForFabricBookingRpt(int? precostingId)
        {
            if (precostingId <= 0)
                return BadRequest("Invalid precosting ID.");

            try
            {
                var result = await _db.ProcessYarnInfoByPrecostingIdAfterBkng(0, precostingId, 0);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving yarn information.");
            }
        }

        [HttpPost("GetYarnDyeingWorkOrderByProcess")]
        public async Task<ActionResult<IEnumerable<GetYarnDyeingWorkOrderByProcessId_Result>>> GetYarnDyeingWorkOrderByProcess([FromBody] ServiceBookingDto dto)
        {
            if (dto == null || !IsValidServiceBookingDto(dto))
                return BadRequest("Invalid request data.");

            try
            {
                var result = await _db.GetYarnDyeingWorkOrderByProcessId(
                    dto.BuyerId, dto.JobNoId, dto.PoNoId, dto.StyleRef, dto.YearId, dto.ProcessId, dto.PfbId, dto.YpoBookingId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving yarn dyeing work order.");
            }
        }

        [HttpGet("DeleteYarnCostByFabricIdNStripeRefrnc/{fabricCostId}")]
        public async Task<ActionResult<int>> DeleteYarnCostByFabricIdNStripeRefrnc(int? fabricCostId)
        {
            if (!fabricCostId.HasValue || fabricCostId <= 0)
                return BadRequest("Invalid fabric cost ID.");

            try
            {
                var rowsAffected = await _db.DeleteYarnCostByFabricIdNStripeRefrnc(fabricCostId);
                return Ok(rowsAffected);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting yarn cost.");
            }
        }

        // Validation helpers
        private bool IsValidFabricBudgetDto(fabricBugetDto dto)
        {
            return dto.BuyerProfileId > 0 && dto.YearId > 0;
        }

        private bool IsValidTrimCostDto(TrimCostDtos dto)
        {
            return dto.BuyerProfileId > 0 && dto.YearId > 0;
        }

        private bool IsValidServiceBookingDto(ServiceBookingDto dto)
        {
            return dto.BuyerId > 0 && dto.YearId > 0;
        }
    }
}