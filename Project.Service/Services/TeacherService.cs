using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Data.DbContexts;
using Project.Data.IRepository;
using Project.Data.Repository;
using Project.Domain.Configuration;
using Project.Domain.Entities.Students;
using Project.Domain.Entities.Teachers;
using Project.Service.DTOs.Students;
using Project.Service.DTOs.Teachers;
using Project.Service.Exceptions;
using Project.Service.Extensions;
using Project.Service.Interfaces;
using Project.Service.Mappers;
using System.Linq.Expressions;

namespace Project.Service.Services
{
    public class TeacherService : ITeacherService
    {

        private readonly IGenericRepository<Teacher> genericRepository;
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public TeacherService()
        {
            genericRepository = new GenericRepository<Teacher>();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async ValueTask<TeacherForViewDTO> CreateAsync(TeacherForCreationDTO TeacherForCreationDTO)
        {
            var existTeacher = await genericRepository.GetAsync(e => e.Email == TeacherForCreationDTO.Email);

            if (existTeacher != null)
            {
                throw new ProjectException("This teacher created already");
            }
            var createdTeacher = await genericRepository.CreateAsync(mapper.Map<Teacher>(TeacherForCreationDTO));
            await genericRepository.SaveChangesAsync();

            return mapper.Map<TeacherForViewDTO>(createdTeacher);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var deletedteacher = await genericRepository.DeleteAsync(id);

            if (!deletedteacher)
            {
                throw new ProjectException("Teacher not found");
            }

            await genericRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IEnumerable<TeacherForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null)
        {
            var teachers = genericRepository.GetAll(expression, isTracking: false);

            return mapper.Map<IEnumerable<TeacherForViewDTO>>(await teachers.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<TeacherForViewDTO> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            var teacher = genericRepository.GetAsync(expression, isTracking: false);

            if (teacher == null)
                throw new ProjectException("Teacher not found");

            return mapper.Map<TeacherForViewDTO>(teacher);
        }

        public async ValueTask<TeacherForViewDTO> UpdateAsync(int id, TeacherForUpdateDTO TeacherForUpdateDTO)
        {
            var existTeacher = await genericRepository.GetAsync(s => s.Id == id);

            if (existTeacher == null)
                throw new ProjectException("404 Teacher not found");

            var Teacher = await genericRepository.GetAsync(s => s.Email == TeacherForUpdateDTO.Email && s.Id != id);

            if (Teacher != null)
                throw new ProjectException("This student already exist");

            existTeacher = genericRepository.UpdateAsync(mapper.Map<Teacher>(TeacherForUpdateDTO));

            await genericRepository.SaveChangesAsync();

            return mapper.Map<TeacherForViewDTO>(existTeacher);
        }
    }
}
