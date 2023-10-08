namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<UserDto?> Create(RegisterDto userInput, CancellationToken cancellationToken); // method signature 

    public Task<UserDto?> Login(LoginDto userInput, CancellationToken cancellationToken);
}
