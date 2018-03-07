using System;
using HairSalon;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Client
    {

        private int _id;
        private string _clientName;
        private int _stylistId;


        public Client(string clientName, int stylistId, int id = 0)
        {

            _id = id;
            _clientName = clientName;
            _stylistId = stylistId;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                return this.GetClientId().Equals(newClient.GetClientId());
            }
        }

        public override int GetHashCode()
        {
            return this.GetClientName().GetHashCode();
        }

        public string GetClientName()
        {
            return _clientName;
        }


        public int GetClientId()
        {
            return _id;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public static void DeleteAllClients()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void SaveClient()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (client_name, stylist_id) VALUES (@clientName, @stylist_id);";

            MySqlParameter clientName = new MySqlParameter();
            clientName.ParameterName = "@name";
            clientName.Value = this._clientName;
            cmd.Parameters.Add(clientName);

        //     MySqlParameter stylistId = new MySqlParameter();
        //     stylistId.ParameterName = "@stylist_id";
        //     stylistId.Value = this._stylistId;
        //     cmd.Parameters.Add(stylistId);
        //
        //     cmd.ExecuteNonQuery();
        //     _id = (int) cmd.LastInsertedId;
        //     conn.Close();
        //
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }
        //
        //
        // public static List<Client> GetAllClients()
        // {
        //     List<Client> allClients = new List<Client> {};
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT * FROM clients;";
        //     var rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     while(rdr.Read())
        //     {
        //         int clientId = rdr.GetInt32(0);
        //         string clientName = rdr.GetString(1);
        //         string clientEmail = rdr.GetString(2);
        //         int stylistId = rdr.GetInt32(3);
        //
        //         Client newClient = new Client(clientName, clientEmail, stylistId, clientId);
        //         allClients.Add(newClient);
        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return allClients;
        // }
        //
        //
        //
        // public static Client FindClient(int id)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT * FROM clients WHERE id = @thisId;";
        //
        //     MySqlParameter thisId = new MySqlParameter();
        //     thisId.ParameterName = "@thisId";
        //     thisId.Value = id;
        //     cmd.Parameters.Add(thisId);
        //
        //     var rdr = cmd.ExecuteReader() as MySqlDataReader;
        //
        //     int clientId = 0;
        //     string clientName = "";
        //     string clientEmail = "";
        //     int stylistId = 0;
        //
        //
        //     while (rdr.Read())
        //     {
        //         clientId = rdr.GetInt32(0);
        //         clientName = rdr.GetString(1);
        //         clientEmail = rdr.GetString(2);
        //         stylistId = rdr.GetInt32(3);
        //
        //     }
        //
        //     Client foundClient = new Client(clientName, clientEmail, stylistId, clientId);
        //
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //
        //     return foundClient;
        // }
        //
        // public void UpdateClient(string newClientName, string newClientEmail, int newStylistId)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"UPDATE clients SET client_name = @newClientName, client_email = @newClientEmail, stylist_id = @newStylistId WHERE id = @searchId;";
        //
        //     MySqlParameter searchId = new MySqlParameter();
        //     searchId.ParameterName = "@searchId";
        //     searchId.Value = _id;
        //     cmd.Parameters.Add(searchId);
        //
        //     MySqlParameter clientName = new MySqlParameter();
        //     clientName.ParameterName = "@newClientName";
        //     clientName.Value = newClientName;
        //     cmd.Parameters.Add(clientName);
        //
        //     MySqlParameter clientEmail = new MySqlParameter();
        //     clientEmail.ParameterName = "@newClientEmail";
        //     clientEmail.Value = newClientName;
        //     cmd.Parameters.Add(clientEmail);
        //
        //     MySqlParameter stylistId = new MySqlParameter();
        //     stylistId.ParameterName = "@newStylistId";
        //     stylistId.Value = newStylistId;
        //     cmd.Parameters.Add(stylistId);
        //
        //     cmd.ExecuteNonQuery();
        //     _clientName = newClientName;
        //     _clientEmail = newClientEmail;
        //     _stylistId = newStylistId;
        //
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }
        //
        // public void DeleteClient()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId; DELETE FROM clients_stylists WHERE client_id = @ClientId;";
        //
        //     MySqlParameter clientIdParameter = new MySqlParameter();
        //     clientIdParameter.ParameterName = "@ClientId";
        //     clientIdParameter.Value = this.GetClientId();
        //     cmd.Parameters.Add(clientIdParameter);
        //
        //     cmd.ExecuteNonQuery();
        //
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }
        //
        //
        // public List<Stylist> GetStylists()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT * FROM stylists WHERE client_id = @clientId;";
        //
        //     MySqlParameter clientIdParameter = new MySqlParameter();
        //     clientIdParameter.ParameterName = "@clientId";
        //     clientIdParameter.Value = _id;
        //     cmd.Parameters.Add(clientIdParameter);
        //
        //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     List<Stylist> stylists = new List<Stylist>{};
        //
        //     while(rdr.Read())
        //     {
        //         int stylistId = rdr.GetInt32(0);
        //         string stylistName= rdr.GetString(1);
        //         string stylistRate = rdr.GetString(2);
        //
        //         Stylist newStylist = new Stylist(stylistName, stylistRate, stylistId);
        //         stylists.Add(newStylist);
        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return stylists;
        // }

    }
}
