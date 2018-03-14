using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SimulationSystem.Models;
using System.Data;

namespace SimulationSystem.DAL
{
    public class MySql
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySql()
        {
            server = "studmysql01.fhict.local";
            database = "dbi310878";
            uid = "dbi310878";
            password = "Iie72-HD";

            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
    
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                return false;
            }
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        
        public int getCounter()
        {
            bool connected = this.OpenConnection();
            if (connected)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM counter", connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int counter = Convert.ToInt32(dataReader["counter"]);
                        return counter;
                    }
                    dataReader.Close();
                }
                catch (Exception e)
                {

                }
                finally
                {
                    this.CloseConnection();
                }

            }
            return 0;
        }
        
        

        public void insertTracker(Tracker tracker)
        {
            bool connected = this.OpenConnection();
            if (connected)
            {
                try
                {
                    string query = "INSERT INTO coordinates (trackerid, lat, lng, timestamp) VALUES(@trackerid, @lat, @lng, @timestamp)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@trackerid", tracker.trackerid);
                    cmd.Parameters.AddWithValue("@lat", tracker.lat);
                    cmd.Parameters.AddWithValue("@lng", tracker.lng);
                    cmd.Parameters.AddWithValue("@timestamp", tracker.timestamp);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        public Tracker getTracker(int id)
        {
            bool connected = this.OpenConnection();
            if (connected)
            {
                try
                {
                    string query = "SELECT * FROM coordinates WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Tracker tracker = new Tracker(Convert.ToString(dataReader["trackerid"]), Convert.ToDecimal(dataReader["lat"]), Convert.ToDecimal(dataReader["lng"]), Convert.ToInt64(dataReader["timestamp"]));
                        return tracker;
                    }
                    dataReader.Close();
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return null;
        }

        public void updateCounter(int counter)
        {
            bool connected = this.OpenConnection();
            if (connected)
            {
                try
                {
                    string query = "UPDATE counter SET counter = @counter WHERE id = 0";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@counter", counter);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }
    }
}