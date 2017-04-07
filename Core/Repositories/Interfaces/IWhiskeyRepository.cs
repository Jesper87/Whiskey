using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories.Interfaces
{
    public interface IWhiskeyRepository
    {
		Task<IEnumerable<Whiskey>> GetAll();
		Task<Whiskey> GetById(string id);
		Task<Whiskey> Insert(Whiskey whiskey);
		void Update(string toString, Whiskey whiskey);
		Task<long> Delete(string id);
    }
}
