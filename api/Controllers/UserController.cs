namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    #region Db and Token Settings
    const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;
    // private readonly ITokenService _tokenService; // save user credential as a token

    // constructor - dependency injection
    public UserController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        _collection = database.GetCollection<AppUser>(_collectionName);
        // _tokenService = tokenService;
    }
    #endregion

    // MAKE THESE MATHODS ASYNC
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAll(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find<AppUser>(new BsonDocument()).ToListAsync(cancellationToken);

        if (!appUsers.Any())
            return NoContent();

        return appUsers;
    }

    [HttpGet("get-by-id/{userId}")]
    public async Task<ActionResult<AppUser>> GetById(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if(appUser is null)
            return NotFound("No user was found");

        return appUser;
    }
}
