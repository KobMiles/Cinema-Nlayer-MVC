namespace Cinema.BLL.DTOs.Users;

public class UserRegisterDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}