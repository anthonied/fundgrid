﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fundgrid.MVC.Models;
//using Models;

namespace Fundgrid.MVC.Controllers
{
    public class HomeController : BootstrapBaseController
    {
        private MenuBase _menuBase = new MenuBase();
        
        public ActionResult Index()
        {
            var model = new HomeModel();            
            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult SendMessage(string fullName, string email, string message)
        {
            var data = new
            {
                isOk = false,
                errorMessage = "TO DO",

                fullName = fullName,
                email = email,
                message = message,
            };
            return new JsonResult { Data = data };
        }

        /*private static List<HomeInputModel> _models = ModelIntializer.CreateHomeInputModels();
        public ActionResult Index()
        {

            var homeInputModels = _models;                                      
            return View(homeInputModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Create(HomeInputModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _models.Count==0?1:_models.Select(x => x.Id).Max() + 1;
                _models.Add(model);
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new HomeInputModel());
        }

        public ActionResult Delete(int id)
        {
            _models.Remove(_models.Get(id));
            Information("Your widget was deleted");
            if(_models.Count==0)
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var model = _models.Get(id);
            return View("Create", model);
        }

        [HttpPost]        
        public ActionResult Edit(HomeInputModel model,int id)
        {
            if(ModelState.IsValid)
            {
                _models.Remove(_models.Get(id));
                model.Id = id;
                _models.Add(model);
                Success("The model was updated!");
                return RedirectToAction("index");
            }
            return View("Create", model);
        }

        public ActionResult Details(int id)
        {
            var model = _models.Get(id);
            return View(model);
        }*/
    }
}
