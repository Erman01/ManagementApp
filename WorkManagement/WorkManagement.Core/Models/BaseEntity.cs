using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Core.Models
{
    public class BaseEntity
    {
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now.Date;
        }
    }
}
