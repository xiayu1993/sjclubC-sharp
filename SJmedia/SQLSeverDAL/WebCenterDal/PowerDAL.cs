using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.IDataAccessLayer;
using SJmedia.Model;
using System.Configuration;
using BookDAL;
using System.Data.SqlClient;
using System.Data;

namespace SJmedia.SQLSeverDAL
{
    public class PowerDAL : IPowerDAL
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public IList<T_FunctionAuthority> GetFunctionAuthority()
        {
            IList<T_FunctionAuthority> list = new List<T_FunctionAuthority>();

            string str_sql = "select * from dbo.T_FunctionAuthority order by Num;";

            SqlDataReader reader = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql);

            while (reader.Read())
            {
                T_FunctionAuthority functionAuthority = new T_FunctionAuthority();
                functionAuthority.Id = Guid.Parse(reader["Id"].ToString());
                functionAuthority.BackMenuId = Guid.Parse(reader["BackMenuId"].ToString());
                functionAuthority.FunctionName = reader["FunctionName"].ToString();
                functionAuthority.Num = Convert.ToInt32(reader["Num"]);

                list.Add(functionAuthority);
            }

            return list;
        }

        public int DeleteBackMenuAndUsersByRank(Guid rankId)
        {
            string str_sql = @"delete from dbo.T_BackMenuAndUsers
                        where dbo.T_BackMenuAndUsers.StatusId = @rankId;";

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@rankId", rankId) };

            int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);

            return count;
        }

        public int AddBackMenuAndUsersByRank(Guid rankId, IList<Guid> menuIdList)
        {
            if (menuIdList.Count > 0)
            {
                StringBuilder str_sql = new StringBuilder();
                str_sql.Append("insert into dbo.T_BackMenuAndUsers values");

                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@rankId", rankId) };
                foreach (Guid menuId in menuIdList)
                {
                    str_sql.Append("(NEWID(),@rankId,'" + menuId + "'),");
                }

                str_sql.Remove(str_sql.Length - 1, 1).Append(";");

                int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql.ToString(), param);

                return count;
            }
            else
                return 0;
        }

        public object CheckPower(Guid rankId, Guid functionId)
        {
            string str_sql = @"select Id 
                from dbo.T_BackMenuAndUsers
                where StatusId = @rankId
                and BackMenuId = @functionId;";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@rankId", rankId),
                new SqlParameter("@functionId", functionId)
            };

            object id = SqlHelper.ExecuteScalar(str_cnn, CommandType.Text, str_sql.ToString(), param);

            return id;
        }
    }
}
