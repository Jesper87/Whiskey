using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models
{
    public class Distillery
    {
		[BsonElement("DistilleryName")]
		public string Name { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }
	}
}
