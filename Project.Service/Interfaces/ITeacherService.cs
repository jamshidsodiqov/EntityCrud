using Project.Domain.Configuration;
using Project.Domain.Entities.Teachers;
using Project.Service.DTOs.Teachers;
using System.Linq.Expressions;

namespace Project.Service.Interfaces
{
    public interface ITeacherService
    {
        ValueTask<IEnumerable<TeacherForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null);
        ValueTask<TeacherForViewDTO> GetAsync(Expression<Func<Teacher, bool>> expression);
        ValueTask<TeacherForViewDTO> CreateAsync(TeacherForCreationDTO TeacherForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<TeacherForViewDTO> UpdateAsync(int id, TeacherForUpdateDTO TeacherForUpdateDTO);
    }
}
