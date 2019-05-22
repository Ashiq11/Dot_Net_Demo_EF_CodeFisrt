using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemo.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepository repo = new DepartmentRepository();
        
        public ActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            if(ModelState.IsValid)
            {
                this.repo.Insert(dept);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dept);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                this.repo.Update(dept);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dept);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(this.repo.Get(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(this.repo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}