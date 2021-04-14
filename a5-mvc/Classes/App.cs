using a5_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a5_mvc.Classes
{
	public class App
	{
		static Context ctx = new Context();
		public static IEnumerable<SelectListItem> GetCustomersDDL()
		{
			return ctx.Customers.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name,
			});
		}

		public static IEnumerable<SelectListItem> GetPetsDDL()
		{
			return ctx.Pets.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.Name,
			});
		}

		public static IEnumerable<SelectListItem> GetCategoriesDDL()
		{
			return ctx.Categories.ToList().Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Id.ToString() + ": " + x.CategoryName,
			});
		}
	}
}