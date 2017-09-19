using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpecFlowExamples.Controllers
{
    using SpecFlowExamples.Models;

    public class PersonController : Controller
    {
        private static List<Person> people;

        public PersonController()
        {
            people = new List<Person>();
        }

        // GET: Person
        public ActionResult Index()
        {
            var newPerson = (Person)TempData["newPerson"];
            if (newPerson != null)
            {
                ViewBag.TheResult = newPerson;
                ViewBag.Message = $"{newPerson.FirstName} {newPerson.LastName} successful created";
            }

            return View(people);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                people.Add(person);
                TempData["newPerson"] = person;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
