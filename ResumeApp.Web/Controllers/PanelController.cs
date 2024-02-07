using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Contracts.Services;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        private readonly IResumeService _resumeService;
        private readonly IContactService _contactService;
        private readonly IExperienceService _experienceService;
        private readonly IEducationService _educationService;
        private readonly ISkillService _skillService;
        private readonly IProjectService _projectService;
        private readonly ILanguageService _languageService;

        public PanelController(IResumeService resumeService, IContactService contactService, IExperienceService experienceService, IEducationService educationService, ISkillService skillService, IProjectService projectService, ILanguageService languageService)
        {
            _resumeService = resumeService;
            _contactService = contactService;
            _experienceService = experienceService;
            _educationService = educationService;
            _skillService = skillService;
            _projectService = projectService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _resumeService.GetAllResume();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetContactMessageDetails(int id)
        {
            var data = await _contactService.GetById(id);
            return View(data);
        }
        public async Task<IActionResult> GetContacts()
        {
            var list = await _contactService.GetAll();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Experience()
        {
            var list = await _experienceService.GetAll();
            return View(list);
        }
     
        [HttpGet]
        public async Task<IActionResult> Education()
        {
            var list = await _educationService.GetAll();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Skill()
        {
            var list = await _skillService.GetAll();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Project()
        {
            var list = await _projectService.GetAll();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> ProgramingLanguage()
        {
            var list = await _languageService.GetAll();
            return View(list);
        }
        [HttpGet]
        public  IActionResult ResumePdf()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResumePdf(IFormFile file)
        {
            await _projectService.SaveCv(file);
            return RedirectToAction("Index", "Panel");
        }








        [HttpPost]
        public async Task<JsonResult> SeenMessage(int id)
        {
            var message = await _contactService.SeenMessage(id);
            return Json(message);
        }
        public JsonResult messageCount()
        {
            var listCount = _contactService.Where(x => x.Seen != true).Count();
            return Json(listCount);
        }
    }
}
