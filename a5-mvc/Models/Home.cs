﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a5_mvc.Models
{
	public class Home
	{
		public int Shelter { get; set; } //Pets.count
		public int FoundHome { get; set; } //SoldPets.max
		public int PutDown { get; set; } //Pets.max - Pets.count

		public Decimal PercentSaved { get; set; } //FH / (FH + PD)

	}
}