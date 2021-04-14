using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	public class Context : DbContext
	{
		public DbSet<Pet> Pets { get; set; }
		public DbSet<SoldPet> SoldPets { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Sale> Sales { get; set; }
	}
}