using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Entities;

namespace ProjectManager.DataAccess
{
    public class ProjectManagerDBContext : DbContext
    {
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Entity<TaskDetail>()
                .HasRequired(d => d.User)
                .WithMany(w => w.TaskDetails)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Project>()
            //    .HasRequired(d => d.User)
            //    .WithMany(w => w.TaskDetails)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        public ProjectManagerDBContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
