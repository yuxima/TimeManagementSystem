using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Data.Implementation;

namespace TimeManagementSystem.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        private ApplicationContext _context;
        public TaskItemController(ITaskItemService taskItemService, ApplicationContext context)
        {
            _taskItemService = taskItemService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _taskItemService.GetAllAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var taskItemDto = await _taskItemService.GetByIdAsync(id);
            return View(taskItemDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemDto taskItemDto)
        {
            if (ModelState.IsValid)
            {
                await _taskItemService.AddAsync(taskItemDto);
                return RedirectToAction(nameof(Index));
            }
            return View(taskItemDto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var queue = await _taskItemService.GetByIdAsync(id);
            if (queue == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", queue.ProjectId);
            return View(queue);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TaskItemDto taskItemDto)
        {
            if (ModelState.IsValid)
            {
                await _taskItemService.UpdateAsync(taskItemDto);
                return RedirectToAction(nameof(Index));
            }
            return View(taskItemDto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var subjectDtoToDelete = await _taskItemService.GetByIdAsync(id);
            return View(subjectDtoToDelete);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _taskItemService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
