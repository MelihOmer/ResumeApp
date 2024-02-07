using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ProjectDtos;
using ResumeApp.Web.ActionFilters;

namespace ResumeApp.Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService perojectService)
        {
            _projectService = perojectService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProjectCreateDto());
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<ProjectCreateDto>))]
        public async Task<IActionResult> Add(ProjectCreateDto dto,int Id)
        {
            await _projectService.AddProject(dto, Id);
            return RedirectToAction("Index", "Panel");
        }
        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            var projectUpdateDto = await _projectService.GetProjectUpdate(id);
            return View(projectUpdateDto);
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter<ProjectUpdateDto>))]
        public async Task<IActionResult> EditProject(ProjectUpdateDto projectDto)
        {
            await _projectService.ProjectUpdate(projectDto);
            return RedirectToAction("Project", "Panel");
        }
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            await _projectService.RemoveProject(id);
            return RedirectToAction("Project","Panel");
        }
    }
}
