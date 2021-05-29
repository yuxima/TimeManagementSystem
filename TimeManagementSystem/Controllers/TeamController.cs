using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _teamService.GetAllAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamDto teamDto)
        {
            if (ModelState.IsValid)
            {
                await _teamService.AddAsync(teamDto);
                return RedirectToAction(nameof(Index));
            }
            return View(teamDto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var subjectDtoToEdit = await _teamService.GetByIdAsync(id);
            return View(subjectDtoToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeamDto teamDto)
        {
            if (ModelState.IsValid)
            {
                await _teamService.UpdateAsync(teamDto);
                return RedirectToAction(nameof(Index));
            }
            return View(teamDto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var subjectDtoToDelete = await _teamService.GetByIdAsync(id);
            return View(subjectDtoToDelete);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _teamService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
