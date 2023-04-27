using Project.Data.DbContexts;
using Project.Data.IRepository;
using Project.Domain.Entities.Courses;
using Project.Domain.Entities.Students;
using Project.Domain.Entities.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Course> Courses { get; set; }
        public IGenericRepository<Student> Students { get; set; }
        public IGenericRepository<Teacher> Teachers { get; set; }

        public readonly AppDbContext dbContext;

        public UnitOfWork()  
        {
            dbContext = new AppDbContext();
            Courses = new GenericRepository<Course>();
            Students = new GenericRepository<Student>();
            Teachers = new GenericRepository<Teacher>(); 
        }

        public async ValueTask SaveChangesAsync()
            => await dbContext.SaveChangesAsync();


    }
}
