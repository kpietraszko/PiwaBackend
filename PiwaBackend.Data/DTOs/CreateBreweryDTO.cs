using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class CreateBreweryDTO
	{
		[Required]
		public string Name { get; set; }
		public string Type { get; set; }
		public int? Country { get; set; }
		public int? YearEst { get; set; }
		public IFormFile Image { get; set; }
	}
}
