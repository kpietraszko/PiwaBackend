using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Repository
{
	public static class DbInitializer
	{
		public static void Seed(ApplicationDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
