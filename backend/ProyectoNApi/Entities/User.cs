

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public required int User_Id { get; set; }
    public required string Dni { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Photo_Url { get; set; }
    public required string Role { get; set; }
}