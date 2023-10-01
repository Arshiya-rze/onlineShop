namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<UserDto?> Create(RegisterDto age, CancellationToken cancellationToken); // method signature 
}
