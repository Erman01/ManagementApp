using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkManagement.Core.Contracts;
using WorkManagement.Core.Models;

namespace WorkManagement.MVCUI.Controllers
{
    public class WorkerImageManagerController : Controller
    {
        IRepository<Worker> _workerRepository;
        IRepository<WorkerImage> _workerImageRepository;
        IRepository<WorkerGallery> _workerGalleryRepository;
        public WorkerImageManagerController(IRepository<Worker> workerRepository, IRepository<WorkerImage> workerImageRepository,IRepository<WorkerGallery> workerGalleryRepository)
        {
            _workerRepository = workerRepository;
            _workerImageRepository = workerImageRepository;
            _workerGalleryRepository = workerGalleryRepository;
        }
        public ActionResult Index()
        {
            List<WorkerImage> imageList = _workerImageRepository.Collection().ToList();

            return View(imageList);
        }
        
    }
}