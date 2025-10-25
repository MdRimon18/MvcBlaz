using Azure.Core;
using Domain.Entity;
using Domain.Entity.Inventory;
using Domain.Entity.Settings;
using Domain.Services;
using Domain.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Net;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ItemCardService _itemCardService;
        public OrderController(ItemCardService itemCardService)
        {
            _itemCardService = itemCardService;
        }
        [HttpGet("Place")]
        public async Task<IActionResult> Place(int addressId,long customerId,string? browserId)
        {

           // var result = (await _itemCardService.GetItemCartAsync(null, browserId, customerId, productId, sku)).ToList();
            //List<ItemCart> itemCartList  =(await _itemCardService.GetItemCartAsync(null, browserId, customerId, null, null)).ToList();
            //var invoiceItems = itemCartList
            //       .Select(item => new InvoiceItems
            //       {
            //           ProductImage = item.ImageUrl,
            //           ProductName = item.ProductName,
            //           CategoryName = item.CategoryName,
            //           SubCtgName = item.SubCtgName,
            //           Unit = item.Unit,

            //           InvoiceId = 0,
            //           ProductId = item.ProductId,
            //           Quantity = (int)item.Quantity,
            //           SellingPrice =item.SellingPrice??0,
            //           BuyingPrice = item.BuyingPrice??0,
            //           DiscountPercentg =0,
            //           RowIndex = item.CartId,
            //           Status = "Active",
            //           ProductVariantId = item.ProductVariantId??0
            //       }).ToList();

            return Ok(new
            {   
                Order=new {OrderId=1},
                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
            });
        }
    }
}
