using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;

namespace DoctorOffice.Controllers
{
public class HomeController : Controller
{
[HttpGet("/")]
public ActionResult Index()
{
	List<Doctor> allDoctors = Doctor.GetAll();

	return View(allDoctors);
}

}
}
