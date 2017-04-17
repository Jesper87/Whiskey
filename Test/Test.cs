using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.Context;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Test
{
	public class Test
	{		
		[Fact]
		public void WhiskeyCollectionsReturnsResult()
		{
			// Arrange
			var whiskeyCollection = Get();
			
			var mock = new Mock<IWhiskeyContext>();
			mock.Setup(w => w.Whiskeys).Returns(whiskeyCollection);
			
			// Act
			// Assert
			Assert.NotNull(mock.Object.Whiskeys);
		}

		private IMongoCollection<Whiskey> Get()
		{
			return null;
		}
	}
}
