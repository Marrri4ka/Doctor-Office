using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace DoctorOffice.Models
{
public class Doctor
{
private string _name;

private int _id;
public Doctor(string name, int id = 0)
{
	_name = name;

	_id = id;
}
public override bool Equals(System.Object otherDoctor)
{
	if (!(otherDoctor is Doctor))
	{
		return false;
	}
	else
	{
		Doctor newDoctor = (Doctor) otherDoctor;
		bool idEquality = this.GetId().Equals(newDoctor.GetId());
		bool nameEquality = this.GetName().Equals(newDoctor.GetName());

		return (idEquality && nameEquality);
	}
}
public override int GetHashCode()
{
	return this.GetId().GetHashCode();
}
public string GetName()
{
	return _name;
}
public int GetId()
{
	return _id;
}



public void Save()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();

	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"INSERT INTO doctor (name) VALUES (@name);";

	MySqlParameter name = new MySqlParameter();
	name.ParameterName = "@name";
	name.Value = this._name;
	cmd.Parameters.Add(name);



	cmd.ExecuteNonQuery();
	_id = (int) cmd.LastInsertedId;
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}

}


public static List<Doctor> GetAll()
{
	List<Doctor> allDoctors = new List<Doctor> {
	};
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT * FROM doctor;";
	var rdr = cmd.ExecuteReader() as MySqlDataReader;
	while(rdr.Read())
	{
		int DoctorId = rdr.GetInt32(0);
		string DoctorName = rdr.GetString(1);
		Doctor newDoctor = new Doctor(DoctorName, DoctorId);
		allDoctors.Add(newDoctor);
	}
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
	return allDoctors;
}



public static Doctor Find(int id)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT * FROM doctor WHERE id = (@searchId);";

	MySqlParameter searchId = new MySqlParameter();
	searchId.ParameterName = "@searchId";
	searchId.Value = id;
	cmd.Parameters.Add(searchId);

	var rdr = cmd.ExecuteReader() as MySqlDataReader;
	int DoctorId = 0;
	string DoctorName = "";

	while(rdr.Read())
	{
		DoctorId = rdr.GetInt32(0);
		DoctorName = rdr.GetString(1);
	}
	Doctor newDoctor = new Doctor(DoctorName, DoctorId);
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
	return newDoctor;
}
public static void DeleteAll()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"DELETE FROM doctor;";
	cmd.ExecuteNonQuery();
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
}

public void Delete()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand( "DELETE FROM doctor WHERE id = @DoctorId; DELETE FROM doctors_patients WHERE doctor_id = @DoctorId;", conn);
	MySqlParameter doctorIdParameter = new MySqlParameter();
	doctorIdParameter.ParameterName = "@DoctorId";
	doctorIdParameter.Value = this.GetId();
	cmd.Parameters.Add(doctorIdParameter);
	cmd.ExecuteNonQuery();

	if (conn != null)
	{
		conn.Close();
	}
}


public List<Patient> GetPatients()
{

	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT patient. * FROM doctor
            JOIN doctors_patients ON (doctor.id = doctors_patients.doctor_id)
            JOIN patient ON (doctors_patients.patient_id = patient.id)
            WHERE doctor.id = @DoctorId;";
	MySqlParameter doctorIdParameter = new MySqlParameter();
	doctorIdParameter.ParameterName = "@DoctorId";
	doctorIdParameter.Value = _id;
	cmd.Parameters.Add(doctorIdParameter);
	MySqlDataReader patientQueryRdr = cmd.ExecuteReader() as MySqlDataReader;
	List<Patient> patients = new List<Patient> {
	};

	while(patientQueryRdr.Read())
	{
		int thisPatientId = patientQueryRdr.GetInt32(0);
		string patientName = patientQueryRdr.GetString(1);
		DateTime patientBirthday = patientQueryRdr.GetDateTime(2);
		Patient newPatient= new Patient (patientName,patientBirthday,thisPatientId);
		patients.Add (newPatient);
	}

	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
	return patients;
}


public int CountPatients()
{

	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT COUNT(*) FROM doctor
            JOIN doctors_patients ON (doctor.id = doctors_patients.doctor_id)
            JOIN patient ON (doctors_patients.patient_id = patient.id)
            WHERE doctor.id = @DoctorId;";
	MySqlParameter doctorIdParameter = new MySqlParameter();
	doctorIdParameter.ParameterName = "@DoctorId";
	doctorIdParameter.Value = _id;
	cmd.Parameters.Add(doctorIdParameter);
	MySqlDataReader patientQueryRdr = cmd.ExecuteReader() as MySqlDataReader;

	int patients = 0;

	while(patientQueryRdr.Read())
	{
		patients= patientQueryRdr.GetInt32(0);

	}

	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
	return patients;
}

public static void ClearAll()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"DELETE FROM doctor;";
	cmd.ExecuteNonQuery();

	conn.Close();
	if(conn != null)
	{
		conn.Dispose();
	}
}

public void Edit(string newName)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"UPDATE doctor SET name = @newName WHERE id = @searchId;";
	MySqlParameter searchId = new MySqlParameter();
	searchId.ParameterName = "@searchId";
	searchId.Value = _id;
	cmd.Parameters.Add(searchId);
	MySqlParameter name = new MySqlParameter();
	name.ParameterName = "@newName";
	name.Value = newName;
	cmd.Parameters.Add(name);
	cmd.ExecuteNonQuery();
	_name = newName; // <--- This line is new!
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
}

public void Dispose()
{
	Doctor.ClearAll();
	Patient.DeleteAll();
}
public void AddPatient (Patient newPatient)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"INSERT INTO doctors_patients (doctor_id, patient_id) VALUES (@DoctorId, @PatientId);";
	MySqlParameter doctor_id = new MySqlParameter();
	doctor_id.ParameterName = "@DoctorId";
	doctor_id.Value = _id;
	cmd.Parameters.Add(doctor_id);
	MySqlParameter patient_id = new MySqlParameter();
	patient_id.ParameterName = "@PatientId";
	patient_id.Value = newPatient.GetId();
	cmd.Parameters.Add(patient_id);
	cmd.ExecuteNonQuery();
	conn.Close();
	if(conn != null)
	{
		conn.Dispose();
	}
}
}
}
