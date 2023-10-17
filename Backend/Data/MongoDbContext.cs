using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
        _database = client.GetDatabase("BackendNet");
    }

    // Agrega propiedades DbSet para tus colecciones
    public IMongoCollection<Auto> Autos => _database.GetCollection<Auto>("Autos");
}
