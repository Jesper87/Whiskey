using Core.Models;
using Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Core.Context
{
    public class WhiskeyContext : IWhiskeyContext
    {
	    private readonly IMongoClient _client;
	    private readonly IMongoDatabase _database;
		private readonly IWebsiteOptions _options;

	    public WhiskeyContext(IOptions<WebsiteOptions> options)
	    {
		    _options = options.Value;
		    _client = new MongoClient(_options.ConnectionString);
		    _database = _client.GetDatabase(_options.DatabaseName);
	    }

	    public IMongoCollection<Whiskey> Whiskeys => _database.GetCollection<Whiskey>(_options.WhiskeyCollectionName);
    }
}
