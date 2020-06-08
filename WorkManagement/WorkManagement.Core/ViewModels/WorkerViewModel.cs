using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Core.Models;

namespace WorkManagement.Core.ViewModels
{
    public class WorkerViewModel
    {
        public Worker Worker { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
