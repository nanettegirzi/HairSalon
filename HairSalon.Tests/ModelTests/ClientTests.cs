using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAllClients();
      Stylist.DeleteAllStylists();
      Specialty.DeleteAllSpecialties();
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nanette_girzi_test;";
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      int result = Client.GetAllClients().Count;

      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_DatabaseSavesListOfAllClients_ClientList()
    {
      Client testClient = new Client("Nano Berthold", "ngirzi@gmail.com", 1, 1);
      testClient.SaveClient();
      Client testClient2 = new Client("Drea Girzi", "123@me.com", 2, 2);
      testClient2.SaveClient();

      //Act
      List<Client> result = Client.GetAllClients();
      List<Client> testList = new List<Client>{testClient, testClient2};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_FindsClientInDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Steve Miller" ,"email@me.com", 1, 1);
      testClient.SaveClient();

      //Act
      Client foundClient = Client.FindClient(testClient.GetClientId());

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    // [TestMethod]
    // public void Edit_UpdatesClientInDatabase_String()
    // {
    //   Client testClient = new Client("Cliff Mass","me@mac.com", 1, 1);
    //   testClient.SaveClient();
    //   Client secondClient = new Client ("Amy Miller", "email@email.com", 1, 1);
    //
    //   testClient.UpdateClient("Cliff M Miller", "emails@me.com");
    //
    //   Assert.AreEqual(testClient, secondClient);
    // }
}
}
