using System.Collections.Generic;
using Core.Models;
using Core.Repositories.Interfaces;
using MongoDB.Bson;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace Test
{
	public class Test
	{
		[Fact]
		public void WhiskeyCollectionsReturnsResult()
		{
			// Arrange
			var whiskeys = Get();
			var repoMock = new Mock<IWhiskeyRepository>();
			repoMock.Setup(m => m.GetAll()).Returns(whiskeys);
			
			// Act
			// Assert
			Assert.NotNull(repoMock.Object);
		}
		private Task<IEnumerable<Whiskey>> Get()
		{
			return new Task<IEnumerable<Whiskey>>(GetWhiskeys);
		}

		private IEnumerable<Whiskey> GetWhiskeys()
		{
			return new List<Whiskey>
			{
				new Whiskey
				{
					Age = 12, AlcoholPercentage = 60, Id =  new ObjectId("123"),Name = "Test",Distillery = new Distillery{Name = "TestDist", Description = "Desc"}
				}
			};
		}
	}
}
