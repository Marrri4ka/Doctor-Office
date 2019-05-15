using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;

namespace DoctorOffice.Controllers
{
public class DoctorsController : Controller
{
[HttpGet("/doctors")]
public ActionResult Index()
{
	List<Doctor> allDoctors = Doctor.GetAll();
	return View(allDoctors);
}

[HttpPost("/doctors/{doctorId}/patients/new")]
public ActionResult AddPatient(int doctorId, int patientId)
{
	Doctor doctor = Doctor.Find(doctorId);
	Patient patient = Patient.Find(patientId);
	doctor.AddPatient(patient);
	return RedirectToAction("Show",  new { id = doctorId });
}

[HttpPost("/doctors")]
public ActionResult Create(string doctorName)
{
	Doctor newDoctor = new Doctor(doctorName);
	newDoctor.Save();
	List<Doctor> allDoctors = Doctor.GetAll();
	return View("Index", allDoctors);
}

[HttpGet("/doctors/{doctorId}/edit")]
public ActionResult Edit(int doctorId)

{
	Doctor foundDoctor = Doctor.Find(doctorId);
	return View("Edit",foundDoctor );
}

[HttpPost("/doctors/{id}/editedDoctor")]
public ActionResult Edit(int id, string doctorName)
{
	Doctor newDoctor = Doctor.Find(id);
	newDoctor.Edit(doctorName);
	List<Doctor> allDoctors = Doctor.GetAll();
	return View("Index", allDoctors);
}

[HttpGet("/doctors/new")]
public ActionResult New()
{
	return View();
}

[HttpGet("/doctors/{id}")]
public ActionResult Show(int id)
{
	Dictionary<string, object> model = new Dictionary<string, object>();
	Doctor selectedDoctor = Doctor.Find(id);
	List<Patient> doctorPatients = selectedDoctor.GetPatients();
	List<Patient> allPatients = Patient.GetAll();
	model.Add("doctor", selectedDoctor);
	model.Add("doctorPatients", doctorPatients);
	model.Add("allPatients", allPatients);
	return View(model);
}

[HttpPost("/doctors/{doctorId}/patients")]
public ActionResult Create(int doctorId, string patientName, DateTime birthday)
{
	Dictionary<string, object> model = new Dictionary<string, object>();
	Doctor foundDoctor = Doctor.Find(doctorId);
	Patient newPatient = new Patient(patientName, birthday, doctorId);
	newPatient.Save();
	List<Patient> doctorPatients = foundDoctor.GetPatients();
	model.Add("patinets", doctorPatients);
	model.Add("doctor", foundDoctor);
	return View("Show", model);
}


// [HttpGet("/doctors/{doctorId}/patientssort")]
// public ActionResult Sort(int doctorId, string patientName, DateTime birthday  )
// {
//      Dictionary<string, object> model = new Dictionary<string, object>();
//      Doctor foundDoctor = Doctor.Find(doctorId);
//      List<Patient> sortedPatients = Patient.Sort();
//      model.Add("patients", sortedPatients);
//      model.Add("doctor", foundDoctor);
//      return View("Show", model);
// }

[HttpGet("/search_by_doctor")]
public ActionResult SearchByDoctor()
{
	return View();
}

//
// [HttpPost("/search_by_doctor")]
// public ActionResult Index(string doctor)
// {
//      List<Doctor> filteredDoctors = Doctor.FilterAll(doctor);
//      return View(filteredDoctors);
// }

[HttpGet("/doctors/{doctorId}/delete")]
public ActionResult Delete(int doctorId)

{
	Doctor foundDoctor = Doctor.Find(doctorId);
	foundDoctor.Delete();
	return RedirectToAction("Index");
}



// [HttpPost("/doctors/{doctorId}/patients/{patientId}/editpatient")]
// public ActionResult Update(int doctorId, int patientId, string newName, DateTime newBirthday)
// {
//      Patient patient = Patient.Find(patientId);
//      patient.Edit(newName, newBirthday);
//      Dictionary<string, object> model = new Dictionary<string, object>();
//      Doctor doctor = Doctor.Find(doctorId);
//      List<Patient> doctorPatients = doctor.GetPatients();
//      model.Add("doctor", doctor);
//      model.Add("patients", doctorPatients);
//      return View("Show", model);
// }

[HttpPost("/doctors/{doctorId}/patients/{patientId}/deletepatient")]
public ActionResult DeletePatient(int doctorId, int patientId)
{
	Patient patient = Patient.Find(patientId);
	patient.Delete();
	Dictionary<string, object> model = new Dictionary<string, object>();
	Doctor doctor = Doctor.Find(doctorId);
	List<Patient> doctorPatients = doctor.GetPatients();
	model.Add("doctor", doctor);
	model.Add("patients", doctorPatients);
	return View("Show", model);
}
}
}
