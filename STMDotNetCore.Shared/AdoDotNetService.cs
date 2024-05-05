using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace STMDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if(parameters is not null && parameters.Length > 0)
            {
                //foreach(var item in parameters)
                //{
                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}
                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());

                var parameterArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray(); // convert to array param
                cmd.Parameters.AddRange(parameterArray);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            string  json  = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json)!;
            return list;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach(var item in parameters)
                //{
                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}
                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());

                var parameterArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray(); // convert to array param
                cmd.Parameters.AddRange(parameterArray);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json)!;
            return list[0];
        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            connection.Close();

            return result;
        }
    }

    public class AdoDotNetParameter
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public AdoDotNetParameter() { }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
