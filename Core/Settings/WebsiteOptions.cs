namespace Core.Settings
{
	public class WebsiteOptions : IWebsiteOptions
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public string WhiskeyCollectionName { get; set; }
		public string LogFilePath { get; set; }
	}
}
