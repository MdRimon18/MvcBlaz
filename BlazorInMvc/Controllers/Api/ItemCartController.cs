using Domain.Entity;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    public class ItemCardController : BaseController
    {
        private readonly ItemCardService _itemCardService;

        public ItemCardController(ItemCardService itemCardService)
        {
            _itemCardService = itemCardService;
        }

        [HttpGet("GetItemCart")]
        public async Task<IActionResult> GetItemCart(
            int? cartId = null,
            long? customerId = null,
            long? productId = null,
            string? sku = null)
        {
            try
            {
                var result = await _itemCardService.GetItemCartAsync(cartId, customerId, productId, sku);
                if (result == null || !result.Any())
                {
                    return ErrorMessage("No items found in the cart.");
                }
                return SuccessMessage(result);
            }
            catch (Exception ex)
            {
                // Log exception
                return InternalServerError();
            }
        }

        [HttpPost("SaveOrUpdateItemCart")]
        public async Task<IActionResult> SaveOrUpdateItemCart([FromBody] ItemCart itemCart)
        {
            if (itemCart == null)
            {
                return ErrorMessage("Invalid item cart data.");
            }

            try
            {
                var successId = await _itemCardService.SaveOrUpdateItemCart(itemCart);

                if (successId > 0)
                {
                    return SuccessMessage(new { CartId = successId });
                }
                else
                {
                    return ErrorMessage("Failed to save or update the item cart.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return InternalServerError();
            }
        }

        [HttpGet("DeleteItemCart")]
        public async Task<IActionResult> DeleteItemCart(
            int? cartId = null,
            int? customerId = null,
            int? productId = null,
            string sku = null)
        {
            if (cartId == null && customerId == null && productId == null && string.IsNullOrEmpty(sku))
            {
                return ErrorMessage("At least one parameter must be provided for deletion.");
            }

            try
            {
                var isDeleted = await _itemCardService.DeleteItemCart(cartId, customerId, productId, sku);

                if (isDeleted)
                {
                    return SuccessMessage("Item cart deleted successfully.");
                }
                else
                {
                    return ErrorMessage("Failed to delete item cart.");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return InternalServerError();
            }
        }
    }
}
