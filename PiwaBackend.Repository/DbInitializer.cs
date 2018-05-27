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
				var okocim = new Brewery{ Name = "Okocim", Type = 0, Country = 166 };
				var kasztelan = new Brewery{ Name = "Kasztelan", Type = 0, Country = 166 };
				var carlsberg = new Brewery{ Name = "Carlsberg", Type = 0, Country = 166 };
				var zywiec = new Brewery{ Name = "Żywiec", Type = 0, Country = 166 };
				var amber = new Brewery{ Name = "Amber", Type = 0, Country = 166 };
				var warka = new Brewery{ Name = "Warka", Type = 0, Country = 166};
				var lech = new Brewery{ Name = "Lech", Type = 0, Country = 166 };
				var lezajsk = new Brewery{ Name = "Leżajsk", Type = 0, Country = 166};
				var lomza = new Brewery{ Name = "Łomża", Type = 0, Country = 166};
				var perla = new Brewery{ Name = "Perła", Type = 0, Country = 166};
				var tyskie = new Brewery{ Name = "Tyskie Browary Książęce", Type = 0, Country = 166};
				context.Breweries.AddRange(okocim, kasztelan, carlsberg, zywiec, amber, warka, lech, lezajsk, lomza, perla, tyskie);

				var beers = new Beer[] {
				new Beer { Name = "Harnaś", Brewery = okocim, Alcohol = 6m, ImagePath = "images/beers/generic.png"},
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
					new Beer { Name = "Żywiec", Brewery = zywiec, Alcohol = 6m, ImagePath = "images/beers/generic.png" }};


				foreach (var beer in beers)
				{
					beer.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vulputate nibh vel elit ultricies, at lobortis nulla dictum. Mauris vitae leo viverra eros pulvinar rhoncus. Ut ut molestie sem, ut porttitor ex. Etiam sodales fermentum nibh eget egestas. Etiam quam lorem, imperdiet vel elementum id, eleifend fermentum magna. Sed ac tortor malesuada, dignissim tortor ut, convallis nisi.";
				}
				context.Beers.AddRange(beers);
				context.SaveChanges();
			}
		}
	}
}
