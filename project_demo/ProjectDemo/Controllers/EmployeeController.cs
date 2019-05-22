using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository repo = new EmployeeRepository();

        public ActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            // creating a dropdownlist of departments
            // can also be done in the view
            DepartmentRepository deptRepo = new DepartmentRepository();
            List<SelectListItem> deptList = new List<SelectListItem>(); // a list of selectable items

            foreach (Department dept in deptRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = dept.Name;
                option.Value = dept.Id.ToString();

                deptList.Add(option);
            }

            // sending the list to view through ViewBag
            ViewBag.Departments = deptList;
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                this.repo.Insert(emp);
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee emp = this.repo.Get(id);

            // creating a dropdownlist of departments
            // can also be done in the view
            DepartmentRepository deptRepo = new DepartmentRepository();
            List<SelectListItem> deptList = new List<SelectListItem>(); // a list of selectable items

            foreach (Department dept in deptRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = dept.Name;
                option.Value = dept.Id.ToString();
                if(dept.Id == emp.DepartmentId)
                {
                    option.Selected = true;
                }
                deptList.Add(option);
            }

            // sending the list to view through ViewBag
            ViewBag.Departments = deptList;

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                this.repo.Update(emp);
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
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