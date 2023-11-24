namespace api.Dtos;

public record RegisterDto
(
   [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="bad email format")] string Email,
   [DataType(DataType.Password), MinLength(7), MaxLength(20, ErrorMessage ="nabayad bish tar az 20 horof bashad")] string Password,
   [DataType(DataType.Password), MinLength(7), MaxLength(20)] string ConfirmPassword
);

public record LoginDto
(
   [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="bad email format")] 
   string Email,
   
   [DataType(DataType.Password), MinLength(7), MaxLength(20)]
   string Password
);
    
public record LoggedInDto
(
    string Id,
    string Email,
    string Token
);    

