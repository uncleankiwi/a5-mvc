using a5_mvc.Models;
using System;
using System.Drawing;
using System.Linq;
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
			decimal savedPercent = Convert.ToDecimal(home.FoundHome) / Convert.ToDecimal(totalOutOfShelter) * 100;
			home.Color = "color: red";
			if (savedPercent >= 90)
			{
				home.Color = "color: green";
			}
			else if (savedPercent >= 80)
			{
				home.Color = "color: yellowgreen";
			}
			else if (savedPercent >= 70)
			{
				home.Color = "color: yellow";
			}
			else if (savedPercent >= 60)
			{
				home.Color = "color: orange";
			}
			else if (savedPercent >= 50)
			{
				home.Color = "color: orangered";
			}
			home.PercentSaved = String.Format("{0:N0}", savedPercent) + "%";
			return View(home);
		}


	}
}