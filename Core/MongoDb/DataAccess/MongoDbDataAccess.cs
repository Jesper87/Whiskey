using Core.MongoDb.Client;
using Core.Settings;
using MongoDB.Driver;

namespace Core.MongoDb.DataAccess
{
	public class MongoDbDataAccess : IMongoDbDataAccess
	{
		private readonly IMongoDbClient _client;

		public MongoDbDataAccess(IMongoDbClient client)
		{
			_client = client;
		}

		public IMongoDatabase GetMongoDatabase()
		{
			var mongoClient = _client.GetMongoClient();
			return mongoClient.GetDatabase(AppSettings.MongoDbDatabaseName);
		}

		public IMongoDatabase GetMongoDatabase(string databaseName)
		{
			var mongoClient = _client.GetMongoClient();
			return mongoClient.GetDatabase(databaseName);
		}
	}
}
