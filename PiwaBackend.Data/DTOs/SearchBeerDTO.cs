using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class SearchBeerDTO
	{
		public string Name { get; set; }
		public int? Style { get; set; }
		public int? Country { get; set; }
		public decimal? AlcoholMin { get; set; }
		public decimal? AlcoholMax { get; set; }
		public float? IbuMin { get; set; }
		public float? IbuMax { get; set; }
		public float? BlgMin { get; set; }
		public float? BlgMax { get; set; }
	}
}
