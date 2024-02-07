using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.EducationDtos;
using ResumeApp.Web.ActionFilters;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new EducationAddDto());
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<EducationAddDto>))]
        public async Task<IActionResult> Add(EducationAddDto dto, int Id)
        {
            await _educationService.AddEducation(dto, Id);
            return RedirectToAction("Index", "Panel");
        }
        [HttpGet]
        public async Task<IActionResult> EditEducation(int id)
        {
            var eduDto = await _educationService.GetEducationUpdate(id);
            return View(eduDto);
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<EducationUpdateDto>))]
        public async Task<IActionResult> EditEducation(EducationUpdateDto eduDto)
        {
            await _educationService.EducationUpdate(eduDto);
            return RedirectToAction("Education", "Panel");
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int Id)
        {
            await _educationService.RemoveEducation(Id);
            return RedirectToAction("Education", "Panel");
        }




        [HttpPost]
        public async Task<IActionResult> AddAjax(EducationAddDto valdata)
        {
            if (ModelState.IsValid)
            {
                await _educationService.AddEducation(valdata, 1);
                return Json(new { success = true, message = "Kayıt Oluşturuldu." });
            }
            else
            {
                return Json(new { success = false, message = "Kırmızı Kutu İçerisindeki Alanları Doldurunuz." });
            }
        }
    }

}
