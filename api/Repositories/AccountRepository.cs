using System.Security.Cryptography;
using System.Text;

namespace api.Repositories;

public class AccountRepository : IAccountRepository
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;
    private readonly ITokenService _tokenService; // save user credential as a token

    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings, ITokenService tokenService)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        _collection = database.GetCollection<AppUser>(_collectionName);
        _tokenService = tokenService;
    }

    public async Task<LoggedInDto?> CreateAsync(RegisterDto userInput, CancellationToken cancellationToken)
    {
        // check if user/email already exists
        bool doesAccountExist = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doesAccountExist)
            return null;

        // manually dispose HMACSHA512 after being done
        using var hmac = new HMACSHA512();

        AppUser appUser = new AppUser(
            Id: null,
            Email: userInput.Email.ToLower().Trim(),
            PasswordHash: hmac.ComputeHash(Encoding.UTF8.GetBytes(userInput.Password)),
            PasswordSalt: hmac.Key
        );

        if (_collection is not null)
            await _collection.InsertOneAsync(appUser, null, cancellationToken);

        if (appUser.Id is not null)
        {
            LoggedInDto loggedInDto = new LoggedInDto(
                Id: appUser.Id,
                Token: _tokenService.CreateToken(appUser),
                Email: appUser.Email // amir@gmail.com
            );

            return loggedInDto;
        }

        return null;
    }

    public async Task<LoggedInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        // Import and use HMACSHA512 including PasswordSalt
        using var hmac = new HMACSHA512(appUser.PasswordSalt!);

        // // Convert userInputPassword to Hash
        var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userInput.Password));

        // // Check if password is correct and matched with Database PasswordHash. 
        if (appUser.PasswordHash is not null && appUser.PasswordHash.SequenceEqual(ComputedHash))
        {
            if (appUser.Id is not null) // merge it!
            {
                return new LoggedInDto(
                    Id: appUser.Id,
                    Token: _tokenService.CreateToken(appUser),
                    Email: appUser.Email
                );
            }
        }

        return null;
    }
}