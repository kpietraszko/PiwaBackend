using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.Models
{
	public class User : BaseModel
	{
		[Required]
		public string EmailAddress { get; set; }
		[Required]
		public string PasswordHash { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
	}
}
