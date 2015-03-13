using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.IDataAccessLayer;
using SJmedia.Model;
using System.Configuration;
using System.Data.SqlClient;
using BookDAL;
using System.Data;

namespace SJmedia.SQLSeverDAL
{
    public class StatusDAL : IStatusDAL
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public Model.T_Status GetStatusById(Guid id)
        {
            T_Status status = new T_Status();
            string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();
            string str_sql = @"select *
                    from dbo.T_Status
                    where dbo.T_Status.Id = @id;";
            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                status.Rank = Convert.ToInt32(data["Rank"]);
                status.Type = data["Type"].ToString();
                status.Id = new Guid(data["Id"].ToString());
            }

            str_sqlcnn.Close();
            return status;
        }

        public int AddStatusById(string StatusName, int StatusRank)
        {
            throw new NotImplementedException();
        }

        public int DeleteStatusById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<T_Status> GetStatus()
        {
            IList<T_Status> list = new List<T_Status>();
            string str_sql = "select * from dbo.T_Status;";

            SqlDataReader reader = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql);

            while (reader.Read())
            {
                T_Status status = new T_Status();
                status.Rank = Convert.ToInt32(reader["Rank"]);
                status.Type = reader["Type"].ToString();
                status.Id = new Guid(reader["Id"].ToString());

                list.Add(status);
            }

            return list;
        }
    }
}
