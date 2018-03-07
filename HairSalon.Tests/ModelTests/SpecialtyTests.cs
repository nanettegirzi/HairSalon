using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nanette_girzi_test;";
        }
        public void Dispose()
        {
            Stylist.DeleteAllStylists();
            Specialty.DeleteAllSpecialties();
        }

        [TestMethod]
        public void Equals_OverrideTrueForSame_Specialty()
        {
            //Arrange, Act
            Specialty firstSpecialty = new Specialty("cut");
            Specialty secondSpecialty = new Specialty("cut");

            //Assert
            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void GetSpecialty_ReturnsSpecialty_String()
        {
            string specialty = "perm";
            Specialty newSpecialty = new Specialty(specialty);

            string result = newSpecialty.GetSpecialty();

            Assert.AreEqual(specialty, result);
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase_SpecialtyList()
        {
            Specialty testSpecialty = new Specialty("color");
            testSpecialty.SaveSpecialty();
            //Act
            List<Specialty> result = Specialty.GetAllSpecialties();
            List<Specialty> testList = new List<Specialty>{testSpecialty};

            CollectionAssert.AreEqual(testList, result);
        }


        [TestMethod]
        public void GetAll_SpecialtiesEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Specialty.GetAllSpecialties().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsSpecialties_SpecialtyList()
        {
            string specialty01 = "specialty01";
            string specialty02 = "specialty02";


            Specialty newSpecialty1 = new Specialty(specialty01);
            Specialty newSpecialty2 = new Specialty(specialty02);
            newSpecialty1.SaveSpecialty();
            newSpecialty2.SaveSpecialty();
            List<Specialty> newSpecialty = new List<Specialty> { newSpecialty1, newSpecialty2 };

            List<Specialty> result = Specialty.GetAllSpecialties();

            CollectionAssert.AreEqual(newSpecialty, result);
        }

        public void Find_FindsSpecialtyinDatabase_Specialty()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("perm");
            testSpecialty.SaveSpecialty();

            //Act
            Specialty foundSpecialty = Specialty.FindSpecialty(testSpecialty.GetSpecialtyId());

            //Assert
            Assert.AreEqual(testSpecialty, foundSpecialty);
        }



        [TestMethod]
        public void Edit_DeleteSpecialtyInDatabase_Int()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("specialty");
            testSpecialty.SaveSpecialty();


            //Act
            Specialty result = Specialty.FindSpecialty(testSpecialty.GetSpecialtyId());
            Assert.AreEqual(testSpecialty, result);
            testSpecialty.DeleteSpecialty();


            //Assert
            Assert.AreEqual(0, Specialty.GetAllSpecialties().Count);

        }

        [TestMethod]
        public void AddStylist_AddsStylisttoSpecialty_StylistList()
        {
            //Arrange
            Specialty testSpecialty = new Specialty ("test special");
            testSpecialty.SaveSpecialty();

            Stylist testStylist = new Stylist ("Nan Girzi", "$105/HR");
            testStylist.SaveStylist();

            //Acttest
            testSpecialty.AddStylist(testStylist);

            List<Stylist> result = testSpecialty.GetStylists();
            List<Stylist> testList = new List<Stylist>{testStylist};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetStylists_ReturnsAllSpecialtyStylists_StylistList()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("cut/color");
            testSpecialty.SaveSpecialty();

            Stylist testStylist1 = new Stylist("Nan L Girzi", "$50/HR");
            testStylist1.SaveStylist();

            Stylist testStylist2 = new Stylist("Mary Girzi", "$75/HR");
            testStylist2.SaveStylist();

            //Act
            testSpecialty.AddStylist(testStylist1);
            List<Stylist> result = testSpecialty.GetStylists();
            List<Stylist> testList = new List<Stylist> {testStylist1};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }


    }
}
