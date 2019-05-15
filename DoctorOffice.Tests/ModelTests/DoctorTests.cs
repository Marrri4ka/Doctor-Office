using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoctorOffice.Models;
using System.Collections.Generic;
using System;

namespace DoctorOffice.Tests
{
[TestClass]
public class DoctorTest : IDisposable
{

public DoctorTest()
{
	DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=doctor_office_test;";
}

public void Dispose()
{
	Doctor.ClearAll();
	Patient.DeleteAll();
}


[TestMethod]
public void GetName_ReturnsName_String()
{

	string name = "Doctor";
	Doctor newDoctor = new Doctor(name);
	string result = newDoctor.GetName();
	Assert.AreEqual(name, result);
}


[TestMethod]
public void GetAll_ReturnsAllDoctors()
{

	string name01 = "Mark";
	string name02 = "Steve";
	Doctor newDoctor1 = new Doctor(name01);
	newDoctor1.Save();
	Doctor newDoctor2 = new Doctor(name02);
	newDoctor2.Save();
	List<Doctor> newList = new List<Doctor> {
		newDoctor1, newDoctor2
	};
	List<Doctor> result = Doctor.GetAll();
	CollectionAssert.AreEqual(newList, result);
}

[TestMethod]
public void Find_ReturnsCategoryInDatabase_Category()
{

	Doctor testDoctor = new Doctor("Jack");
	testDoctor.Save();
	Doctor foundDoctor = Doctor.Find(testDoctor.GetId());
	Assert.AreEqual(testDoctor, foundDoctor);
}


[TestMethod]
public void Count_PatientsFrom_OneDoctor()
{

	Doctor testDoctor = new Doctor("Jack");
	testDoctor.Save();
	Patient newPatient1 = new Patient ("Mark", new DateTime());
	newPatient1.Save();
	testDoctor.AddPatient(newPatient1);
	Patient newPatient2 = new Patient ("Erik", new DateTime());
	newPatient2.Save();
	testDoctor.AddPatient(newPatient2);
	Doctor foundDoctor = Doctor.Find(testDoctor.GetId());
	int result = foundDoctor.CountPatients();
	Assert.AreEqual(2, result);
}

// [TestMethod]
// public void GetItems_ReturnsEmptyItemList_ItemList()
// {
//      //Arrange
//      string name = "Work";
//      Category newCategory = new Category(name);
//      List<Item> newList = new List<Item> {
//      };
//
//      //Act
//      List<Item> result = newCategory.GetItems();
//
//      //Assert
//      CollectionAssert.AreEqual(newList, result);
// }
//
// [TestMethod]
// public void GetAll_CategoriesEmptyAtFirst_List()
// {
//      //Arrange, Act
//      int result = Category.GetAll().Count;
//
//      //Assert
//      Assert.AreEqual(0, result);
// }
//
// [TestMethod]
// public void Equals_ReturnsTrueIfNamesAreTheSame_Category()
// {
//      //Arrange, Act
//      Category firstCategory = new Category("Household chores");
//      Category secondCategory = new Category("Household chores");
//
//      //Assert
//      Assert.AreEqual(firstCategory, secondCategory);
// }
//
// [TestMethod]
// public void Save_SavesCategoryToDatabase_CategoryList()
// {
//      //Arrange
//      Category testCategory = new Category("Household chores");
//      testCategory.Save();
//
//      //Act
//      List<Category> result = Category.GetAll();
//      List<Category> testList = new List<Category> {
//              testCategory
//      };
//
//      //Assert
//      CollectionAssert.AreEqual(testList, result);
// }
//
// [TestMethod]
// public void Save_DatabaseAssignsIdToCategory_Id()
// {
//      //Arrange
//      Category testCategory = new Category("Household chores");
//      testCategory.Save();
//
//      //Act
//      Category savedCategory = Category.GetAll()[0];
//
//      int result = savedCategory.GetId();
//      int testId = testCategory.GetId();
//
//      //Assert
//      Assert.AreEqual(testId, result);
// }
//
// [TestMethod]
// public void Delete_DeletesCategoryAssociationsFromDatabase_CategoryList()
// {
//      //Arrange
//      Item testItem = new Item("Mow the lawn");
//      testItem.Save();
//      string testName = "Home stuff";
//      Category testCategory = new Category(testName);
//      testCategory.Save();
//
//      //Act
//      testCategory.AddItem(testItem);
//      testCategory.Delete();
//      List<Category> resultItemCategories = testItem.GetCategories();
//      List<Category> testItemCategories = new List<Category> {
//      };
//
//      //Assert
//      CollectionAssert.AreEqual(testItemCategories, resultItemCategories);
// }
//
// [TestMethod]
// public void Test_AddItem_AddsItemToCategory()
// {
//      //Arrange
//      Category testCategory = new Category("Household chores");
//      testCategory.Save();
//      Item testItem = new Item("Mow the lawn");
//      testItem.Save();
//      Item testItem2 = new Item("Water the garden");
//      testItem2.Save();
//
//      //Act
//      testCategory.AddItem(testItem);
//      testCategory.AddItem(testItem2);
//      List<Item> result = testCategory.GetItems();
//      List<Item> testList = new List<Item> {
//              testItem, testItem2
//      };
//
//      //Assert
//      CollectionAssert.AreEqual(testList, result);
// }
//
// [TestMethod]
// public void GetItems_ReturnsAllCategoryItems_ItemList()
// {
//      //Arrange
//      Category testCategory = new Category("Household chores");
//      testCategory.Save();
//      Item testItem1 = new Item("Mow the lawn");
//      testItem1.Save();
//      Item testItem2 = new Item("Buy plane ticket");
//      testItem2.Save();
//
//      //Act
//      testCategory.AddItem(testItem1);
//      List<Item> savedItems = testCategory.GetItems();
//      List<Item> testList = new List<Item> {
//              testItem1
//      };
//
//      //Assert
//      CollectionAssert.AreEqual(testList, savedItems);
// }

}
}
