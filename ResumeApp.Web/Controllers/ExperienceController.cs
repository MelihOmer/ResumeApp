using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ExperienceDtos;
using ResumeApp.Core.Entities;
using ResumeApp.Web.ActionFilters;
using ResumeApp.Web.Models;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        private IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View(new ExperienceAddDto());
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<ExperienceAddDto>))]
        public async Task<IActionResult> Add(ExperienceAddDto dto, int Id)
        {
            await _experienceService.AddExperience(dto, Id);
            return RedirectToAction("Index", "Panel");
        }

        [HttpGet]
        public async Task<IActionResult> EditExperience(int id)
        {
            var experienceDto = await _experienceService.GetExperienceUpdate(id);
            return View(experienceDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<ExperienceUpdateDto>))]
        public async Task<IActionResult> EditExperience(ExperienceUpdateDto experienceDto)
        {
            await _experienceService.UpdateExperience(experienceDto);
            return RedirectToAction("Experience", "Panel");
        }
        [HttpGet]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            await _experienceService.RemoveExperience(id);
            return RedirectToAction("Experience", "Panel");
        }
    }
}
