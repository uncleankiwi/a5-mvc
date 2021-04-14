using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	public class Pet
	{
		public int Id { get; set; }
		[DisplayName("Category")]
		public int CategoryId { get; set; }
		[DisplayName("Date of birth")]
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public Decimal Price { get; set; }
		public string Name { get; set; }
	}
}