namespace api.DTOs;

public record RegisterDto(
    // Email
    [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
    // Password
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string Password,
    // ConfirmPassword
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string ConfirmPassword
);

public record LoginDto(
    string Email,
    string Password
);