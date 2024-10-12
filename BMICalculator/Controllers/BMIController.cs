using BMICalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BMICalculator.Controllers
{
	public class BMIController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CaculateBMI(BMIModel bMI)
		{
			if (ModelState.IsValid)
			{

				bMI.BMI = bMI.Weight / (bMI.Height * bMI.Height);
				if (bMI.BMI < 18.5)
					ViewBag.Result = "نقص وزن";
				else if (bMI.BMI >= 18.5 && bMI.BMI < 24.9)
					ViewBag.Result = "وزن طبيعى";
				else if (bMI.BMI >= 25 && bMI.BMI < 29.9)
					ViewBag.Result = "زيادة الوزن";
				else
					ViewBag.Result = "سمنة";
				return View("Result",bMI);
			}
			return View("Index");
		}
	}
}
