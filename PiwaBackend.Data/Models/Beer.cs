using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.Models
{
	enum BeerStyle
	{

	}
	public class Beer : BaseModel
	{
		[Required]
		public string Name { get; set; }
		public int Style { get; set; }
		public decimal Alcohol { get; set; }
		public float? IBU { get; set; }
		public float? Blg { get; set; }
		public string Description { get; set; }
	}
}
