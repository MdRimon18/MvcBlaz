using Domain.Entity.Settings;
using Domain.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.Net;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressBookController : ControllerBase
    {
        private readonly UserAddressBookService _userAddressBookService;

        public UserAddressBookController(UserAddressBookService userAddressBookService)
        {
            _userAddressBookService = userAddressBookService;
        }

        [HttpGet]
        // GET: api/GetAllAddresses
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _userAddressBookService.GetAllAddressesAsync();
            return Ok(new
            {
                response = addresses.Select(address => new
                {
                    addressID = address.AddressID,
                    userID = address.UserID,
                    addressType = address.AddressType,
                    address = address.Address,
                    isDefault = address.IsDefault
                }).ToList(),

                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
            });
        }

        // GET: api/UserAddressBook/5
        [HttpGet]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _userAddressBookService.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound(new
                {
                    response = (object)null,
                    code = HttpStatusCode.NotFound,
                    message = "Address not found",
                    isSuccess = false
                });
            }

            return Ok(new
            {
                response = new
                {
                    addressID = address.AddressID,
                    userID = address.UserID,
                    addressType = address.AddressType,
                    address = address.Address,
                    isDefault = address.IsDefault
                },
                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
            });
        }

        // POST: api/UserAddressBook
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAddress([FromBody] UserAddressBook address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    response = ModelState,
                    code = HttpStatusCode.BadRequest,
                    message = "Invalid data",
                    isSuccess = false
                });
            }

            var createdAddress = await _userAddressBookService.CreateOrUpdateAddressAsync(address);
            return Ok(new
            {
                response =new {
                    addressID= createdAddress.AddressID,
                    userID=createdAddress.UserID,
                    addressType= createdAddress.AddressType,
                    address= createdAddress.Address,
                    isDefault=createdAddress.IsDefault
                },
                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
            });
        }

    }
}
