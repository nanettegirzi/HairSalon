using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
  {
        public CategoryTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nanette_girzi_test;";
        }
        public void Dispose()
        {
            Client.DeleteAll();
            // Stylist.DeleteAll();
        }

        [TestMethod]
       public void GetAll_StylistsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

       [TestMethod]
      public void Equals_ReturnsTrueForSameName_Stylist()
      {
        //Arrange, Act
        Stylist firstStylist = new Stylist("Nanette Girzi");
        Stylist secondStylist = new Stylist("Nanette Girzi");

        //Assert
        Assert.AreEqual(firstStylist, secondStylist);
      }

      [TestMethod]
      public void Save_SavesSylistToDatabase_StylistList()
      {
        //Arrange
        Stylist testStylist = new Stylist("Megan Smith");
        testStylist.Save();

        //Act
        List<Stylist> result = Stylist.GetAll();
        List<Stylist> testList = new List<Stylist>{testStylist};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }
    }
}
