using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.IDataAccessLayer;
using SJmedia.Model;
using SJmedia.Common;
using BookDAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SJmedia.SQLSeverDAL
{
    public class Club : IClub
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public T_Club GetClubInformationByUserId(string id)
        {
            string str_sql = @"select c.Id,c.ClubName,c.ClubIntroduction,c.ClubRelatedInformation,c.ClubResources,c.ClubRoute,c.ClubLogo,c.ClubLink
                            from dbo.T_Club c inner join dbo.T_ClubAndUsers u on c.Id = u.Club
                            where u.Users = @id;";
            SqlParameter[] param = new SqlParameter[]{new SqlParameter("@id",Guid.Parse(id))};

            T_Club club = new T_Club();

            using (SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param))
            {
                //只读取一行
                if (dater.Read())
                {
                    club.Id = new Guid(dater["Id"].ToString());
                    club.ClubName = dater["ClubName"].ToString();
                    club.ClubIntroduction = dater["ClubIntroduction"].ToString();
                    club.ClubRelatedInformation = dater["ClubRelatedInformation"].ToString();
                    club.ClubResources = dater["ClubResources"].ToString();
                    club.ClubRoute = dater["ClubRoute"].ToString();
                    club.ClubLogo = dater["ClubLogo"].ToString();
                    club.ClubLink = dater["ClubLink"].ToString();
                }
            }

            return club;
        }

        public int ChangeClubInformation(T_Club club)
        {
            string str_sql = @"update dbo.T_Club
                    set dbo.T_Club.ClubName = @clubName,
                    dbo.T_Club.ClubIntroduction = @clubIntroduction,
                    dbo.T_Club.ClubLogo = @clubLogo
                    where dbo.T_Club.Id= @id;";
            SqlParameter[] param = new SqlParameter[]
            { 
                new SqlParameter("@id", club.Id),
                new SqlParameter("@clubName",club.ClubName),
                new SqlParameter("@clubIntroduction",club.ClubIntroduction),
                new SqlParameter("@clubLogo",club.ClubLogo)
            };

            //int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param)

            int count = SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);
            
            return count;

        }
    }
}
