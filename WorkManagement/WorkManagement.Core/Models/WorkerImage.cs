using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Core.Models
{
    public class WorkerImage:BaseEntity
    {
        public int WorkerImageId { get; set; }
        [Display(Name ="Name")]
        public string ImageName { get; set; }
        [Display(Name ="Image")]
        public string ImageUrl { get; set; }
        [Display(Name ="Gallery")]
        public int WorkerImageGalleryId { get; set; }
        [ForeignKey("WorkerImageGalleryId")]
        public virtual WorkerGallery WorkerGallery { get; set; } 
        [Display(Name ="Worker")]
        public int? WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }
    }
}
