using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.MongoDb.DataAccess;
using Core.Repositories.Interfaces;
using Core.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Repositories
{
	public class WhiskeyRepository : IWhiskeyRepository
	{
		protected IMongoDatabase Database;
		protected IMongoCollection<Whiskey> Collection;

		public WhiskeyRepository(IMongoDbDataAccess iMongoDbDataAccess)
		{
			var mongoDbDataAccess = iMongoDbDataAccess;
			Database = mongoDbDataAccess.GetMongoDatabase();
			Collection = Database.GetCollection<Whiskey>(AppSettings.WhiskeyCollectionName);
		}

		public async Task<IEnumerable<Whiskey>> GetAll()
		{
			var whiskeys = new List<Whiskey>();
			using (var result = await Collection.FindAsync(new BsonDocument()))
			{
				while (await result.MoveNextAsync())
				{
					var batch = result.Current;
					whiskeys.AddRange(batch.Where(document => document != null));
				}
			}
			return whiskeys;
		}

		public async Task<Whiskey> GetById(string id)
		{
			var whiskey = new Whiskey();
			using (var result = await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }))
			{
				var batch = result.Current.SingleOrDefault();
				if (batch != null)
					whiskey = batch;
			}
			return whiskey;

		}

		public async Task<Whiskey> Insert(Whiskey whiskey)
		{
			await Collection.InsertOneAsync(whiskey);
			return await GetById(whiskey.Id.ToString());
		}

		public void Update(Whiskey whiskey)
		{
			throw new System.NotImplementedException();
		}

		public async Task<long> Delete(string id)
		{
			var result = await Collection.DeleteOneAsync(new BsonDocument {{"_id", new ObjectId(id)}});
			return result.DeletedCount;
		}
	}
}
