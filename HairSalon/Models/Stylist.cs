using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        private int _id;
        private string _stylistName;
        private string _stylistRate;

        public Stylist (string stylistName, string stylistRate, int id = 0)
        {
            _stylistName = stylistName;
            _stylistRate = stylistRate;
            _id = id;

        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetStylistId() == newStylist.GetStylistId();
                bool stylistNameEquality = this.GetStylistName() == newStylist.GetStylistName();
                bool stylistRateEquality = this.GetStylistRate() == newStylist.GetStylistRate();
                return (idEquality && stylistNameEquality && stylistRateEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetStylistId().GetHashCode();
        }

        public string GetStylistName()
        {
            return _stylistName;
        }

        public string GetStylistRate()
        {
            return _stylistRate;
        }

        public int GetStylistId()
        {
            return _id;
        }

        public static void DeleteAllStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAllStylists()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistRate = rdr.GetString(2);
                Stylist newStylist = new Stylist(stylistName, stylistRate, stylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public void SaveStylist()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (stylist_name, stylist_rate) VALUES (@StylistName, @StylistRate);";

            MySqlParameter stylistName = new MySqlParameter();
            stylistName.ParameterName = "@StylistName";
            stylistName.Value = this._stylistName;
            cmd.Parameters.Add(stylistName);

            MySqlParameter stylistRate = new MySqlParameter();
            stylistRate.ParameterName = "@StylistRate";
            stylistRate.Value = this._stylistRate;
            cmd.Parameters.Add(stylistRate);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist FindStylist(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int stylistId = 0;
            string stylistName = "";
            string stylistRate = "";

            while(rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
                stylistRate = rdr.GetString(2);
            }
            Stylist newStylist = new Stylist(stylistName, stylistRate, stylistId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newStylist;
        }

        public void UpdateStylist(string newStylistName, string newStylistRate)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET stylist_name = @newStylistName, stylist_rate = @newStylistRate WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);

            MySqlParameter stylistName = new MySqlParameter();
            stylistName.ParameterName = "@newStylistName";
            stylistName.Value = newStylistName;
            cmd.Parameters.Add(stylistName);

            MySqlParameter stylistRate = new MySqlParameter();
            stylistRate.ParameterName = "@newStylistRate";
            stylistRate.Value = newStylistRate;
            cmd.Parameters.Add(stylistRate);

            cmd.ExecuteNonQuery();
            _stylistName= newStylistName;
            _stylistRate = newStylistRate;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void DeleteStylist()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId; DELETE FROM specialty_stylists WHERE stylist_id = @StylistId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetStylistId();
            cmd.Parameters.Add(stylistIdParameter);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        public List<Client> GetClients()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@stylistId";
            stylistIdParameter.Value = _id;
            cmd.Parameters.Add(stylistIdParameter);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Client> clients = new List<Client>{};

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName= rdr.GetString(1);
                string clientEmail = rdr.GetString(2);

                Client newClient = new Client(clientName, clientEmail, clientId);
                clients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return clients;
        }

        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialty_stylists (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@StylistId";
            stylist_id.Value = _id;
            cmd.Parameters.Add(stylist_id);

            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@SpecialtyId";
            specialty_id.Value = newSpecialty.GetSpecialtyId();
            cmd.Parameters.Add(specialty_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        public List<Specialty> GetSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM stylists
            JOIN specialty_stylists ON (stylists.id = specialty_stylists.stylist_id)
            JOIN specialties ON (specialty_stylists.specialty_id = specialties.id)
            WHERE stylists.id = @StylistId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = _id;
            cmd.Parameters.Add(stylistIdParameter);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Specialty> specialties = new List<Specialty>{};

            while(rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string stylistSpecialty= rdr.GetString(1);


                Specialty newSpecialty = new Specialty(stylistSpecialty,  specialtyId);
                specialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return specialties;
        }


    }
}
