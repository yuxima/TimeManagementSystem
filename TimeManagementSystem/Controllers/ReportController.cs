using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _reportService.GetAllAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReportDto reportDto)
        {
            if (ModelState.IsValid)
            {
                await _reportService.AddAsync(reportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(reportDto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var subjectDtoToEdit = await _reportService.GetByIdAsync(id);
            return View(subjectDtoToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ReportDto reportDto)
        {
            if (ModelState.IsValid)
            {
                await _reportService.UpdateAsync(reportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(reportDto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var subjectDtoToDelete = await _reportService.GetByIdAsync(id);
            return View(subjectDtoToDelete);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _reportService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
