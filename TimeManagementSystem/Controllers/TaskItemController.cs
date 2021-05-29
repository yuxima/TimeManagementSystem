using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _taskItemService.GetAllAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
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
            var subjectDtoToEdit = await _taskItemService.GetByIdAsync(id);
            return View(subjectDtoToEdit);
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
