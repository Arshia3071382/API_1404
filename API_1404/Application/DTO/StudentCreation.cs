namespace API_1404.Application.DTO;

public class StudentCreation
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}
