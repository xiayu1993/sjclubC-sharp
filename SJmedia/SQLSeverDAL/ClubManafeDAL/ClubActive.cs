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
    public class ClubActive : IClubActive
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public int AddClubActive(T_ClubActive clubActive)
        {
            string str_sql = @"insert into dbo.T_ClubActive
                values (@newid,@clubid,@head,@content,@time,@ActiveEndTime,null,@ActivePosterName);";

            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@newid",clubActive.Id),
                new SqlParameter("@clubid",clubActive.ClubId),
                new SqlParameter("@head",clubActive.ActiveHead),
                new SqlParameter("@content",clubActive.ActiveContent),
                new SqlParameter("@time",clubActive.ActiveTime),
                new SqlParameter("@ActiveEndTime",clubActive.ActiveEndTime),
                new SqlParameter("@ActivePosterName",clubActive.ActivePosterName)
            };

            int count = SqlHelper.ExecuteNonQuery(str_cnn,CommandType.Text,str_sql, param);
            return count;
        }

        public int DeleteClubActive(Guid clubId)
        {
            string str_sql = @"delete from dbo.T_ClubActive
                       where dbo.T_ClubActive.Id = @clubId;";

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@clubId", clubId) };

            return SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);
        }

        public IList<T_ClubActive> GetClubActiveListByUserId(Guid userId)
        {
            string str_sql = @"select a.Id,a.ClubId,a.ActiveHead,a.ActiveContent,a.ActiveTime,a.ActiveEndTime,a.ActivePosterRoute,a.ActivePosterName
                        from dbo.T_ClubActive a inner join dbo.T_ClubAndUsers u on a.ClubId = u.Club
                        where u.Users = @userId
                        order by a.ActiveTime desc;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@userId", userId) };

            SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param);

            IList<T_ClubActive> list = new List<T_ClubActive>();

            while (dater.Read())
            {
                T_ClubActive clubActive = new T_ClubActive();
                clubActive.Id = new Guid(dater["Id"].ToString());
                clubActive.ClubId = new Guid(dater["ClubId"].ToString());
                clubActive.ActiveHead = dater["ActiveHead"].ToString();
                clubActive.ActiveContent = dater["ActiveContent"].ToString();
                clubActive.ActiveTime = dater["ActiveTime"].ToString();
                DateTime dt;
                DateTime.TryParse(dater["ActiveEndTime"].ToString(), out dt);
                clubActive.ActiveEndTime = dt;
                clubActive.ActivePosterRoute = dater["ActivePosterRoute"].ToString();
                clubActive.ActivePosterName = dater["ActivePosterName"].ToString();

                list.Add(clubActive);
            }

            return list;
        }

        public T_ClubActive GetClubActiveDetail(Guid activeId)
        {
            string str_sql = @"select * from dbo.T_ClubActive
                where dbo.T_ClubActive.Id = @activeId;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@activeId", activeId) };

            SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param);

            T_ClubActive clubActive = new T_ClubActive();

            //只读取一行
            if(dater.Read())
            {
                clubActive.Id = new Guid(dater["Id"].ToString());
                clubActive.ClubId = new Guid(dater["ClubId"].ToString());
                clubActive.ActiveHead = dater["ActiveHead"].ToString();
                clubActive.ActiveContent = dater["ActiveContent"].ToString();
                clubActive.ActiveTime = dater["ActiveTime"].ToString();
                DateTime dt;
                DateTime.TryParse(dater["ActiveEndTime"].ToString(), out dt);
                clubActive.ActiveEndTime = dt;
                clubActive.ActivePosterRoute = dater["ActivePosterRoute"].ToString();
                clubActive.ActivePosterName = dater["ActivePosterName"].ToString();
            }

            return clubActive;
        }

        public int UpdateClubActive(Guid activeId, string activeHead, string activeContent, DateTime ActiveEndTime, string ActivePosterName)
        {
            string str_sql = @"update dbo.T_ClubActive
        set dbo.T_ClubActive.ActiveHead = @activeHead,dbo.T_ClubActive.ActiveContent = @activeContent,dbo.T_ClubActive.ActiveEndTime,dbo.T_ClubActive.ActivePosterName = @ActivePosterName
        where dbo.T_ClubActive.Id = @activeId;";

            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@activeHead",activeHead),
                new SqlParameter("@activeContent",activeContent),
                new SqlParameter("@activeId",activeId),
                new SqlParameter("@ActiveEndTime",ActiveEndTime),
                new SqlParameter("@ActivePosterName",ActivePosterName)
            };

            int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);
            return count;
        }
    }
}
