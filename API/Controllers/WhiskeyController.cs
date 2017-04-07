using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/whiskey")]
    public class WhiskeyController : Controller
    {
	    private readonly IWhiskeyRepository _whiskeyRepository;

	    public WhiskeyController(IWhiskeyRepository whiskeyRepository)
	    {
		    _whiskeyRepository = whiskeyRepository;
	    }
		// GET api/whiskey
		[HttpGet]
        public Task<IEnumerable<Whiskey>> Get()
        {
	        return _whiskeyRepository.GetAll();
        }

		// GET api/whiskey/5
		[HttpGet("{id}")]
        public Task<Whiskey> Get(string id)
		{
			return _whiskeyRepository.GetById(id);
		}

		// POST api/whiskey
		[HttpPost]
        public void Post([FromBody]Whiskey whiskey)
        {
			//_whiskeyRepository.Add(whiskey);
		}

		// PUT api/whiskey/5
		[HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

		// DELETE api/whiskey/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
