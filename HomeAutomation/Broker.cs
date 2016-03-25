using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace HomeAutomation
{
    public class Broker
    {
        SqlConnection conn;
        SqlCommand comm;

        SqlConnectionStringBuilder connStringBuilder;

        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DREWHS,11000";
            connStringBuilder.InitialCatalog = "Home";
            connStringBuilder.UserID = "api_user";
            connStringBuilder.Password = "Ap|$123";
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        public Broker()
        {
            ConnectToDb();
        }

        public int InsertStatus(string n, string a)
        {
            try
            {
                comm.CommandText = "INSERT INTO hStatus (sta_name, sta_action) VALUES (@n, @a)";
                comm.Parameters.AddWithValue("n", n);
                comm.Parameters.AddWithValue("a", a);
                comm.CommandType = CommandType.Text;
                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public string QueryStatus(string n)
        {
            return "status " + n;
        }

        public int InsertEvent(string l, string t, string d)
        {
            try
            {
                comm.CommandText = "INSERT INTO hEvent (eve_location, eve_type, eve_description) VALUES (@l, @t, @d)";
                comm.Parameters.AddWithValue("l", l);
                comm.Parameters.AddWithValue("t", t);
                comm.Parameters.AddWithValue("d", d);
                comm.CommandType = CommandType.Text;
                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public string QueryEvent(string l)
        {
            return "event " + l;
        }

        public int InsertEnvironment(string l, string s, string t, string u, string r)
        {
            try
            {
                comm.CommandText = "INSERT INTO hEnvironment (env_location, env_sensor, env_type, env_unit, env_reading) VALUES (@l, @s, @t, @u, @r)";
                comm.Parameters.AddWithValue("l", l);
                comm.Parameters.AddWithValue("s", s);
                comm.Parameters.AddWithValue("t", t);
                comm.Parameters.AddWithValue("u", u);
                comm.Parameters.AddWithValue("r", r);
                comm.CommandType = CommandType.Text;
                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public string QueryEnvironment(string l)
        {
            return "environment " + l;
        }

    }
}