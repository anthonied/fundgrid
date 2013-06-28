using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fundgrid.MVC.Models;
using FundGrid.Repository;
using FunGrid.Domain;

namespace Fundgrid.MVC.Controllers
{
    public class ProjectController : Controller
    {

        private ProjectRepository _projectRepository = new ProjectRepository();

        public ActionResult Index()
        {
            var projectModels = new List<ProjectModel>();

            var projects = _projectRepository.GetAllProjects();

            projects.ForEach(project => projectModels.Add(new ProjectModel
            {
                Id = project.Id,
                Description = project.Description,
                Name = project.Name
            }));
            return View(projectModels);          
        }

       
        public ActionResult Edit(int id)
        {
            var project = _projectRepository.GetProjectById(id);

            var projectModel = new ProjectModel { Id = project.Id, Name = project.Name, Description = project.Description };
            return View(projectModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string description)
        {
            _projectRepository.EditProject(id, name, description);
            return RedirectToAction("Index");
        }

        
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(string name, string description)
        {
            var project = new Project
            {
                Name = name,
                Description = description
            };
            _projectRepository.CreateNewProject(project);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _projectRepository.RemoveProject(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult UpdateGrid(int projectId, int gridId, int gridItemNumber, string gridItemOwner, decimal gridItemAmount)
        {
            var isEntryUpdated = _projectRepository.updateGridForProject(projectId, gridId, gridItemNumber, gridItemOwner, gridItemAmount);
            var data = new { isOk = isEntryUpdated, errorMessage = "No entry was updated" };
            return new JsonResult {Data = data};
        }

        [AllowAnonymous]
        public JsonResult CreateGrid(int projectId, int gridDimensionRows, int gridDimensionColumns)
        {
            var isEntryAdded = _projectRepository.CreateGridForProject(projectId, gridDimensionRows, gridDimensionColumns);
            var data = new { isOk = isEntryAdded, errorMessage = "Entry not added." };
            return new JsonResult { Data = data };
        }

        /*[AllowAnonymous]
        public ActionResult BuyGridItem()
        {
            var isEntryAdded = _projectRepository.AssignItemToGrid(1, 1, "Phillip", 1000.50m);
            var data = new { isOk = isEntryAdded, errorMessage = "Entry not added." };

            return new JsonResult { Data = data };
        }*/
    }
}
