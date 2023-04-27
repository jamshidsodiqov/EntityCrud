using Project.Domain.Configuration;
using Project.Domain.Entities.Students;
using Project.Service.DTOs.Students;
using System.Linq.Expressions;

namespace Project.Service.Interfaces
{
    public interface IStudentService
    {
        ValueTask<IEnumerable<StudentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null);
        ValueTask<StudentForViewDTO> GetAsync(Expression<Func<Student, bool>> expression);
        ValueTask<StudentForViewDTO> CreateAsync(StudentForCreationDTO StudentForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<StudentForViewDTO> UpdateAsync(int id, StudentForUpdateDTO StudentForUpdateDTO);
    }
}
