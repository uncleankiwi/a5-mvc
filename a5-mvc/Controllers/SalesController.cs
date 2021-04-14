using a5_mvc.Classes;
using a5_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace a5_mvc.Controllers
{
	public class SalesController : Controller
	{
		Context ctx = new Context();
		// GET: Sales
		public ActionResult Index()
		{
			return View(ctx.Sales.ToList());
		}

		// GET: Sales/Details/5
		public ActionResult Details(int id)
		{
			return View(ctx.SoldPets.Find(id));
		}

		// GET: Sales/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Sales/Create
		[HttpPost]
		public ActionResult Create(Sale sale)
		{
			try
			{
				ctx.Sales.Add(sale);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//// GET: Sales/Edit/5
		//public ActionResult Edit(int id)
		//{
		//    return View(ctx.Sales.Find(id));
		//}

		//// POST: Sales/Edit/5
		//[HttpPost]
		//public ActionResult Edit(Sale sale)
		//{
		//    try
		//    {
				
		//        return RedirectToAction("Index");
		//    }
		//    catch
		//    {
		//        return View();
		//    }
		//}

		// GET: Sales/Delete/5
		public ActionResult Delete(int id)
		{
			return View(ctx.Sales.Find(id));
		}

		// POST: Sales/Delete/5
		[HttpPost]
		public ActionResult Delete(Sale sale)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		////////////////////utility methods
		private Sale SaleFromId(int id)
		{
			return ctx.Sales
				.Include(x => x.Customer)
				.Include(x => x.SoldPet)
				.Single(x => x.Id == id);
		}
		private Sale InitDDL(Sale sale)
		{
			sale.CustomerList = App.GetCustomersDDL();
			sale.PetsList = App.GetPetsDDL();
			return sale;
		}

	}
}
