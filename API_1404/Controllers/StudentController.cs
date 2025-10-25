using API_1404.Application.DTO;
using API_1404.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/student
    [HttpGet]
    public async Task<ActionResult<IList<StudentDetails>>> GetAllStudents()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students); // Return 200 OK with the list of students
    }

    // GET: api/student/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDetails>> GetStudentById(int id)
    {
        var student = await _studentService.GetById(id);
        if (student == null)
        {
            return NotFound(); // Return 404 Not Found if student doesn't exist
        }
        return Ok(student); // Return 200 OK with student details
    }

    // POST: api/student
    [HttpPost]
    public async Task<ActionResult> CreateStudent([FromBody] StudentCreation student)
    {
        if (student == null)
        {
            return BadRequest("Student data is required.");
        }

        var createdStudent = await _studentService.CreateAsync(student);
        return Ok(createdStudent);
    }

    // PUT: api/student/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, [FromBody] StudentEdit studentEdit)
    {
        if (id != studentEdit.Id)
        {
            return BadRequest("Student ID mismatch."); // Return 400 if the IDs don't match
        }

        var student = await _studentService.GetById(id);
        if (student == null)
        {
            return NotFound(); // Return 404 if the student doesn't exist
        }

        await _studentService.UpdateAsync(studentEdit);
        return NoContent(); // Return 204 No Content on successful update
    }

    // DELETE: api/student/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
        var student = await _studentService.GetById(id);
        if (student == null)
        {
            return NotFound(); // Return 404 if student doesn't exist
        }

        await _studentService.Delete(id);
        return NoContent(); // Return 204 No Content on successful deletion
    }
}
