using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Core.Models;

namespace WorkManagement.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerGallery> WorkerImageGalleries { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
