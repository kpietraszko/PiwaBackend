using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class BreweryDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Type { get; set; }
		public int? Country { get; set; }
		public int? YearEst { get; set; }
		[JsonIgnore]
		public string ImagePath { get; set; }
		public byte[] Image { get; set; }
	}
}
