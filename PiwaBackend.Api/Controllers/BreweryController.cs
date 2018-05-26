using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiwaBackend.Data.DTOs;
using PiwaBackend.Services.Interfaces;

namespace PiwaBackend.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class BreweryController : Controller
	{
		private readonly IBreweryService _breweryService;

		public BreweryController(IBreweryService breweryService)
		{
			_breweryService = breweryService;
		}
		[HttpPost]
		public IActionResult Create([FromForm]CreateBreweryDTO newBrewery) // /api/brewery
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(422, ModelState);
			}
			var result = _breweryService.CreateBrewery(newBrewery);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
		[HttpGet("{breweryId}")]
		public IActionResult GetById(int breweryId) // /api/brewery/1
		{
			var result = _breweryService.GetBreweryById(breweryId);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
		[HttpPost("[action]")]
		public IActionResult Search([FromBody]SearchBreweryDTO searchData)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(422, ModelState);
			}
			var result = _breweryService.SearchBreweries(searchData);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
	}
}