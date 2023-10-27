namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggedInDto?> CreateAsync(RegisterDto userInput, CancellationToken cancellationToken); // method signature 

    public Task<LoggedInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);
}
