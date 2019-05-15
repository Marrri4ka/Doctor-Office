using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace DoctorOffice.Models
{
public class Patient   // class
{
private string _name;
private DateTime _birthday;     // field
private int _id;

public Patient (string name, DateTime birthday, int id=0)     // constructor
{
	_name = name;
	_birthday = birthday;
	_id = id;
}
public int GetId()
{
	return _id;
}

public string GetName()
{
	return _name;
}

public void SetName(string newName)
{
	_name = newName;
}

public DateTime GetBirthday()
{
	return _birthday;
}

public void SetBirthday(DateTime newBirthday)
{
	_birthday = newBirthday;
}


public static List<Patient> GetAll()
{
	List<Patient> allPatients = new List<Patient> {
	};

	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT * FROM patient;";
	MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

	while (rdr.Read())
	{
		int patientId = rdr.GetInt32(0);
		string patientName = rdr.GetString(1);
		DateTime patientBirthday = rdr.GetDateTime(2);

		Patient newPatient = new Patient  (patientName,patientBirthday, patientId);
		allPatients.Add(newPatient);
	}

	conn.Close();

	if (conn != null)
	{
		conn.Dispose();
	}

	return allPatients;

}

// public static List<Item> Sort()
// {
//      List<Item> allItems = new List<Item> {
//      };
//
//      MySqlConnection conn = DB.Connection();
//      conn.Open();
//      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//      cmd.CommandText = @"SELECT * FROM items ORDER BY duedate DESC;";
//      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//
//      while (rdr.Read())
//      {
//              int itemId = rdr.GetInt32(0);
//              string itemDescription = rdr.GetString(1);
//              DateTime itemDueDate = rdr.GetDateTime(2);
//              // int itemCategoryId = rdr.GetInt32(3);
//              Item newItem = new Item (itemDescription,itemDueDate,itemId);
//              allItems.Add(newItem);
//      }
//
//      conn.Close();
//
//      if (conn != null)
//      {
//              conn.Dispose();
//      }
//
//      return allItems;
//
// }



public static void DeleteAll()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"DELETE FROM patient;";
	cmd.ExecuteNonQuery();

	conn.Close();
	if(conn != null)
	{
		conn.Dispose();
	}
}
public override bool Equals(System.Object otherPatient)
{
	if (!(otherPatient is Patient))
	{
		return false;
	}
	else
	{
		Patient newPatient = (Patient) otherPatient;

		bool idEquality = this.GetId() == newPatient.GetId();
		bool nameEquality = this.GetName() == newPatient.GetName();
		bool birthdayEquality = this.GetBirthday() == newPatient.GetBirthday();
		// bool categoryEquality = this.GetCategoryId() == newItem.GetCategoryId();
		return (idEquality && nameEquality && birthdayEquality);
	}
}

public void Save()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;

	cmd.CommandText = @"INSERT INTO patient (name, birthday) VALUES (@PatientName, @PatientBirthday);";

	MySqlParameter nameParameter = new MySqlParameter();
	nameParameter.ParameterName = "@PatientName";
	nameParameter.Value = this._name;
	cmd.Parameters.Add(nameParameter);

	MySqlParameter birthdayParameter = new MySqlParameter();
	birthdayParameter.ParameterName = "@PatientBirthday";
	birthdayParameter.Value = this._birthday;
	cmd.Parameters.Add(birthdayParameter);

	// MySqlParameter categoryParameter = new MySqlParameter();
	// categoryParameter.ParameterName = "@ItemCategoryId";
	// categoryParameter.Value = this._categoryId;
	// cmd.Parameters.Add(categoryParameter);

	cmd.ExecuteNonQuery();

	_id = (int) cmd.LastInsertedId;

	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
}


// public void Edit(string newDescription, DateTime newduedate)
// {
//      MySqlConnection conn = DB.Connection();
//      conn.Open();
//      var cmd = conn.CreateCommand() as MySqlCommand;
//      cmd.CommandText = @"UPDATE items SET description = @newDescription WHERE id = @searchId;";
//      cmd.CommandText = @"UPDATE items SET duedate = @newduedate WHERE id = @searchId;";
//      MySqlParameter searchId = new MySqlParameter();
//      searchId.ParameterName = "@searchId";
//      searchId.Value = _id;
//      cmd.Parameters.Add(searchId);
//
//      MySqlParameter description = new MySqlParameter();
//      description.ParameterName = "@newDescription";
//      description.Value = newDescription;
//      cmd.Parameters.Add(description);
//      MySqlParameter duedate = new MySqlParameter();
//      duedate.ParameterName = "@newduedate";
//      duedate.Value = newduedate;
//      cmd.Parameters.Add(duedate);
//      cmd.ExecuteNonQuery();
//
//      _description = newDescription;
//      _duedate = newduedate;
//
//      conn.Close();
//      if (conn != null)
//      {
//              conn.Dispose();
//      }
// }





//
public static Patient Find (int id)
{

	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT * FROM patient WHERE id = (@searchId);";
	MySqlParameter idParameter = new MySqlParameter();
	idParameter.ParameterName = "@searchId";
	idParameter.Value = id;
	cmd.Parameters.Add(idParameter);
	var rdr = cmd.ExecuteReader() as MySqlDataReader;
	int patientId=0;
	string patientName ="";
	DateTime patientBirthday = new DateTime();

	while(rdr.Read())
	{
		patientId = rdr.GetInt32(0);
		patientName = rdr.GetString(1);
		patientBirthday = rdr.GetDateTime(2);
		// itemCategoryId = rdr.GetInt32(3);
	}
	Patient foundPatient = new Patient (patientName,patientBirthday, patientId);

	conn.Close();
	if(conn != null)
	{
		conn.Dispose();
	}
	return foundPatient;
}

public List<Doctor> GetDoctors()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT doctor_id FROM doctors_patients WHERE patient_id = @patientId;";
	MySqlParameter patientIdParameter = new MySqlParameter();
	patientIdParameter.ParameterName = "@patientId";
	patientIdParameter.Value = _id;
	cmd.Parameters.Add(patientIdParameter);
	var rdr = cmd.ExecuteReader() as MySqlDataReader;
	List<int> doctorIds = new List <int> {
	};
	while (rdr.Read())
	{
		int doctorId = rdr.GetInt32(0);
		doctorIds.Add(doctorId);
	}
	rdr.Dispose();
	List<Doctor> doctors = new List<Doctor> {
	};
	foreach (int doctorId in doctorIds)
	{
		var doctorQuery = conn.CreateCommand() as MySqlCommand;
		doctorQuery.CommandText = @"SELECT * FROM doctor WHERE id = @DoctorId;";
		MySqlParameter doctorIdParameter = new MySqlParameter();
		doctorIdParameter.ParameterName = "@DoctorId";
		doctorIdParameter.Value = doctorId;
		doctorQuery.Parameters.Add(doctorIdParameter);
		var doctorQueryRdr = doctorQuery.ExecuteReader() as MySqlDataReader;
		while(doctorQueryRdr.Read())
		{
			int thisDoctorId = doctorQueryRdr.GetInt32(0);
			string doctorName = doctorQueryRdr.GetString(1);
			Doctor foundDoctor = new Doctor(doctorName, thisDoctorId);
			doctors.Add(foundDoctor);
		}
		doctorQueryRdr.Dispose();
	}


	conn.Close();
	if(conn != null)
	{
		conn.Dispose();
	}
	return doctors;
}


public void AddDoctor (Doctor newDoctor)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"INSERT INTO doctors_patients (doctor_id, patient_id) VALUES (@DoctorId, @PatientId);";
	MySqlParameter doctor_id = new MySqlParameter();
	doctor_id.ParameterName = "@DoctorId";
	doctor_id.Value = newDoctor.GetId();
	cmd.Parameters.Add(doctor_id);
	MySqlParameter patient_id = new MySqlParameter();
	patient_id.ParameterName = "@PatientId";
	patient_id.Value = _id;
	cmd.Parameters.Add(patient_id);
	cmd.ExecuteNonQuery();


	conn.Close();
	if(conn != null)
	{
		conn.Dispose();
	}
}

public void Delete()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"DELETE FROM patient WHERE id = @PatientId; DELETE FROM doctors_patients WHERE patient_id = @PatinetId;";
	MySqlParameter itemIdParameter = new MySqlParameter();
	itemIdParameter.ParameterName = "@PatientId";
	itemIdParameter.Value = this.GetId();
	cmd.Parameters.Add(itemIdParameter);
	cmd.ExecuteNonQuery();
	if(conn != null)
	{
		conn.Close();
	}
}


}
}
