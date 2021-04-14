using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	public class Context : DbContext
	{
		DbSet<Pet> Pets { get; set; }
		DbSet<SoldPet> SoldPets { get; set; }
		DbSet<Category> Categories { get; set; }
		DbSet<Customer> Customers { get; set; }
		DbSet<Sale> Sales { get; set; }
	}
}