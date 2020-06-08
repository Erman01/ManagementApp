using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Core.Models
{
    public class Worker : BaseEntity
    {
        public Worker()
        {
           
            WorkerImageGalleries = new List<WorkerGallery>();
            WorkerImages = new List<WorkerImage>();
        }
        [Key]
        public int WorkerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public short Salary { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        [Display(Name = "Image")]
        public string WorkerImageUrl { get; set; }
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<WorkerGallery> WorkerImageGalleries { get; set; }
        public virtual ICollection<WorkerImage> WorkerImages { get; set; }


    }

}
