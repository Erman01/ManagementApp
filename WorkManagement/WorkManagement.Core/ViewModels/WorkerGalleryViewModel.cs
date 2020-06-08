using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Core.Models;

namespace WorkManagement.Core.ViewModels
{
    public class WorkerGalleryViewModel
    {
        public WorkerGallery WorkerGallery { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
    }
}
