using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_HW2.DataAccess;
using Entity_HW2.Models;

namespace Entity_HW2
{
    class AcademyDbContext : DbContext
    {
        public AcademyDbContext() //: base("MyAcademyDB")
        {
            Database.SetInitializer(new AcademyDBInitializer());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestWork> TestWorks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Students");
            modelBuilder.Entity<Question>()
                .Property(p => p.Text)
                .IsRequired();
        }
    }
}
