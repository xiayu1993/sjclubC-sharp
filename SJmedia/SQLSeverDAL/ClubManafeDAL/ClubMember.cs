using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.IDataAccessLayer;
using System.Configuration;
using System.Data.SqlClient;
using BookDAL;
using System.Data;
using SJmedia.Model;

namespace SJmedia.SQLSeverDAL
{
    public class ClubMember : IClubMember
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public IList<T_Users> GetAllClubMember(Guid clubId)
        {
            string str_sql = @"select u.Id,u.Academy,u.Account,u.Birthday,u.Introducation,u.Isinschool,u.Name,u.Number,u.Password,u.Sex,u.Status,u.TrueName,s.Rank
                        from dbo.T_ClubAndUsers c inner join dbo.T_Users u on c.Users = u.Id
                        inner join dbo.T_Status s on u.Status = s.Id
                        where c.Club = @clubId
                        order by s.Rank desc;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@clubId", clubId) };

            SqlDataReader data = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param);

            IList<T_Users> list = new List<T_Users>();

            while(data.Read())
            {
                T_Users user = new T_Users();

                user.Id = Guid.Parse(data["Id"].ToString());

                if (data["Number"] is DBNull)
                    user.Number = null;
                else
                    user.Number = Convert.ToInt64(data["Number"]);

                user.Status = new Guid(data["Status"].ToString());
                user.Name = data["Name"] == null ? string.Empty : data["Name"].ToString();
                user.Account = data["Account"] == null ? string.Empty : data["Account"].ToString();
                user.Password = data["Password"] == null ? string.Empty : data["Password"].ToString();

                if (data["Sex"] is DBNull)
                    user.Sex = null;
                else
                    user.Sex = Convert.ToBoolean(data["Sex"]);

                user.Birthday = data["Birthday"] == null ? string.Empty : data["Birthday"].ToString();
                user.Introducation = data["Introducation"] == null ? string.Empty : data["Introducation"].ToString();
                user.Academy = data["Academy"] == null ? string.Empty : data["Academy"].ToString();
                user.IsInSchool = Convert.ToBoolean(data["IsInSchool"]);
                user.TrueName = data["TrueName"] == null ? string.Empty : data["TrueName"].ToString();

                list.Add(user);
            }

            return list;
        }
    }
}
