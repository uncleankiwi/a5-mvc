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
		readonly Context ctx = new Context();
		// GET: Sales
		public ActionResult Index()
		{
			try
			{
				return View(ctx.Sales
				.Include(x => x.SoldPet)
				.Include(x => x.Customer)
				.ToList());
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.GetBaseException().ToString());
				return View();
			}

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
			System.Diagnostics.Debug.WriteLine("sale!");						//TODO sales fix


			try
			{
				Pet pet = ctx.Pets.Find(sale.PetId);
				System.Diagnostics.Debug.WriteLine("petid:" + sale.PetId);           //TODO sales fix
				System.Diagnostics.Debug.WriteLine("pet:" + pet);              //TODO sales fix
				SoldPet soldPet = new SoldPet(pet);
				System.Diagnostics.Debug.WriteLine("soldpet:" + soldPet);  //TODO sales fix
				ctx.SoldPets.Add(soldPet);
				ctx.Pets.Remove(pet);
				ctx.SaveChanges();

				int newSoldPetId = ctx.SoldPets.Max(x => x.Id);
				System.Diagnostics.Debug.WriteLine("newsoldpetid:" + newSoldPetId);  //TODO sales fix
				sale.SoldPetId = newSoldPetId;
				ctx.Sales.Add(sale);
				ctx.SaveChanges();

				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Sale creation exception: " + e.GetBaseException().ToString());
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
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Sale deletion exception: " + e.GetBaseException().ToString());
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
			Sale sale =  ctx.Sales
				.Include(x => x.Customer)
				.Include(x => x.SoldPet)
				.Single(x => x.Id == id);
			return sale;
		}
		private Sale InitDDL(Sale sale)
		{
			sale.CustomerList = App.GetCustomersDDL();
			sale.PetsList = App.GetPetsDDL();
			return sale;
		}

	}
}
