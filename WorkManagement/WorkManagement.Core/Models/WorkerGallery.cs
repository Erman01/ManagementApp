using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Core.Models
{
    public class WorkerGallery : BaseEntity
    {
        public WorkerGallery()
        {
            WorkerImages = new List<WorkerImage>();
        }
        [Key]
        public int WorkerImageGalleryId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryUrl { get; set; }
        [Display(Name = "Worker Name")]
        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }
        public virtual ICollection<WorkerImage> WorkerImages { get; set; }

    }
}
