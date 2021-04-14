﻿using a5_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a5_mvc.Controllers
{
	public class CustomersController : Controller
	{
		Context ctx = new Context();
		// GET: Customers
		public ActionResult Index()
		{
			return View(ctx.Customers.ToList());
		}

		// GET: Customers/Details/5
		public ActionResult Details(int id)
		{
			return View(ctx.Customers.Find(id));
		}

		// GET: Customers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Customers/Create
		[HttpPost]
		public ActionResult Create(Customer customer)
		{
			try
			{
				ctx.Customers.Add(customer);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Customers/Edit/5
		public ActionResult Edit(int id)
		{
			return View(ctx.Customers.Find(id));
		}

		// POST: Customers/Edit/5
		[HttpPost]
		public ActionResult Edit(Customer customer)
		{
			try
			{
				ctx.Entry(customer).State = System.Data.Entity.EntityState.Modified;
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Customers/Delete/5
		public ActionResult Delete(int id)
		{
			return View(ctx.Customers.Find(id));
		}

		// POST: Customers/Delete/5
		[HttpPost]
		public ActionResult Delete(Customer customer)
		{
			try
			{
				ctx.Customers.Remove(customer);
				ctx.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
