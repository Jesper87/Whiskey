﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;

namespace Web.Rest
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
		//[ValidateAntiForgeryToken]
		public JsonResult Post([FromBody]Whiskey whiskey)
		{
			_whiskeyRepository.Add(whiskey);
			return new JsonResult("Whiskey added");
		}

		// PUT api/whiskey/5
		[HttpPut("{id}")]
        public void Put(int id, [FromBody]Whiskey whiskey)
		{
			_whiskeyRepository.Update(id.ToString(),whiskey);
		}

		// DELETE api/whiskey/5
		[HttpDelete("{id}")]
        public void Delete(string id)
		{
			_whiskeyRepository.Delete(id);
		}
	}
}
