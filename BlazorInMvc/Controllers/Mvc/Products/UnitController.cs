using Domain.CommonServices;
using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BlazorInMvc.Controllers.Mvc.Products
{
    public class UnitController : Controller
    {
        private readonly UnitService _unitService;
        public UnitController(UnitService unitService)
        {
            _unitService = unitService;
        }
            
        
        public async Task<IActionResult> Index()
        {
           UnitsViewModel viewModel = new UnitsViewModel();
            viewModel.UnitList =await FetchModelList();
            return PartialView("Index", viewModel);
          
        }
        public async Task<List<Unit>> FetchModelList()
        {
            var units = await _unitService.Get(
                null,                                 
                null,                               
                null,                               
                "",                                 
                GlobalPageConfig.PageNumber,        
                GlobalPageConfig.PageSize        
            );

            return units.ToList(); // Convert and return as List<Unit>
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveOrUpdate(Unit model)
        {
            if (ModelState.IsValid)
            {
                    try
                    {
                        if (model.UnitId>0)
                        {
                            var saveResult = await _unitService.Update(model);

                        }
                        else
                        {
                            var UpdateResult = await _unitService.Save(model);


                        }
                    }
                    catch (Exception ex)
                    {
                        return PartialView("AddForm", model);

                    }

                var list = await FetchModelList();
                return PartialView("_SearchResult", list);
            }


            Response.StatusCode = 400; // Indicate validation error with HTTP 400 status

            return PartialView("AddForm", model);
        }

        [HttpGet]
        public async Task<IActionResult> LoadEditModeData(long id)
        {
            if (id==0)
            {
                return NotFound();
            }
            Unit obj = (await _unitService.GetById(id));

            return PartialView("AddForm", obj);
        }
        [HttpGet]
        public async Task<IActionResult> AddNewForm()
        {
            Unit obj = new();
            if (obj == null)
            {
                return NotFound();
            }

            return PartialView("AddForm", obj);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid ID provided.");
            }

            try
            {
                if (id >0)
                {
                    var isDeleted = await _unitService.Delete(id);
                    
                }

            }
            catch (Exception)
            {
                // It's better to log the exception and provide a meaningful response to the user
                return StatusCode(500, "An error occurred while deleting the pipeline.");
            }


           
          var  list = await FetchModelList(); 

            return PartialView("_SearchResult", list);
           

        }
    }
}
