using a5_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a5_mvc.Controllers
{
	public class CategoriesController : Controller
	{
		Context ctx = new Context();
		// GET: Categories
		public ActionResult Index()
		{
			return View(ctx.Categories.ToList());
		}

		// GET: Categories/Details/5
		public ActionResult Details(int id)
		{
			return View(ctx.Categories.Find(id));
		}

		// GET: Categories/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Categories/Create
		[HttpPost]
		public ActionResult Create(Category category)
		{
			try
			{
				ctx.Categories.Add(category);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Categories/Edit/5
		public ActionResult Edit(int id)
		{
			return View(ctx.Categories.Find(id));
		}

		// POST: Categories/Edit/5
		[HttpPost]
		public ActionResult Edit(Category category)
		{
			try
			{
				ctx.Entry(category).State = System.Data.Entity.EntityState.Modified;
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Categories/Delete/5
		public ActionResult Delete(int id)
		{
			return View(ctx.Categories.Find(id));
		}

		// POST: Categories/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			try
			{
				ctx.Categories.Remove(ctx.Categories.Find(id));
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				return View();
			}
		}
	}
}
