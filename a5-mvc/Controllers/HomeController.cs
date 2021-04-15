using a5_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a5_mvc.Controllers
{
	public class HomeController : Controller
	{
		Context ctx = new Context();
		public ActionResult Index()
		{
			Home home = new Home();
			home.Shelter = ctx.Pets.Count();
			home.FoundHome = ctx.SoldPets.Max(x => x.Id);
			home.PutDown = ctx.Pets.Max(x => x.Id) - home.Shelter;
			int totalOutOfShelter = home.FoundHome + home.PutDown;
			totalOutOfShelter = totalOutOfShelter != 0 ? totalOutOfShelter : 1;
			home.PercentSaved = home.FoundHome / totalOutOfShelter;
			return View(home);
		}


	}
}