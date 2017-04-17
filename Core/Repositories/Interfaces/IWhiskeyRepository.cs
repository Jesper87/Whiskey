using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using MongoDB.Driver;

namespace Core.Repositories.Interfaces
{
    public interface IWhiskeyRepository
    {
		Task<IEnumerable<Whiskey>> GetAll();
		Task<Whiskey> GetById(string id);
		Task Add(Whiskey whiskey);
	    Task<ReplaceOneResult> Update(string id, Whiskey item);
		Task<DeleteResult> Delete(string id);
    }
}
