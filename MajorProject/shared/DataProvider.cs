using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MajorProject.shared
{
    public class DataProvider
    {
        public static DataSet retrieveDataSet(string s,string u)
        {
            try
            {MySqlConnection con1 = new MySqlConnection("server=localhost; database=minorproject; uid=root; pwd=;");
        MySqlCommand cmd;
        con1.Open();
                DataSet d = new DataSet();
                cmd = new MySqlCommand(s, con1);
                cmd.Parameters.AddWithValue("id",u);
                MySqlDataAdapter sdr = new MySqlDataAdapter(cmd);
                sdr.Fill(d);
                con1.Close();
                return d;
            }
            catch (Exception){ return null;}
        }
        public static DataSet retrieveDataSet(string s)
        {
            MySqlConnection con1 = new MySqlConnection("server=localhost; database=minorproject; uid=root; pwd=;");
            MySqlCommand cmd;
            DataSet d = new DataSet();            
            cmd = new MySqlCommand(s, con1);
            try
            {
                con1.Open();

                MySqlDataAdapter sdr = new MySqlDataAdapter(cmd);
                sdr.Fill(d);
                con1.Close();
                return d;
            }
            catch (Exception ){  return null;    }
        }
        public static string retrieveString(string s)
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection("server=localhost; database=minorproject; uid=root; pwd=;");
                MySqlCommand cmd;
                con1.Open();
                cmd = new MySqlCommand(s, con1);
                string d = "";
                d = cmd.ExecuteScalar().ToString();
                con1.Close();
                return d;
            }
            catch (Exception){  return "";}
        }
        public static void nonQuery(string q,string p1="",string p2="") {
            try
            {
                MySqlConnection con1 = new MySqlConnection("server=localhost; database=minorproject; uid=root; pwd=;");
                MySqlCommand cmd = new MySqlCommand(q, con1);
            cmd.Parameters.AddWithValue("p1", p1);
            cmd.Parameters.AddWithValue("p2", p2);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
            }
            catch (Exception){}
        }
    }
}