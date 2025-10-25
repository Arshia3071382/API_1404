using API_1404.Application.DTO;
using API_1404.DataModels;
using Mapster;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API_1404.Application;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _db;
    public StudentService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<StudentCreation?> CreateAsync(StudentCreation student)
    {
        if (student is not null)
        {
            var finalstudent = await _db.Students.AddAsync(student.Adapt<Student>());
            await _db.SaveChangesAsync();
            return student;
        }
            return null;
    }

    public async Task Delete(int id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student is not null)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IList<StudentDetails>> GetAllAsync()
    {
        return await _db.Students.ProjectToType<StudentDetails>().ToListAsync();
    }

    public async Task<StudentDetails?> GetById(int id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student is not null)
        {
            return student.Adapt<StudentDetails>();
        }
        else
        {
            return null;
        }
    }

    public async Task UpdateAsync(StudentEdit studentEdited)
    {
        var student = await _db.Students.FindAsync(studentEdited.Id);
        if (student is not null)
        {
            student.Name = studentEdited.Name;
            student.Email = studentEdited.Email;
            student.DateOfBirth = studentEdited.DateOfBirth;
        }

        await _db.SaveChangesAsync();
    }
}
