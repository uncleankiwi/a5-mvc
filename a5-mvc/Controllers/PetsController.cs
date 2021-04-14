using a5_mvc.Classes;
using a5_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a5_mvc.Controllers
{
	public class PetsController : Controller
	{
		Context ctx = new Context();

		// GET: Pets
		public ActionResult Index()
		{
			return View(ctx.Pets.ToList());
		}

		// GET: Pets/Details/5
		public ActionResult Details(int id)
		{
			return View(ctx.Pets.Find(id));
		}

		// GET: Pets/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Pets/Create
		[HttpPost]
		public ActionResult Create(Pet pet)
		{
			try
			{
				ctx.Pets.Add(pet);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Pets/Edit/5
		public ActionResult Edit(int id)
		{
			return View(ctx.Pets.Find(id));
		}

		// POST: Pets/Edit/5
		[HttpPost]
		public ActionResult Edit(Pet pet)
		{
			try
			{
				ctx.Entry(pet).State = System.Data.Entity.EntityState.Modified;
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Pets/Delete/5
		public ActionResult Delete(int id)
		{
			return View(ctx.Pets.Find(id));
		}

		// POST: Pets/Delete/5
		[HttpPost]
		public ActionResult Delete(Pet pet)
		{
			try
			{
				ctx.Pets.Remove(pet);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		/////////////////////utility methods
		private void InitDDL(Pet pet)
		{
			pet.CategoriesList = App.GetCategoriesDDL();
		}
	}
}
