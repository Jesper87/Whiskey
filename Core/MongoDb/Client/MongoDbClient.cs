using Core.Settings;
using MongoDB.Driver;

namespace Core.MongoDb.Client
{
	public class MongoDbClient : IMongoDbClient
	{
		public IMongoClient GetMongoClient()
		{
			return new MongoClient(AppSettings.MongoDbConnectionString);
		}

		public IMongoClient GetMongoClient(string connectionString)
	    {
		    return new MongoClient(connectionString);
	    }
	}
}
