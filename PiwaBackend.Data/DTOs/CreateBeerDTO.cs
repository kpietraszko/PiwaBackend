using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class CreateBeerDTO
	{
		[Required]
		public string Name { get; set; }
		public int Style { get; set; }
		public decimal Alcohol { get; set; }
		public float? Ibu { get; set; }
		public float? Blg { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }
		[Required]
		public int Brewery { get; set; }
	}
}
