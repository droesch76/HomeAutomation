using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Text;

namespace HomeAutomation
{
    public class Broker
    {
        SqlConnection conn;
        SqlCommand cmd;

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
            cmd = conn.CreateCommand();
        }

        public Broker()
        {
            ConnectToDb();
        }

        public DataSet QueryToDataSet(string Query, string Parameter = null)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = Query;
            if (Parameter != null)
            {
                cmd.Parameters.AddWithValue("@p", Parameter);
            }
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }

        public string QueryToJSON(string Query, string Parameter = null)
        {
            DataSet ds = QueryToDataSet(Query, Parameter);
            DataTable table = ds.Tables[0];
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(list);
        }

        public int InsertStatus(string n, string a)
        {
            try
            {
                cmd.CommandText = "INSERT INTO hStatus (sta_name, sta_action) VALUES (@n, @a)";
                cmd.Parameters.AddWithValue("n", n);
                cmd.Parameters.AddWithValue("a", a);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
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
            return QueryToJSON("SELECT * FROM hStatusCurrentV where sta_name = @p", n);
        }

        public int InsertEvent(string l, string t, string d)
        {
            try
            {
                cmd.CommandText = "INSERT INTO hEvent (eve_location, eve_type, eve_description) VALUES (@l, @t, @d)";
                cmd.Parameters.AddWithValue("l", l);
                cmd.Parameters.AddWithValue("t", t);
                cmd.Parameters.AddWithValue("d", d);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
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
            return QueryToJSON("SELECT * FROM hStatusCurrentV where sta_name = @p", l);
        }

        public int InsertEnvironment(string l, string s, string t, string u, string r)
        {
            try
            {
                cmd.CommandText = "INSERT INTO hEnvironment (env_location, env_sensor, env_type, env_unit, env_reading) VALUES (@l, @s, @t, @u, @r)";
                cmd.Parameters.AddWithValue("l", l);
                cmd.Parameters.AddWithValue("s", s);
                cmd.Parameters.AddWithValue("t", t);
                cmd.Parameters.AddWithValue("u", u);
                cmd.Parameters.AddWithValue("r", r);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
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
            return QueryToJSON("SELECT * FROM hEnvrionmentCurrentV where env_location = @p", l);
        }

    }
}