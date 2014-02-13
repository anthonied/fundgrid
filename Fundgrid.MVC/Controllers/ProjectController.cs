using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fundgrid.MVC.Models;
using FundGrid.Repository;
using FunGrid.Domain;
using SolutionServerWebSession;

namespace Fundgrid.MVC.Controllers
{
    public class ProjectController : Controller
    {
        private MenuBase _menubase = new MenuBase();

        public ActionResult Index()
        {
            using (var projectRepository = new ProjectRepository())
            {
                var indexModel = new IndexModel();
                var projectModels = new List<ProjectModel>();
                var projects = projectRepository.GetSpecificProjects();
                projects.ForEach(project => projectModels.Add(new ProjectModel
                {
                    Id = project.Id,
                    Description = project.Description,
                    Name = project.Name
                }));
                indexModel.ProjectModels = projectModels;
                return View(indexModel);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var projectRepository = new ProjectRepository())
            {
                var editModel = new EditModel();
                var project = projectRepository.GetProject(id, Status.active);
                editModel.ProjectModel = new ProjectModel { Id = project.Id, Name = project.Name, Description = project.Description };
                return View(editModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string description)
        {
            using (var projectRepository = new ProjectRepository())
            {
                projectRepository.EditProject(id, name, description);
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult Create()
        {
            var createModel = new CreateModel();

            return View(createModel);
        }

        public ActionResult Details(int id)
        {
            using (var projectRepository = new ProjectRepository())
            {
                var detailsModel = new DetailsModel();
                detailsModel.Project = projectRepository.GetProject(id, Status.active);
                return View(detailsModel);
            }
        }

        public ActionResult ArchiveProject(int id)
        {
            using (var projectRepository = new ProjectRepository())
            {
                var project = projectRepository.GetProject(id, Status.archived);
                return View(project);
            }
        }

        public ActionResult Archive(int id)
        {
            using (var projectRepository = new ProjectRepository())
            {
                using (var gridRepository = new GridRepository())
                {
                    var selectedProject = projectRepository.GetProject(id, Status.archived);
                    var archiveModel = new ArchiveModel();
                    var gridModel = new GridModel();

                    gridModel.ProjectName = selectedProject.Name;
                    gridModel.ProjectDescription = selectedProject.Description;
                    gridModel.Grids = gridRepository.GetArchivedGridsByProjectId(id);

                    archiveModel.GridModel = gridModel;
                    return View(gridModel);
                }
            }
        }


        [HttpPost]
        public JsonResult Create(string name, string description)
        {
            using (var projectRepository = new ProjectRepository())
            {
                var project = new Project
                {
                    Name = name,
                    Description = description
                };
                projectRepository.CreateNewProject(project);
                var data = new { isOk = true, errorMessage = "Entry not added." };
                return new JsonResult { Data = data };
            }
        }

        public ActionResult Delete(int id)
        {
            using (var projectRepository = new ProjectRepository())
            {
                projectRepository.RemoveProject(id);
                return RedirectToAction("Index");
            }
        }

        [AllowAnonymous]
        public JsonResult CreateGrid(int projectId, int gridDimensionRows, int gridDimensionColumns, decimal gridValue, decimal incrementValue, string gridName, string gridDescription)
        {
            using (var gridRepository = new GridRepository())
            {
                var isEntryAdded = gridRepository.CreateNewGrid(projectId, gridDimensionRows, gridDimensionColumns, gridValue, incrementValue, gridName, gridDescription);
                var data = new { isOk = isEntryAdded, errorMessage = "Entry not added." };
                return new JsonResult { Data = data };
            }
        }

        [HttpPost]
        public JsonResult AddGridItem(int donateId, int gridId, int gridItemNumber, string gridItemOwner, decimal gridItemAmount)
        {
            var _paymentrepository = new PaymentRepository()
            {
                ConfirmationUrl = "http://localhost:58150/Project/Donate/",
                CancelUrl = "http://localhost:58150/Project/DonateDetails/" + donateId
            };
            var redirectURL = _paymentrepository.PayUsingPaypal(gridItemAmount);

            return new JsonResult { Data = redirectURL };

            //_projectRepository.AssignItemToGrid(gridId, gridItemNumber, gridItemOwner, gridItemAmount);
            //return RedirectToAction("Donate");
        }

        [HttpPost]
        public ActionResult DeleteGrid(int gridId)
        {
            using (var gridRepository = new GridRepository())
            {
                gridRepository.RemoveGrid(gridId);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ArchiveGrid(int gridId)
        {
            using (var gridRepository = new GridRepository())
            {
                gridRepository.ArchiveGrid(gridId);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Donate()
        {
            using (var projectRepository = new ProjectRepository())
            {
                var donateModel = new DonateModel();
                var projectModels = new List<ProjectModel>();
                var projects = projectRepository.GetAllProjects();
                projects.ForEach(project => projectModels.Add(new ProjectModel
                {
                    Id = project.Id,
                    Description = project.Description,
                    Name = project.Name
                }));
                donateModel.ProjectModels = projectModels;
                return View(donateModel);
            }
        }

        public ActionResult DonateDetails(int id)
        {
            using (var projectRepository = new ProjectRepository())
            {
                var project = projectRepository.GetProject(id, Status.active);
                var donateProjectModel = new DonateProjectModel
                            {
                                Id = project.Id,
                                Description = project.Description,
                                Grid = project.Grid,
                                Name = project.Name,
                                //Owner_Id = project.Owner_Id
                            };
                return View(donateProjectModel);
            }
        }
    }
}
