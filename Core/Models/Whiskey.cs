using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models
{
    public class Whiskey
    {
	    public Whiskey()
	    {
		    Distillery = new Distillery();
	    }

		/// <summary>
		/// MongoDB ObjectId
		/// </summary>
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("WhiskeyName")]
		public string Name { get; set; }

		[BsonElement("Age")]
	    public double Age { get; set; }

		[BsonElement("AlcoholPercentage")]
		public double AlcoholPercentage { get; set; }

		[BsonElement("Distillery")]
		public Distillery Distillery { get; set; }
	}
}
