using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;
using System;

namespace DoctorOffice.Controllers
{
public class SpecialitiesController : Controller
{
[HttpGet("/specialities")]
public ActionResult Index()
{
	List<Speciality> allSpecialities = Speciality.GetAll();
	return View(allSpecialities);
}

[HttpPost("/specialities")]
public ActionResult Create(string specialityName)
{
	Speciality newSpeciality = new Speciality(specialityName);
	newSpeciality.Save();
	List<Speciality> allSpecialities= Speciality.GetAll();
	return View("Index", allSpecialities);
}

[HttpGet("/specialities/new")]
public ActionResult New()
{
	return View();

}

[HttpGet("/specialities/{id}")]
public ActionResult Show(int id)
{
	Dictionary<string, object> model = new Dictionary<string, object>(); // pa - sp do - do
	Speciality selectedSpeciality = Speciality.Find(id);
	List<Doctor> specialityDoctors = selectedSpeciality.GetDoctors();
	List<Doctor> allDoctors = Doctor.GetAll();
	model.Add("selectedSpeciality", selectedSpeciality);
	model.Add("specialityDoctors", specialityDoctors);
	model.Add("allDoctors", allDoctors);
	return View(model);
}

[HttpPost("/specialities/delete")]
public ActionResult DeleteAll()
{
	Speciality.DeleteAll();
	return View();
}

[HttpGet("/specialities/{specialityId}/edit")]
public ActionResult Edit(int specialityId)
{

	Dictionary<string, object> model = new Dictionary<string, object>();
	Speciality speciality = Speciality.Find(specialityId);

	model.Add("speciality", speciality);
	return View(model);
}

[HttpPost("/specialities/{specialityId}/doctors/new")]
public ActionResult AddDoctor(int specialityId, int doctorId)
{
	Speciality speciality = Speciality.Find(specialityId);
	Doctor doctor = Doctor.Find(doctorId);

	speciality.AddDoctor(doctor);
	return RedirectToAction("Show",  new { id = specialityId });

}
}
}
