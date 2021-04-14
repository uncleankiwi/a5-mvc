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
	[Table("tblSale")]
	public class Sale
	{
		public int Id { get; set; }
		[DisplayName("Customer")]
		public int CustomerId { get; set; }
		[DisplayName("Sold pet")]
		public int SoldPetId { get; set; }
		[DisplayName("Sale date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime SaleDate { get; set; }
		[NotMapped]
		public Customer Customer { get; set; }
		[NotMapped]
		public SoldPet SoldPet {get; set; }
		[NotMapped]
		public int PetId { get; set; }
		[NotMapped]
		public Pet Pet { get; set; }
		[NotMapped]
		public IEnumerable<SelectListItem> PetsList { get; set; }
		[NotMapped]
		public IEnumerable<SelectListItem> CustomerList { get; set; }

	}
}