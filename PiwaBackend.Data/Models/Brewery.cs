using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.Models
{
	public class Brewery : BaseModel
	{
		[Required]
		public string Name { get; set; }
		public int? Type { get; set; }
		public int? Country { get; set; }
		public int? YearEst { get; set; }
		public string ImagePath { get; set; }
		public ICollection<Beer> Beers { get; set; }
	}
}
