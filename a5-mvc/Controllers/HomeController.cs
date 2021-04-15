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
			try
			{
				home.Shelter = ctx.Pets.Count();
			}
			catch (Exception)
			{
				home.Shelter = 0;
			}

			try
			{
				home.FoundHome = ctx.SoldPets.Max(x => x.Id);
			}
			catch (Exception)
			{
				home.FoundHome = 0;
			}

			int petsMax = 0;
			try
			{
				petsMax = ctx.Pets.Max(x => x.Id);
			}
			catch (Exception)
			{
			}
			home.PutDown = petsMax - home.Shelter;
			int totalOutOfShelter = home.FoundHome + home.PutDown;
			totalOutOfShelter = totalOutOfShelter != 0 ? totalOutOfShelter : 1;
			decimal savedPercent = home.FoundHome / totalOutOfShelter * 100;
			home.PercentSaved = String.Format("{0:N0}", savedPercent) + "%";
			return View(home);
		}


	}
}