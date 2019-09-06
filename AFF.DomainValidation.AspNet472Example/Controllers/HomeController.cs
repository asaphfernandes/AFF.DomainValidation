﻿using AFF.DomainValidation.AspNet472Example.Models;
using AFF.DomainValidation.AspNet472Example.Services;
using System.Web.Mvc;

namespace AFF.DomainValidation.AspNet472Example.Controllers
{
    public class HomeController : Controller
    {
        private static ServicePerson Service { get; } = new ServicePerson { };

        [HttpGet]
        public ActionResult Index() => View(Service.Get());

        [HttpGet]
        public ActionResult Details(int id) => View(Service.Get(id));

        [HttpGet]
        public ActionResult Create() => View(new ResponseModel<PersonModel> { Model = new PersonModel { } });

        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            return View(Service.Add(model));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new ResponseModel<PersonModel> { Model = new PersonModel { } });
        }

        [HttpPost]
        public ActionResult Edit(PersonModel model)
        {
            return View(new ResponseModel<PersonModel> { Model = new PersonModel { } });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new ResponseModel<PersonModel> { Model = new PersonModel { } });
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            return View(new ResponseModel<PersonModel> { Model = new PersonModel { } });
        }
    }
}