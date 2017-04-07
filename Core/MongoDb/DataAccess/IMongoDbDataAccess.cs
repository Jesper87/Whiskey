using MongoDB.Driver;

namespace Core.MongoDb.DataAccess
{
    public interface IMongoDbDataAccess
    {
	    IMongoDatabase GetMongoDatabase();
	    IMongoDatabase GetMongoDatabase(string databaseName);
    }
}
