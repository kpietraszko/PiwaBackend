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

			if (!context.Beers.Any() && !context.Breweries.Any())
			{
				var okocim = new Brewery{ Name = "Okocim" };
				var kasztelan = new Brewery{ Name = "Kasztelan" };
				var carlsberg = new Brewery{ Name = "Carlsberg" };
				var zywiec = new Brewery{ Name = "Żywiec" };
				var amber = new Brewery{ Name = "Amber" };
				var warka = new Brewery{ Name = "Warka"};
				var lech = new Brewery{ Name = "Lech" };
				var lezajsk = new Brewery{ Name = "Leżajsk"};
				var lomza = new Brewery{ Name = "Łomża"};
				var perla = new Brewery{ Name = "Perła"};
				var tyskie = new Brewery{ Name = "Tyskie Browary Książęce"};

				context.Beers.AddRange(new Beer { Name = "Harnaś", Brewery = okocim },
					new Beer { Name = "Kasztelan", Brewery = kasztelan },
					new Beer { Name = "Karmi", Brewery = carlsberg },
					new Beer { Name = "EB", Brewery = zywiec },
					new Beer { Name = "Koźlak", Brewery = amber },
					new Beer { Name = "Królewskie", Brewery = warka },
					new Beer { Name = "Lech Pils", Brewery = lech },
					new Beer { Name = "Leżajsk", Brewery = lezajsk },
					new Beer { Name = "Łomża", Brewery = lomza },
					new Beer { Name = "Perła", Brewery = perla },
					new Beer { Name = "Tatra", Brewery = lezajsk},
					new Beer { Name = "Tyskie",  Brewery = tyskie },
					new Beer { Name = "Warka", Brewery = warka },
					new Beer { Name = "Żywiec", Brewery = zywiec });
				context.SaveChanges();
			}
		}
	}
}
