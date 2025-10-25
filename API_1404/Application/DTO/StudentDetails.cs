using System.ComponentModel.DataAnnotations;

namespace API_1404.Application.DTO;

public class StudentDetails
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public DateTime DateOfBirth { get; init; }
}
