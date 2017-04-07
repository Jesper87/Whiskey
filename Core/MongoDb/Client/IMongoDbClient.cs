using MongoDB.Driver;

namespace Core.MongoDb.Client
{
    public interface IMongoDbClient
    {
	    IMongoClient GetMongoClient();
	    IMongoClient GetMongoClient(string connectionString);
    }
}
