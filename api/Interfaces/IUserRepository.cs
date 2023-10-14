namespace api.Interfaces;

public interface IUserRepository
{
    public Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken);
}
