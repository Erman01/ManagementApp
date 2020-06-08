using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkManagement.Core.Contracts;
using WorkManagement.Core.Models;
using WorkManagement.Core.ViewModels;

namespace WorkManagement.MVCUI.Controllers
{
    public class WorkerManagerController : Controller
    {
        IRepository<Worker> _workerRepository;
        IRepository<Department> _departmentRepository;
        public WorkerManagerController(IRepository<Worker> workerRepository, IRepository<Department> departmentRepository)
        {
            _workerRepository = workerRepository;
            _departmentRepository = departmentRepository;
        }
        // GET: WorkerManeger
        public ActionResult Index()
        {
            List<Worker> workerList = _workerRepository.Collection().ToList();

            return View(workerList);
        }
        public ActionResult Details(int Id)
        {
            Worker worker = _workerRepository.Find(Id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(worker);
            }
        }
        public ActionResult Create()
        {
            WorkerViewModel viewModel = new WorkerViewModel()
            {
                Worker = new Worker(),
                Departments = _departmentRepository.Collection().ToList()
            };
            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Create(Worker worker, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(worker);
            }
            else
            {
                if (file != null)
                {
                    worker.WorkerImageUrl = worker.WorkerId + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//WorkerProfileImages//") + worker.WorkerImageUrl);
                }
                _workerRepository.Insert(worker);
                _workerRepository.Commit();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Edit(int Id)
        {
            Worker workerToEdit = _workerRepository.Find(Id);
            if (workerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                WorkerViewModel viewModel = new WorkerViewModel()
                {
                    Worker = workerToEdit,
                    Departments = _departmentRepository.Collection().ToList()
                };
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(int Id, Worker worker, HttpPostedFileBase file)
        {
            Worker workerToEdit = _workerRepository.Find(Id);
            if (workerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(workerToEdit);
                }
                if (file != null)
                {
                    workerToEdit.WorkerImageUrl = worker.WorkerId + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//WorkerProfileImages//") + workerToEdit.WorkerImageUrl);
                }
                workerToEdit.FirstName = worker.FirstName;
                workerToEdit.LastName = worker.LastName;
                workerToEdit.Salary = worker.Salary;
                workerToEdit.DateOfBirth = worker.DateOfBirth;
                workerToEdit.DepartmentId = worker.DepartmentId;
                workerToEdit.Gender = worker.Gender;


                _workerRepository.Commit();

                return RedirectToAction("Index");

            }
        }
        public ActionResult Delete(int Id)
        {
            Worker worker = _workerRepository.Find(Id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(worker);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDeleted(int Id)
        {
            Worker workerToDelete = _workerRepository.Find(Id);
            if (workerToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _workerRepository.Delete(Id);
                _workerRepository.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}