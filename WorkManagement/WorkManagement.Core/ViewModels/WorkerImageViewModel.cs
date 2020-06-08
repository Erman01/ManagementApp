using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Core.Models;

namespace WorkManagement.Core.ViewModels
{
    public class WorkerImageViewModel
    {
        public WorkerImage WorkerImage { get; set; }
        public IEnumerable<WorkerGallery> WorkerGalleries { get; set; }
    }
}
