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
	public class PetsController : Controller
	{
		Context ctx = new Context();

		// GET: Pets
		public ActionResult Index()
		{
			//System.Diagnostics.Debug.WriteLine(e.GetBaseException().ToString());
			return View(ctx.Pets.Include(x => x.Category).ToList());
		}

		// GET: Pets/Details/5
		public ActionResult Details(int id)
		{
			return View(PetFromId(id));
		}

		// GET: Pets/Create
		public ActionResult Create()
		{
			return View(InitDDL(new Pet()));
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
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Pet creation exception: " + e.GetBaseException().ToString());
				return View();
			}
		}

		// GET: Pets/Edit/5
		public ActionResult Edit(int id)
		{
			return View(InitDDL(PetFromId(id)));
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
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Pet edit exception: " + e.GetBaseException().ToString());
				return View();
			}
		}

		// GET: Pets/Delete/5
		public ActionResult Delete(int id)
		{
			return View(PetFromId(id));
		}

		// POST: Pets/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			try
			{
				ctx.Pets.Remove(PetFromId(id));
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Pet deletion exception: " + e.GetBaseException().ToString());
				return View();
			}
		}

		/////////////////////utility methods
		private Pet PetFromId (int id)
		{
			return ctx.Pets
				.Include(x => x.Category)
				.Single(x => x.Id == id);
		}
		private Pet InitDDL(Pet pet)
		{
			pet.CategoriesList = App.GetCategoriesDDL();
			return pet;
		}
	}
}
