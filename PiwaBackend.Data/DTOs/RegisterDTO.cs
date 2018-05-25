using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class RegisterDTO
	{
		[Required]
		[EmailAddress]
		public string EmailAddress { get; set; }
		[Required]
		[RegularExpression("[a-zA-Z]+")]
		public string FirstName { get; set; }
		[Required]
		[RegularExpression("[a-zA-Z]+")]
		public string LastName { get; set; }
		[MinLength(6)]
		public string Password { get; set; }
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
