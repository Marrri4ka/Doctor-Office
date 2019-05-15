using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;
using System.Collections.Generic;
using System;

namespace DoctorOffice.Controllers
{
public class PatientsController : Controller
{
[HttpGet("/patients")]
public ActionResult Index()
{
	List<Patient> allPatients = Patient.GetAll();
	return View(allPatients);
}

[HttpPost("/patients")]
public ActionResult Create(string patientName, DateTime birthday)
{
	Patient newPatient = new Patient(patientName,birthday);
	newPatient.Save();
	List<Patient> allPatients = Patient.GetAll();
	return View("Index", allPatients);
}

[HttpGet("/patients/new")]
public ActionResult New()
{


	return View();

}

[HttpGet("/patients/{id}")]
public ActionResult Show(int id)
{
	Dictionary<string, object> model = new Dictionary<string, object>();
	Patient selectedPatient = Patient.Find(id);
	List<Doctor> patientDoctors = selectedPatient.GetDoctors();
	List<Doctor> allDoctors = Doctor.GetAll();
	model.Add("selectedPatient", selectedPatient);
	model.Add("patientDoctors", patientDoctors);
	model.Add("allDoctors", allDoctors);
	return View(model);
}

[HttpPost("/patients/delete")]
public ActionResult DeleteAll()
{
	Patient.DeleteAll();
	return View();
}

[HttpGet("/doctors/{doctorId}/patients/{patientId}/edit")]
public ActionResult Edit(int doctorId, int patientId)
{

	Dictionary<string, object> model = new Dictionary<string, object>();
	Doctor doctor = Doctor.Find(doctorId);

	model.Add("doctor", doctor);
	Patient patient = Patient.Find(patientId);
	model.Add("patient", patient);
	return View(model);
}

[HttpPost("/patients/{patientId}/doctors/new")]
public ActionResult AddDoctor(int patientId, int doctorId)
{
	Patient patient = Patient.Find(patientId);
	Doctor doctor = Doctor.Find(doctorId);

	patient.AddDoctor(doctor);
	return RedirectToAction("Show",  new { id = patientId });
}
}
}
