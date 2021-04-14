using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	[Table("tblSoldPet")]
	public class SoldPet
	{
		public int Id { get; set; }
		[DisplayName("Category")]
		public int CategoryId { get; set; }
		[DisplayName("Date of birth")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public Decimal Price { get; set; }
		public string Name { get; set; }
		[NotMapped]
		public Category Category { get; set; }
		public SoldPet(Pet pet)
		{
			this.Id = pet.Id;
			this.CategoryId = pet.Id;
			this.BirthDate = pet.BirthDate;
			this.Gender = pet.Gender;
			this.Price = pet.Price;
			this.Name = pet.Name;
		}
	}
}