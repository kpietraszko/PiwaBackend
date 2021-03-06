﻿using System;
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
	[Route("api/[controller]")]
	public class BeerController : Controller
	{
		private readonly IBeerService _beerService;

		public BeerController(IBeerService beerService)
		{
			_beerService = beerService;
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create([FromForm]CreateBeerDTO newBeer) // /api/beer
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(422, ModelState);
			}
			var result = _beerService.CreateBeer(newBeer);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var result = _beerService.GetAllBeers();
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}

		[HttpGet("{beerId:int}")]
		public IActionResult GetById(int beerId)
		{
			var result = _beerService.GetBeerById(beerId);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
		[HttpPost("[action]")]
		public IActionResult Search([FromBody]SearchBeerDTO searchData)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(422, ModelState);
			}
			var result = _beerService.SearchBeers(searchData);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
		[HttpGet("brewery/{breweryId:int}")]
		public IActionResult Brewery(int breweryId)
		{
			var result = _beerService.GetBeersByBrewery(breweryId);
			if (result.IsError)
			{
				return StatusCode(422, result.Errors);
			}
			return Ok(result.SuccessResult);
		}
    }
}