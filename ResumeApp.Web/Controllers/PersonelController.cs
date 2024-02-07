using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ContactDtos;
using ResumeApp.Web.ActionFilters;
using ResumeApp.Web.Models;

namespace ResumeApp.Web.Controllers
{
    public class PersonelController : Controller
    {

        private readonly IExperienceService _experienceService;
        private readonly IEducationService _educationService;
        private readonly ISkillService _skillService;
        private readonly ILanguageService _languageService;
        private readonly IProjectService _projectService;
        private readonly IContactService _contactService;

        public PersonelController(IExperienceService experienceService, IEducationService educationService, ISkillService skillService, ILanguageService languageService, IProjectService projectService, IContactService contactService)
        {
            _experienceService = experienceService;
            _educationService = educationService;
            _skillService = skillService;
            _languageService = languageService;
            _projectService = projectService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Resume()
        {
            
            ResumeModel model = new ResumeModel()
            {
                Experiences = await _experienceService.GetAll(),
                Educations = await _educationService.GetAll(),
                Skills = await _skillService.GetAll(),
                ProgramingLanguages= await _languageService.GetAll(),
                
            };
           
            return View(model);
        }
        public async Task<IActionResult> Project()
        {
          var list =   await _projectService.GetAll();
            return View(list.ToList());
        }
        public async Task<IActionResult> ProjectDownload(string projectName)
        {
           byte[] bytes =  await _projectService.DownloadProject(projectName);
            return File(bytes, "application/octet-stream", projectName);
        }
        [HttpGet]
        public  IActionResult Contact()
        {
            
            return View(new ContactAddDto());
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<ContactAddDto>))]
        public async Task<IActionResult> Contact(ContactAddDto dto)
        {
           await _contactService.SendMessage(dto);
            return View("Index");
        }
        public async Task<JsonResult> GetContacts()
        {
            var dataList = await _contactService.Where(x => x.Seen == false).Take(3).ToListAsync();
            return Json(dataList);
        }
        public async  Task<IActionResult> GetGeneratedPdf()
        {
            //ChromePdfRenderer renderer = new ChromePdfRenderer();
            //PdfDocument pdf = renderer.RenderUrlAsPdf("https://localhost:44357/Personel/Resume");
            //return File(pdf.BinaryData, "application/octet-stream", "melihomerkamarcv.pdf");
           byte[] bytes =  await _projectService.DownloadCV();
            return File(bytes, "application/octet-stream", "melihomerkamarcv.pdf");
            return View("");
        }

    }
}
