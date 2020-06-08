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
    public class WorkerGalleryManagerController : Controller
    {
        IRepository<WorkerGallery> _workerGalleryRepository;
        IRepository<Worker> _workerRepository;
      
        public WorkerGalleryManagerController(IRepository<WorkerGallery> workerImageGalleryRepository, IRepository<Worker> workerRepository)
        {
            _workerGalleryRepository = workerImageGalleryRepository;
            _workerRepository = workerRepository;
          
        }
        public ActionResult Index()
        {
            List<WorkerGallery> listOfGallery = _workerGalleryRepository.Collection().ToList();

            return View(listOfGallery);
        }
       
        public ActionResult Create()
        {
            WorkerGalleryViewModel viewModel = new WorkerGalleryViewModel()
            {
                WorkerGallery = new WorkerGallery(),
                Workers = _workerRepository.Collection().ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(WorkerGallery workerGallery, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(workerGallery);
            }
            else
            {
                if (file != null)
                {
                    workerGallery.GalleryUrl = workerGallery.WorkerImageGalleryId+ Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//Galleries//") + workerGallery.GalleryUrl);
                }
                _workerGalleryRepository.Insert(workerGallery);
                _workerGalleryRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int Id)
        {
            WorkerGallery galleryToEdit = _workerGalleryRepository.Find(Id);
            if (galleryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                WorkerGalleryViewModel viewModel = new WorkerGalleryViewModel();
                viewModel.Workers = _workerRepository.Collection().ToList();
                viewModel.WorkerGallery = galleryToEdit;

                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, WorkerGallery gallery, HttpPostedFileBase file)
        {
            WorkerGallery galleryToEdit = _workerGalleryRepository.Find(id);
            if (galleryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(galleryToEdit);
                }
                if (file != null)
                {
                    gallery.GalleryUrl = gallery.WorkerImageGalleryId + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//Galleries//") + gallery.GalleryUrl);
                }
                galleryToEdit.GalleryName = gallery.GalleryName;
                galleryToEdit.WorkerId = gallery.WorkerId;
                
                _workerGalleryRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int Id)
        {
            WorkerGallery gallery = _workerGalleryRepository.Find(Id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(gallery);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            WorkerGallery galleryToDelete = _workerGalleryRepository.Find(Id);
            if (galleryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _workerGalleryRepository.Delete(Id);
                _workerGalleryRepository.Commit();

                return RedirectToAction("Index");
            }
        }

    }
}