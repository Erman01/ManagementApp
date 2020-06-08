using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Core.Models
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Workers = new List<Worker>();
        }
        [Key]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
