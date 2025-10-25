using API_1404.Application.DTO;

namespace API_1404.Application;

public interface IStudentService
{
    Task<StudentCreation?> CreateAsync(StudentCreation student);
     Task<StudentDetails>? GetById(int id);
    Task Delete(int id);
    Task UpdateAsync(StudentEdit student);
    Task<IList<StudentDetails>> GetAllAsync();
}
