using System.ComponentModel.DataAnnotations;

namespace api.Models;

public record AppUser
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad email format")] string Email,
    byte[] PasswordSalt,
    byte[] PasswordHash
);