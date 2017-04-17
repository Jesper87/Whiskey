namespace Core.Settings
{
	public interface IWebsiteOptions
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
		string WhiskeyCollectionName { get; set; }
		string LogFilePath { get; set; }
	}
}
