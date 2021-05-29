using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeManagementSystem.BL.Abstraction;
using TimeManagementSystem.BL.DTO;
using TimeManagementSystem.Data.Implementation;

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
            var subjectDtoToEdit = await _projectService.GetByIdAsync(id);
            return View(subjectDtoToEdit);
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
