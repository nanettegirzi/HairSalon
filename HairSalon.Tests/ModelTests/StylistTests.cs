using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nanette_girzi_test;";
        }
        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAllStylists();
            Specialty.DeleteAllSpecialties();
        }


        [TestMethod]
        public void Equals_OverrideTrueForSameStylist_Stylist()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Nanette Girzi", "$100/HR");
            Stylist secondStylist = new Stylist("Nanette Girzi", "$100/HR");

            //Assert
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void GetStylistName_ReturnsStylistName_String()
        {
            string stylistName = "Nanette Girzi";
            string stylistRate = "$100/HR";
            Stylist newStylist = new Stylist(stylistName, stylistRate);

            string result = newStylist.GetStylistName();

            Assert.AreEqual(stylistName, result);
        }


        [TestMethod]
        public void GetAll_StylistsEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Stylist.GetAllStylists().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsStylists_StylistList()
        {
            string stylistName01 = "Heather Girzi";
            string stylistName02 = "Drea Berthold";
            string stylistRate01 = "$105/HR";
            string stylistRate02= "$65/HR";

            Stylist newStylist1 = new Stylist(stylistName01, stylistRate01);
            Stylist newStylist2 = new Stylist(stylistName02, stylistRate02);
            newStylist1.SaveStylist();
            newStylist2.SaveStylist();
            List<Stylist> newStylist = new List<Stylist> { newStylist1, newStylist2 };

            List<Stylist> result = Stylist.GetAllStylists();

            CollectionAssert.AreEqual(newStylist, result);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            Stylist testStylist = new Stylist("Megan Smith", "$70/HR");
            testStylist.SaveStylist();
            //Act
            List<Stylist> result = Stylist.GetAllStylists();
            List<Stylist> testList = new List<Stylist>{testStylist};

            CollectionAssert.AreEqual(testList, result);
        }

        public void Find_FindsStylistinDatabase_Stylist()
        {
            //Arrange
            Stylist testStylist = new Stylist("Erin Moore", "$70/HR");
            testStylist.SaveStylist();

            //Act
            Stylist foundStylist = Stylist.FindStylist(testStylist.GetStylistId());

            //Assert
            Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void Edit_UpdatesStylistInDatabase_String()
        {
            //Arrange
            string firstStylistName = "Red Miller";
            string firstStylistRate = "$50/HR";
            Stylist testStylist = new Stylist(firstStylistName, firstStylistRate);
            testStylist.SaveStylist();
            string secondStylistName = "Red W Miller";
            string secondStylistRate = "60/HR";

            //Act
            testStylist.UpdateStylist(secondStylistName, secondStylistRate);

            Stylist result = Stylist.FindStylist(testStylist.GetStylistId());

            //Assert
            Assert.AreEqual(testStylist, result);
        }

        [TestMethod]
        public void Edit_DeleteStylistInDatabase_Int()
        {
            //Arrange
            Stylist testStylist = new Stylist("Nan Brown", "$60/HR");
            testStylist.SaveStylist();


            //Act
            Stylist result = Stylist.FindStylist(testStylist.GetStylistId());
            Assert.AreEqual(testStylist, result);
            testStylist.DeleteStylist();


            //Assert
            Assert.AreEqual(0, Stylist.GetAllStylists().Count);

        }

        [TestMethod]
        public void Test_AddSpecialty_AddsSpecialtyToStylist()
        {
            //Arrange
            Stylist testStylist = new Stylist("Moe Green", "$50/HR");
            testStylist.SaveStylist();

            Specialty testSpecialty = new Specialty("Cut");
            testSpecialty.SaveSpecialty();

            Specialty testSpecialty2 = new Specialty("Color");
            testSpecialty2.SaveSpecialty();

            //Act
            testStylist.AddSpecialty(testSpecialty);
            testStylist.AddSpecialty(testSpecialty2);

            List<Specialty> result = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty>{testSpecialty, testSpecialty2};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetSpecialty_ReturnsAllStylistSpecialties_StylistList()
        {
            //Arrange
            Stylist testStylist = new Stylist("Beth Moore","$50/HR");
            testStylist.SaveStylist();

            Specialty testSpecialty1 = new Specialty("blow dry");
            testSpecialty1.SaveSpecialty();

            Specialty testSpecialty2 = new Specialty("perm");
            testSpecialty2.SaveSpecialty();

            //Act
            testStylist.AddSpecialty(testSpecialty1);
            List<Specialty> savedSpecialties = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty> {testSpecialty1};

            //Assert
            CollectionAssert.AreEqual(testList, savedSpecialties);
        }


    }
}
