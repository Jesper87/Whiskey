using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.MongoDb.DataAccess;
using Core.Repositories.Interfaces;
using Core.Settings;
using Logger;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Repositories
{
	public class WhiskeyRepository : IWhiskeyRepository
	{
		protected IMongoDatabase Database;
		protected IMongoCollection<Whiskey> Collection;
		protected ILogger Logger;

		public WhiskeyRepository(IMongoDbDataAccess iMongoDbDataAccess, ILogger logger)
		{
			var mongoDbDataAccess = iMongoDbDataAccess;
			Database = mongoDbDataAccess.GetMongoDatabase();
			Collection = Database.GetCollection<Whiskey>(AppSettings.WhiskeyCollectionName);
			Logger = logger;
		}

		public async Task<IEnumerable<Whiskey>> GetAll()
		{
			try
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
			catch (Exception e)
			{
				Logger.LogError("[WhiskeyRepository.GetAll] Exception thrown: ", e);
				return Enumerable.Empty<Whiskey>();
			}

		}

		public async Task<Whiskey> GetById(string id)
		{
			try
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
			catch (Exception e)
			{
				Logger.LogError("[WhiskeyRepository.GetById] Exception thrown, parameter id = " + id + " ", e);
				return null;
			}
		}

		public async Task<Whiskey> Insert(Whiskey whiskey)
		{
			try
			{
				await Collection.InsertOneAsync(whiskey);
				return await GetById(whiskey.Id.ToString());
			}
			catch (Exception e)
			{
				Logger.LogError("[WhiskeyRepository.Insert] Exception thrown: ",e);
				return null;
			}
			
		}

		public void Update(string toString, Whiskey whiskey)
		{
			throw new System.NotImplementedException();
		}

		public async Task<long> Delete(string id)
		{
			try
			{
				var result = await Collection.DeleteOneAsync(new BsonDocument { { "_id", new ObjectId(id) } });
				return result.DeletedCount;
			}
			catch (Exception e)
			{
				Logger.LogError("[WhiskeyRepository.Delete] Exception thrown: ", e);
				return 0;
			}

		}
	}
}
