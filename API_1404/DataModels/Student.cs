using System.ComponentModel.DataAnnotations;

namespace API_1404.DataModels;

public class Student
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(30)]
    public required string Email { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

}
