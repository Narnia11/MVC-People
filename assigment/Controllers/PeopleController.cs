using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using assignment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host;
using Microsoft.AspNetCore.Authorization;

namespace assigment.Controllers
{
    [Authorize]

    public class PeopleController : Controller
    {
        private IPeopleService _peopleService;
        private assignment.Models.ILanguageService _languageService;
        private IPersonLanguageService _PersonlanguageService;
        private ICityService _cityService;

        public PeopleController(IPeopleService peopleService, assignment.Models.ILanguageService languageService, IPersonLanguageService PersonlanguageService, ICityService cityService)
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _PersonlanguageService = PersonlanguageService;
            _cityService = cityService;
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
            if (string.IsNullOrEmpty(search))
                return RedirectToAction(nameof(Index));

            var Person = _peopleService.SearchPerson(search);
            if (Person == null)
            {
                return NotFound();
            }
            return View(Person);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var cities = _cityService.GetCities();
            ViewData["cities"] = new SelectList(cities.Select(a =>
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                }).ToList(), "Value", "Text");

            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }
                var city = _cityService.FindCity(model.CityId);
                Person person = new Person() { City = city, PersonName = model.PersonName, PersonPhoneNumber = model.PersonPhoneNumber };
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

            return View(_peopleService.FindPerson(id));
        }

        public ActionResult AddLanguageToPerson(int personId)
        {

            AddPersonLanguageViewModel model = new AddPersonLanguageViewModel()
            {
                PersonId = personId,
                Languages = _languageService.GetLanguages()


            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLanguageToPerson(PersonLanguage personLanguage)
        {
            try
            {


                _PersonlanguageService.CreatePersonLanguage(new PersonLanguage() { LanguageId = personLanguage.LanguageId, PersonId = personLanguage.PersonId });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowPersonLanguages(int personId)
        {
            List<Language> languages = new List<Language>();
            var personLanguages = _PersonlanguageService.GetPersonLanguages(personId);
            foreach (var item in personLanguages)
            {
                Language lng = _languageService.FindLanguage(item.LanguageId);
                languages.Add(lng);

            }
            return View(personLanguages.Select(x => x.Language).ToList());
        }


        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person model)
        {
            try
            {

                Person person = _peopleService.FindPerson(id);
                if (person != null)
                {
                    person.City = model.City;
                    person.PersonName = model.PersonName;
                    person.PersonPhoneNumber = model.PersonPhoneNumber;
                }
                _peopleService.UpdatePerson(person);
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