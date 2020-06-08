using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkManagement.Core.Contracts;
using WorkManagement.Core.Models;

namespace WorkManagement.MVCUI.Controllers
{
    public class DepartmentManagerController : Controller
    {
        IRepository<Department> _departmentRepository;
        IRepository<Worker> _workerRepository;
        public DepartmentManagerController(IRepository<Department> departmentRepository, IRepository<Worker> workerRepository)
        {
            _departmentRepository = departmentRepository;
            _workerRepository = workerRepository;
        }
        public ActionResult Index()
        {
            List<Department> departments = _departmentRepository.Collection().ToList();

            return View(departments);
        }
        public ActionResult Details(int id)
        {
            Department department = _departmentRepository.Find(id);
            if (department==null)
            {
                return HttpNotFound();
            }
            else
            {
                List<Worker> workerListByDepartment = _workerRepository.Collection().Where(x => x.DepartmentId == department.DepartmentId).ToList();
                return View(workerListByDepartment);
            }
           
        }
        public ActionResult Create()
        {
            Department department = new Department();

            return View(department);
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            else
            {
                _departmentRepository.Insert(department);
                _departmentRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int Id)
        {
            Department departmentToEdit = _departmentRepository.Find(Id);
            if (departmentToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(departmentToEdit);
            }

        }
        [HttpPost]
        public ActionResult Edit(int Id, Department department)
        {
            Department departmentToEdit = _departmentRepository.Find(Id);
            if (departmentToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                departmentToEdit.DepartmentName = department.DepartmentName;
                _departmentRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int Id)
        {
            Department department = _departmentRepository.Find(Id);
            if (department == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(department);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Department departmentToDelete = _departmentRepository.Find(Id);
            if (departmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _departmentRepository.Delete(Id);
                _departmentRepository.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}