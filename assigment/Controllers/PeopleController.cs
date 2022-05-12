﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleAssignment.Models;

namespace assigment.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public ActionResult Index()
        {
            var model = _peopleService.GetPeoples();
            return View(model);
        }

        public PartialViewResult All()
        {
            var model = _peopleService.GetPeoples();
            return PartialView("_PersionPartial", model);
        }

        public PartialViewResult info(int id)
        {
            var model = _peopleService.FindPerson(id);
            return PartialView("_PersonInfo", model);
        }

        public ActionResult Details(int id)
        {
            var Person = _peopleService.FindPerson(id);
            if (Person == null)
            {
                return NotFound();
            }
            return View(Person);
        }

        public ActionResult Search(string search)
        {
            var Person = _peopleService.SearchPerson(search);
            if (Person == null)
            {
                return NotFound();
            }
            return View(Person);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }
                _peopleService.CreatePerson(person);
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Person person)
        {
            try
            {
                _peopleService.DeletePerson(person);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}