namespace api.Models;

public record AppUser(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string Email,
    // string Password,
    // string ConfirmPassword
    byte[] PasswordSalt,
    byte[] PasswordHash
);