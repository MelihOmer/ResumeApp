using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.SkillsDtos;
using ResumeApp.Web.ActionFilters;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new SkillCreateDto());
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<SkillCreateDto>))]
        public async Task<IActionResult> Add(SkillCreateDto dto,int Id)
        {
            await _skillService.AddSkill(dto,Id);
            return RedirectToAction("Index", "Panel");
        }

        [HttpGet]
        public async Task<IActionResult> EditSkill(int Id)
        {
            var skillDto = await _skillService.GetSkillUpdate(Id);
            return View(skillDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<SkillUpdateDto>))]
        public async Task<IActionResult> EditSkill(SkillUpdateDto skillDto)
        {
            await _skillService.UpdateSkill(skillDto);
            return RedirectToAction("Skill", "Panel");
        }
        [HttpGet]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            await _skillService.RemoveSkill(id);
            return RedirectToAction("Skill", "Panel");
        }
    }
}
