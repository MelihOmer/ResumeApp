using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos;
using ResumeApp.Web.ActionFilters;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }
        
        [HttpGet]
        public IActionResult Add()
        {

            return View(new ResumeCreateDto());
        }
        [HttpGet]
        public  IActionResult Update(int Id)
        {
            return View(_resumeService.GetResumeUpdate(Id));
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<ResumeUpdateDto>))]
        public async Task<IActionResult> Update(ResumeUpdateDto dto)
        {
            await _resumeService.Update(dto);
            return RedirectToAction("Index", "Panel");
        }
    }
}
