using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Data.DTOs
{
	public class TokenDTO
	{
		public string Token { get; set; }
		public int UserId { get; set; }

		public TokenDTO(string token, int userId)
		{
			Token = token;
			UserId = userId;
		}
	}
}
