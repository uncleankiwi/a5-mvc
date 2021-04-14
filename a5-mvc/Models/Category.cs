using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	[Table("tblCategory")]
	public class Category
	{
		public int Id { get; set; }
		[DisplayName("Category")]
		public string CategoryName { get; set; }
	}
}