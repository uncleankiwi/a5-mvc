using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	public class Sale
	{
		public int Id { get; set; }
		[DisplayName("Customer")]
		public int CustomerId { get; set; }
		[DisplayName("Sold pet")]
		public int SoldPetId { get; set; }
		[DisplayName("Sale date")]
		public DateTime SaleDate { get; set; }
	}
}