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

        private ProjectEntityRepository _repo = new ProjectEntityRepository();

        public ActionResult Index()
        {
            var projectModels = new List<ProjectModel>();

            var projects = _repo.GetAllProjects();

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
            var project = _repo.GetProjectById(id);

            var projectModel = new ProjectModel { Id = project.Id, Name = project.Name, Description = project.Description };
            return View(projectModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string description)
        {
            _repo.EditProject(id, name, description);
            return RedirectToAction("Index");
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string description)
        {
            var project = new Project
            {
                Name = name,
                Description = description
            };
            _repo.CreateNewProject(project);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repo.RemoveProject(id);
            return RedirectToAction("Index");
        }
    }
}
