using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a5_mvc.Models
{
	[Table("tblPet")]
	public class Pet
	{
		public int Id { get; set; }
		[DisplayName("Category")]
		public int CategoryId { get; set; }
		[DisplayName("Date of birth")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public Decimal Price { get; set; }
		public string Name { get; set; }
		public Category Category { get; set; }
		[NotMapped]
		public IEnumerable<SelectListItem> CategoriesList { get; set; }

		override
		public string ToString()
		{
			return "pet:" + this.Id.ToString() +
				" categoryid:" + this.CategoryId.ToString() +
				" name:" + this.Name +
				//" categoryname:" + this.Category.CategoryName +
				" price:" + this.Price.ToString();
		}
	}
}