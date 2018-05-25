using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PiwaBackend.Data.Models;

namespace PiwaBackend.Repository
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Beer> Beers { get; set; }
		public DbSet<Brewery> Breweries { get; set; }

	}
}