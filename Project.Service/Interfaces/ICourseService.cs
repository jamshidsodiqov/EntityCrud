using Project.Domain.Configuration;
using Project.Domain.Entities.Courses;
using Project.Service.DTOs.Courses;
using System.Linq.Expressions;

namespace Project.Service.Interfaces
{
    public interface ICourseService
    {
        ValueTask<IEnumerable<CourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
        ValueTask<CourseForViewDTO> GetAsync(Expression<Func<Course, bool>> expression);
        ValueTask<CourseForViewDTO> CreateAsync(CourseForCreationDTO CourseForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<CourseForViewDTO> UpdateAsync(int id, CourseForUpdateDTO CourseForUpdateDTO);
    }
}
