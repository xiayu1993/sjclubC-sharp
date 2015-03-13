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
    public class UsersDAL : IUsersDAL
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public IList<T_Users> GetUsers()
        {
            IList<T_Users> list = new List<T_Users>();

            string str_sql = @"select *
                    from dbo.T_Users;";
            SqlDataReader data = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql);

            while (data.Read())
            {
                T_Users mode_Users = new T_Users();
                mode_Users.Id = Guid.Parse(data["Id"].ToString());

                if (data["Number"] is DBNull)
                    mode_Users.Number = null;
                else
                    mode_Users.Number = Convert.ToInt64(data["Number"]);

                mode_Users.Status = new Guid(data["Status"].ToString());
                mode_Users.Name = data["Name"] == null ? string.Empty : data["Name"].ToString();
                mode_Users.Account = data["Account"] == null ? string.Empty : data["Account"].ToString();
                mode_Users.Password = data["Password"] == null ? string.Empty : data["Password"].ToString();

                if (data["Sex"] is DBNull)
                    mode_Users.Sex = null;
                else
                    mode_Users.Sex = Convert.ToBoolean(data["Sex"]);

                mode_Users.Birthday = data["Birthday"] == null ? string.Empty : data["Birthday"].ToString();
                mode_Users.Introducation = data["Introducation"] == null ? string.Empty : data["Introducation"].ToString();
                mode_Users.Academy = data["Academy"] == null ? string.Empty : data["Academy"].ToString();
                mode_Users.IsInSchool = Convert.ToBoolean(data["IsInSchool"]);
                mode_Users.TrueName = data["TrueName"] == null ? string.Empty : data["TrueName"].ToString();

                list.Add(mode_Users);
            }

            return list;
        }

        public T_Users GetUsersById(Guid id)
        {
            T_Users user;

            string str_sql = @"select *
                            from dbo.T_Users 
                            where dbo.T_Users.Id = @id;";
            
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };

            SqlDataReader data = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param);

            //只读取一行
            if (data.Read())
            {
                user = new T_Users();
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
            }
            else
                user = null;

            return user;
        }

        public int DeleteUsersById(Guid id)
        {
            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();

            string str_sql = @"delete from dbo.T_Users 
                    where id= @id;";

            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);

            cmd.Parameters.AddWithValue("@id", id);

            int i = cmd.ExecuteNonQuery();

            str_sqlcnn.Close();

            return i;
        }

        public int ChangeUserPassword(string id, string newPassword)
        {
            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();

            string str_sql = @"update dbo.T_Users
                        set dbo.T_Users.Password= @newPassword
                        where id= @id;";

            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);

            cmd.Parameters.AddWithValue("@id", Guid.Parse(id));
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            int i = cmd.ExecuteNonQuery();

            str_sqlcnn.Close();
            return i;
        }

        public int ChangeUserInformation(T_Users user)
        {
            string str_sql = @"update dbo.T_Users
                    set dbo.T_Users.Name =  @Name,
	                dbo.T_Users.Sex = @Sex,
	                dbo.T_Users.Birthday = @Birthday,
	                dbo.T_Users.Introducation = @Introducation,
	                dbo.T_Users.Number = @Number,
	                dbo.T_Users.TrueName = @TrueName,
	                dbo.T_Users.Academy = @Academy
                    where dbo.T_Users.Id = @Id;";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Sex", user.Sex),
                new SqlParameter("@Birthday", user.Birthday),
                new SqlParameter("@Introducation", user.Introducation),
                new SqlParameter("@Number", user.Number),
                new SqlParameter("@TrueName", user.TrueName),
                new SqlParameter("@Academy", user.Academy)
            };

            int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);
            return count;
        }

        public Guid QueryIdByAccount(string userAccount)
        {
            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();

            string str_sql = @"select dbo.T_Users.Id
                            from dbo.T_Users
                            where dbo.T_Users.Account = @userAccount;";
            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);

            cmd.Parameters.AddWithValue("@userAccount", userAccount);

            Guid userId = cmd.ExecuteScalar() == null ? Guid.Empty: Guid.Parse(cmd.ExecuteScalar().ToString());
            return userId;
        }

        public int SetUserRank(Guid userId, int rank)
        {
            string str_sql = @"update dbo.T_Users
                        set dbo.T_Users.Status =
                        (
                        select Id
                        from dbo.T_Status
                        where dbo.T_Status.Rank = @rank
                        )
                        where Id = @userId;";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@userId", userId),
                new SqlParameter("@rank", rank),
            };

            int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);

            return count;
        }

        public bool QueryUser(string account)
        {
            bool exist;

            string str_sql = @"select dbo.T_Users.Id
                    from dbo.T_Users
                    where dbo.T_Users.Account = @account;";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@account", account)
            };

            using (SqlDataReader datar = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param))
            {
                //只读一行数据
                if (datar.Read())
                    exist = true;
                else
                    exist = false;
            }

            return exist;
        }
    }
}
