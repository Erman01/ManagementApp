using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Core.Models
{
    public class WorkerImage : BaseEntity
    {
        [Key]
        public int WorkerImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int WorkerImageGalleryId { get; set; }

        [ForeignKey("WorkerImageGalleryId")]
        public virtual WorkerGallery WorkerGallery { get; set; }
    }

}
