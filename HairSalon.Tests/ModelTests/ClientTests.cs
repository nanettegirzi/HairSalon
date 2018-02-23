using System;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {
        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nanette_girzi_test;";
        }
        public void Dispose()
        {
            Client.DeleteAll();
            // Stylist.DeleteAll();
        }
        [TestMethod]
        public void GetAllClients_DatabaseEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Equals_OverrideTrueIfClientsAreIdentical_Client()
        {
            //Arrange, Act
            Client firstClient = new Client("Brenda", 1, 1);
            Client secondClient = new Client("Brenda", 1, 1);

            //Assert
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void GetName_ReturnName_String()
        {
            string name= "Andy Smith";
            Client newClient = new Client(name);

            string result = newClient.GetName();

            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void Save_SavesClientToDatabase_ClientList()
        {
            Client testClient = new Client("Andy Smith", 1);
            testClient.Save();
            //Act
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsClientInDatabase_Client()
        {
            //Arrange
            Client testClient = new Client("Andy Smith", 1);
            testClient.Save();

            //Act
            Client foundClient = Client.Find(testClient.GetId());

            //Assert
            Assert.AreEqual(testClient, foundClient);
        }

        [TestMethod]
        public void Edit_UpdatesClientInDatabase_String()
        {
            //Arrange
            string firstName = "Doug Jones";
            Client testClient = new Client(firstName, 1);
            testClient.Save();
            string secondName = "Sara Miller";

            //Act
            testClient.Edit(secondName);

            string result = Client.Find(testClient.GetId()).GetName();

            //Assert
            Assert.AreEqual(secondName, result);
        }

    }
}
