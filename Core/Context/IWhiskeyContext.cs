using Core.Models;
using MongoDB.Driver;

namespace Core.Context
{
	public interface IWhiskeyContext
	{
		IMongoCollection<Whiskey> Whiskeys { get; }
	}
}