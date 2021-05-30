using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _projectService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var project = await _projectService.GetByIdAsync(id);
            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                await _projectService.AddAsync(projectDto);
                return RedirectToAction(nameof(Index));
            }
            return View(projectDto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var projectDtoToEdit = await _projectService.GetByIdAsync(id);
            return View(projectDtoToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                await _projectService.UpdateAsync(projectDto);
                return RedirectToAction(nameof(Index));
            }
            return View(projectDto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var subjectDtoToDelete = await _projectService.GetByIdAsync(id);
            return View(subjectDtoToDelete);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _projectService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
