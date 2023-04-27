using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Data.DbContexts;
using Project.Data.IRepository;
using Project.Data.Repository;
using Project.Domain.Configuration;
using Project.Domain.Entities.Students;
using Project.Service.DTOs.Students;
using Project.Service.Exceptions;
using Project.Service.Extensions;
using Project.Service.Interfaces;
using Project.Service.Mappers;
using System.Linq.Expressions;

namespace Project.Service.Services
{

    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> genericRepository;
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public StudentService()
        {
            genericRepository = new GenericRepository<Student>();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }


        public async ValueTask<StudentForViewDTO> CreateAsync(StudentForCreationDTO studentForCreationDTO)
        {
            var existstudent = await genericRepository.GetAsync(e => e.Email == studentForCreationDTO.Email);

            if (existstudent != null)
            {
                throw new ProjectException("This student created already");
            }

            var createdstudent = await genericRepository.CreateAsync(mapper.Map<Student>(studentForCreationDTO));

            var existcourse = await genericRepository.GetAsync(c => c.Id == studentForCreationDTO.CourseId);

            if (existcourse == null)
                throw new ProjectException("Course not found");

            await genericRepository.SaveChangesAsync();

            return mapper.Map<StudentForViewDTO>(createdstudent);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var deletedstudent = await genericRepository.DeleteAsync(id);

            if (!deletedstudent)
            {
                throw new ProjectException("Student not found");
            }

            await genericRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IEnumerable<StudentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null)
        {
            var students = genericRepository.GetAll(expression, isTracking: false);

            return mapper.Map<IEnumerable<StudentForViewDTO>>(await students.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<StudentForViewDTO> GetAsync(Expression<Func<Student, bool>> expression)
        {
            var student = genericRepository.GetAsync(expression, isTracking: false);

            if (student == null)
            {
                throw new ProjectException("Student not found");
            }

            return mapper.Map<StudentForViewDTO>(student);
        }

        public async ValueTask<StudentForViewDTO> UpdateAsync(int id, StudentForUpdateDTO StudentForUpdateDTO)
        {
            var existstudent = await genericRepository.GetAsync(s => s.Id == id);

            if (existstudent == null)
                throw new ProjectException("404 Student not found");

            var student = await genericRepository.GetAsync(s => s.Email == StudentForUpdateDTO.Email && s.Id != id);

            if (student != null)
            {
                throw new ProjectException("This Student email already taken");
            }

            existstudent = genericRepository.UpdateAsync(mapper.Map<Student>(StudentForUpdateDTO));

            await genericRepository.SaveChangesAsync();

            return mapper.Map<StudentForViewDTO>(existstudent);

        }

    }
}
