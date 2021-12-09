using EmployeesData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Controllers
{
    public class PersonController : Controller
    {
        public readonly DBFirstContext _dBFirstContext;
        public PersonController(DBFirstContext dBFirstContext)
        {
            _dBFirstContext = dBFirstContext;
        }

        public async Task<IActionResult> Index()
        {
                return View(await _dBFirstContext.People.ToListAsync());
        }
       
        public async Task<IActionResult> Details(int id)
        {
            Person people=  await _dBFirstContext.People.FirstOrDefaultAsync(p=>p.Id==id);
            if (people == null) 
                return NotFound();
            else
                return View(people);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person model)
        {
            if (ModelState.IsValid) { 
                Person newPerson = new Person
                {
                   Name= model.Name,
                   Address=model.Address,
                   Age=model.Age,
                   Contact=model.Contact
                };
                _dBFirstContext.People.Add(newPerson);
                _dBFirstContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
              return View();
            
        }

        // GET: PersonController/Edit/5
        public IActionResult Edit(int id)
        {
            Person people =  _dBFirstContext.People.FirstOrDefault(p => p.Id == id);
            Person editpeople = new Person
            {
                Name = people.Name,
                Address = people.Address,
                Age = people.Age,
                Contact = people.Contact
            };
            return View(editpeople);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person model)
        {
            if (ModelState.IsValid)
            {
                Person people = _dBFirstContext.People.FirstOrDefault(p => p.Id ==model.Id);
                people.Name = model.Name;
                people.Address = model.Address;
                people.Age = model.Age;
                people.Contact = model.Contact;
                _dBFirstContext.People.Update(people);
                _dBFirstContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            Person people = _dBFirstContext.People.FirstOrDefault(p => p.Id == id);
            return View(people);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person person)
        {
            try
            {
                Person people = _dBFirstContext.People.FirstOrDefault(p => p.Id == person.Id);
                _dBFirstContext.Remove(people);
                _dBFirstContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
