using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ProgrammingLanguageDtos;
using ResumeApp.Web.ActionFilters;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new LanguageCreateDto());
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<LanguageCreateDto>))]
        public IActionResult Add(LanguageCreateDto dto, int Id)
        {
            _languageService.AddLanguage(dto, Id);
            return RedirectToAction("Index", "Panel");
        }
        public async Task<IActionResult> EditProgrammingLanguage(int id)
        {
            var programmingLanguage = await _languageService.GetProgrammingLanguageUpdate(id);
            return View(programmingLanguage);
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<LanguageUpdateDto>))]
        public async Task<IActionResult> EditProgrammingLanguage(LanguageUpdateDto languageDto)
        {
            await _languageService.ProgrammingLanguageUpdate(languageDto);
            return RedirectToAction("ProgramingLanguage", "Panel");
        }
        [HttpGet]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            await _languageService.RemoveLanguage(id);
            return RedirectToAction("ProgramingLanguage", "Panel");
        }
    }
}
