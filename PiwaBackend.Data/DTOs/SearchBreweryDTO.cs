using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class SearchBreweryDTO
	{
		public string Name { get; set; }
		public int? Type { get; set; }
		public int? Country { get; set; }
		public int? YearEstMin { get; set; }
		public int? YearEstMax { get; set; }
	}
}
