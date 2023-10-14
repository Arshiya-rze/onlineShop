namespace api.Repositories;

public class UserRepository : IUserRepository
{
    const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;

    public UserRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        _collection = database.GetCollection<AppUser>(_collectionName);
        // _tokenService = tokenService;
    }

    public async Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find<AppUser>(new BsonDocument()).ToListAsync(cancellationToken);

        List<UserDto> userDtos = new List<UserDto>();

        if (appUsers.Any())
        {
            foreach (AppUser appUser in appUsers)
            {
                UserDto userDto = new UserDto(
                    Id: appUser.Id!,
                    Email: appUser.Email
                );

                userDtos.Add(userDto);
            }

            return userDtos;
        }

        return userDtos; // []
    }
}
