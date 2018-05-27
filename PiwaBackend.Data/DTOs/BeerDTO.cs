using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class BeerDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Style { get; set; }
		public decimal Alcohol { get; set; }
		public float? Ibu { get; set; }
		public float? Blg { get; set; }
		public string Description { get; set; }
		[JsonIgnore]
		public string ImagePath { get; set; }
		public byte[] Image { get; set; }
		public string Brewery { get; set; }
		public int? BreweryType { get; set; }
		public int? Country { get; set; }
	}
}
