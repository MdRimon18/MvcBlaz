using Domain.CommonServices;
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
            viewModel.UnitList = (await _unitService.Get(null, null, null,"", GlobalPageConfig.PageNumber, GlobalPageConfig.PageSize)).ToList();
            return PartialView("Index", viewModel);
          
        }
    }
}
