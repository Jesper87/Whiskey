using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Context;
using Core.Models;
using Core.Repositories.Interfaces;
using Logger;
using MongoDB.Driver;

namespace Core.Repositories
{
	public class WhiskeyRepository : IWhiskeyRepository
	{
		private readonly ILogger _logger;
		private readonly IWhiskeyContext _context;

		public WhiskeyRepository(IWhiskeyContext context, ILogger logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<Whiskey>> GetAll()
		{
			try
			{
				return await _context.Whiskeys.Find(_ => true).ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError("[WhiskeyRepository.GetAll] Exception thrown: ", e);
				return Enumerable.Empty<Whiskey>();
			}

		}

		public async Task<Whiskey> GetById(string id)
		{
			try
			{
				var filter = Builders<Whiskey>.Filter.Eq("Id", id);
				return await _context.Whiskeys.Find(filter).FirstOrDefaultAsync();
			}
			catch (Exception e)
			{
				_logger.LogError("[WhiskeyRepository.GetById] Exception thrown, parameter id = " + id + " ", e);
				return null;
			}
		}

		public async Task Add(Whiskey whiskey)
		{
			try
			{
				await _context.Whiskeys.InsertOneAsync(whiskey);
			}
			catch (Exception e)
			{
				_logger.LogError("[WhiskeyRepository.Add] Exception thrown: ", e);
			}

		}

		public async Task<DeleteResult> Delete(string id)
		{
			try
			{
				return await _context.Whiskeys.DeleteOneAsync(Builders<Whiskey>.Filter.Eq("Id", id));

			}
			catch (Exception e)
			{
				_logger.LogError("[WhiskeyRepository.Delete] Exception thrown: ", e);
				return null;
			}

		}

		public async Task<ReplaceOneResult> Update(string id, Whiskey whiskey)
		{
			try
			{
				return await _context.Whiskeys.ReplaceOneAsync(n => n.Id.Equals(id), whiskey, new UpdateOptions { IsUpsert = true });
			}
			catch (Exception e)
			{
				_logger.LogError("[WhiskeyRepository.Update] Exception thrown: ", e);
				return null;
			}
		}
	}
}
