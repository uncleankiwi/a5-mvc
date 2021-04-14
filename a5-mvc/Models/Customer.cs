using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	[Table("tblCustomer")]
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }

	}
}