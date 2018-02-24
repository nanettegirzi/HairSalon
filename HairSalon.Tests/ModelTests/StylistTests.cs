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
       public void GetAllStylists_StylistsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAllStylists().Count;

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
      public void SaveStylist_SavesStylistToDatabase_StylistList()
      {
        //Arrange
        Stylist testStylist = new Stylist("Megan Smith");
        testStylist.SaveStylist();

        //Act
        List<Stylist> result = Stylist.GetAllStylists();
        List<Stylist> testList = new List<Stylist>{testStylist};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }

      [TestMethod]
     public void SaveStylist_DatabaseAssignsIdToStylist_Id()
     {
       //Arrange
       Stylist testStylist = new Stylist("Joe Anderson");
       testStylist.SaveStylist();

       //Act
       Stylist savedStylist = Stylist.GetAllStylists()[0];

       int result = savedStylist.GetId();
       int testId = testStylist.GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Joe Smith");
      testStylist.SaveStylist();

      //Act
      Stylist foundStylist = Stylist.FindStylist(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }

    // [TestMethod]
    // public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    // {
    //   Stylist testStylist = new Stylist("Mindy Smith", 0);
    //   testStylist.SaveStylist();
    //
    //   Client firstClient = new Client("Cliff Mass", testStylist.GetId());
    //   firstClient.Save();
    //   Client secondClient = new Client("Heather Girzi", testStylist.GetId());
    //   secondClient.Save();
    //
    //
    //   List<Client> testClientList = new List<Client> {firstClient, secondClient};
    //   List<Client> resultClientList = testStylist.GetClients();
    //
    //   CollectionAssert.AreEqual(testClientList, resultClientList);
    // }
    }
}
