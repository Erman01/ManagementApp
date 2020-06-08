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
    public class WorkerImageManagerController : Controller
    {
        IRepository<WorkerImage> _workerImageRepository;
        IRepository<WorkerGallery> _workerGalleryRepository;
        public WorkerImageManagerController(IRepository<WorkerImage> workerImageRepository, IRepository<WorkerGallery> workerRepository)
        {
            _workerImageRepository = workerImageRepository;
            _workerGalleryRepository = workerRepository;
        }
        public ActionResult Index()
        {
            List<WorkerImage> listOfImage = _workerImageRepository.Collection().ToList();

            return View(listOfImage);
        }
        public ActionResult Create()
        {
            WorkerImageViewModel viewModel = new WorkerImageViewModel()
            {
                WorkerImage = new WorkerImage(),
                WorkerGalleries = _workerGalleryRepository.Collection().ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(WorkerImage workerImage, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(workerImage);
            }
            else
            {
                if (file != null)
                {
                    workerImage.ImageUrl = workerImage.WorkerImageId + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//Images//") + workerImage.ImageUrl);
                }
                _workerImageRepository.Insert(workerImage);
                _workerImageRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int Id)
        {
            WorkerImage ImageToEdit = _workerImageRepository.Find(Id);
            if (ImageToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                WorkerImageViewModel viewModel = new WorkerImageViewModel()
                {
                    WorkerImage = new WorkerImage(),
                    WorkerGalleries = _workerGalleryRepository.Collection().ToList()
                };
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, WorkerImage workerImage, HttpPostedFileBase file)
        {
            WorkerImage ImageToEdit = _workerImageRepository.Find(id);
            if (ImageToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(ImageToEdit);
                }
                if (file != null)
                {
                    workerImage.ImageUrl = workerImage.WorkerImageId+ Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//Galleries//") + workerImage.ImageUrl);
                }
                ImageToEdit.ImageName = workerImage.ImageName;
                ImageToEdit.WorkerImageGalleryId = workerImage.WorkerImageGalleryId;
                _workerImageRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int Id)
        {
            WorkerImage workerImage = _workerImageRepository.Find(Id);
            if (workerImage == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(workerImage);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            WorkerImage ImageToDelete = _workerImageRepository.Find(Id);
            if (ImageToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _workerImageRepository.Delete(Id);
                _workerImageRepository.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}