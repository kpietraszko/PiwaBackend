using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PiwaBackend.Data.DTOs;
using PiwaBackend.Data.Models;
using PiwaBackend.Services.Interfaces;

namespace PiwaBackend.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthenticationController : Controller
	{
		private readonly IAuthService _authService;
		private readonly IConfiguration _config;
		private readonly IPasswordHasher<User> _passwordHasher;

		public AuthenticationController(IAuthService authService, IConfiguration config, IPasswordHasher<User> passwordHasher)
		{
			_authService = authService;
			_config = config;
			_passwordHasher = passwordHasher;
		}

		[HttpPost]
		[AllowAnonymous]
		public IActionResult Register([FromBody] RegisterDTO userData)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var result = _authService.Register(userData);
			if (result.IsError)
				return StatusCode(422, result.Errors);

			return Ok(result.SuccessResult);
		}
		[HttpPost]
		[AllowAnonymous]
		public IActionResult Login([FromBody]LoginDTO loginData) //zwraca token
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var result = _authService.Login(loginData);
			if (result.IsError)
				return Unauthorized();

			return Ok(result.SuccessResult);
		}
	}
}