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
				context.Breweries.AddRange(okocim, kasztelan, carlsberg, zywiec, amber, warka, lech, lezajsk, lomza, perla, tyskie);

				context.Beers.AddRange(new Beer { Name = "Harnaś", Brewery = okocim, Alcohol = 6m, ImagePath = "images/beers/generic.png"},
					new Beer { Name = "Kasztelan", Brewery = kasztelan, Alcohol = 7m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Karmi", Brewery = carlsberg, Alcohol = 1m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "EB", Brewery = zywiec, Alcohol = 8m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Koźlak", Brewery = amber, Alcohol = 6m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Królewskie", Brewery = warka, Alcohol = 7m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Lech Pils", Brewery = lech, Alcohol = 5m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Leżajsk", Brewery = lezajsk, Alcohol = 6m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Łomża", Brewery = lomza, Alcohol = 6m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Perła", Brewery = perla, Alcohol = 6m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Tatra", Brewery = lezajsk, Alcohol = 4m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Tyskie",  Brewery = tyskie, Alcohol = 4m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Warka", Brewery = warka, Alcohol = 6m, ImagePath = "images/beers/generic.png" },
					new Beer { Name = "Żywiec", Brewery = zywiec, Alcohol = 6m, ImagePath = "images/beers/generic.png" });
				context.SaveChanges();
			}
		}
	}
}
