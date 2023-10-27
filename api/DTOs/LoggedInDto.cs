namespace api.DTOs;

public record LoggedInDto(
    string Id,
    string Email,
    string Token
);
