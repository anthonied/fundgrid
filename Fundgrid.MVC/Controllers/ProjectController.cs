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
        private MenuBase _menuBase = new MenuBase();
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
            var project = _projectRepository.GetProject(id, Status.active);

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
            var project = _projectRepository.GetProject(id, Status.active);
            return View(project);
        }

        public ActionResult ArchiveProject(int id)
        {
            var project = _projectRepository.GetProjectByGridId(id, Status.archived);
            return View(project);
        }

        public ActionResult Archive(int id)
        {
            var selectedProject = _projectRepository.GetProject(id, Status.archived);
            var gridModel = new GridModel();

            gridModel.ProjectName = selectedProject.Name;
            gridModel.ProjectDescription = selectedProject.Description;
            gridModel.Grids = _projectRepository.GetArchivedGridsForProject(id);

            return View(gridModel);
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

        [AllowAnonymous]
        public JsonResult CreateGrid(int projectId, int gridDimensionRows, int gridDimensionColumns, decimal gridValue, decimal incrementValue, string gridName, string gridDescription)
        {
            var isEntryAdded = _projectRepository.CreateNewGrid(projectId, gridDimensionRows, gridDimensionColumns, gridValue, incrementValue, gridName, gridDescription);
            var data = new { isOk = isEntryAdded, errorMessage = "Entry not added." };
            return new JsonResult { Data = data };
        }

        [HttpPost]
        public ActionResult AddGridItem(int gridId, int gridItemNumber, string gridItemOwner, decimal gridItemAmount)
        {
            _projectRepository.AssignItemToGrid(gridId, gridItemNumber, gridItemOwner, gridItemAmount);
            return RedirectToAction("Donate");
        }

        [HttpPost]
        public ActionResult DeleteGrid(int gridId)
        {
            _projectRepository.RemoveGrid(gridId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ArchiveGrid(int gridId)
        {
            _projectRepository.ArchiveGrid(gridId);
            return RedirectToAction("Index");
        }

        public ActionResult Donate()
        {
            var donateModel = new DonateModel();
            var projectModels = new List<ProjectModel>();

            var projects = _projectRepository.GetAllProjects();

            projects.ForEach(project => projectModels.Add(new ProjectModel
            {
                Id = project.Id,
                Description = project.Description,
                Name = project.Name
            }));

            donateModel.ProjectModels = projectModels;
            return View(donateModel);  
        }

        public ActionResult DonateDetails(int id)
        {
            var project = _projectRepository.GetProject(id, Status.active);
            var donateProjectModel = new DonateProjectModel
        {
            Id =project.Id,
            Description = project.Description,
            Grid = project.Grid,
            Name = project.Name,
            Owner_Id = project.Owner_Id
        };
            return View(donateProjectModel); 
        }
    }
}
