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
			return View(SoldPetFromId(id));
		}

		// GET: Sales/Create
		public ActionResult Create()
		{
			return View(InitDDL(new Sale()));
		}

		// POST: Sales/Create
		[HttpPost]
		public ActionResult Create(Sale sale)
		{
			try
			{
				ctx.Sales.Add(sale);
				Pet pet = ctx.Pets.Find(sale.PetId);
				ctx.Pets.Remove(pet);
				ctx.SoldPets.Add(new SoldPet(pet));
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
			return View(SaleFromId(id));
		}

		// POST: Sales/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			try
			{
				ctx.Sales.Remove(SaleFromId(id));
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		////////////////////utility methods
		private SoldPet SoldPetFromId(int id)
		{
			return ctx.SoldPets
				.Include(x => x.Category)
				.Single(x => x.Id == id);
		}

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
