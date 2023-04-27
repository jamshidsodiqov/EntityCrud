using AutoMapper;
using Project.Domain.Entities.Courses;
using Project.Domain.Entities.Students;
using Project.Domain.Entities.Teachers;
using Project.Service.DTOs.Courses;
using Project.Service.DTOs.Students;
using Project.Service.DTOs.Teachers;

namespace Project.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentForCreationDTO>().ReverseMap();
            CreateMap<Student, StudentForUpdateDTO>().ReverseMap();
            CreateMap<Student, StudentForViewDTO>().ReverseMap();

            CreateMap<Teacher, TeacherForCreationDTO>().ReverseMap();
            CreateMap<Teacher, TeacherForUpdateDTO>().ReverseMap();
            CreateMap<Teacher, TeacherForViewDTO>().ReverseMap();

            CreateMap<Course, CourseForCreationDTO>().ReverseMap();
            CreateMap<Course, CourseForUpdateDTO>().ReverseMap();
            CreateMap<Course, CourseForViewDTO>().ReverseMap();
        }
    }
}
