using PiwaBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiwaBackend.Repository
{
	public static class DbInitializer
	{
		public static void Seed(ApplicationDbContext context)
		{
			context.Database.EnsureCreated();
			if (!context.Users.Any())
			{
				context.Users.AddRange(new User { EmailAddress = "test@example.com", PasswordHash = "AQAAAAEAACcQAAAAEPc30vIAUpgsOBFBMXqfDmW1Ut0vwuRBqapeIcDJMmUIrEpbcpA8siKBuHf2W6urUw==", FirstName = "Jan", LastName = "Kowalski" });
				context.SaveChanges();
			}
		}
	}
}
