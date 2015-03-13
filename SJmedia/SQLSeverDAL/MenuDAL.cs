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
    public class MenuDAL : IMenuDAL
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public IList<T_BackMenu> GetBackMenu(Guid statusId)
        {
            IList<T_BackMenu> list = new List<T_BackMenu>();
            
            string str_sql = @"select b.Id,b.ParentId,b.MenuName,b.URL,b.Num
                    from dbo.T_BackMenu b inner join dbo.T_BackMenuAndUsers u on b.Id=u.BackMenuId
                    where u.StatusId = @statusId
                    order by b.Num;";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@statusId", statusId),
            };

            using (SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param))
            {
                while (dater.Read())
                {
                    T_BackMenu mode_BackMenu = new T_BackMenu();
                    mode_BackMenu.Id = new Guid(dater["Id"].ToString());
                    mode_BackMenu.ParentID = new Guid(dater["ParentID"].ToString());
                    mode_BackMenu.MenuName = dater["MenuName"].ToString();
                    mode_BackMenu.URL = dater["URL"].ToString();
                    mode_BackMenu.Num = Convert.ToInt32(dater["Num"]);

                    list.Add(mode_BackMenu);
                }
            }

            return list;
        }

        public IList<T_BackMenu> GetAllBackMenu()
        {
            IList<T_BackMenu> list = new List<T_BackMenu>();

            string str_sql = @"select Id,ParentId,MenuName,URL,Num
                    from dbo.T_BackMenu
                    order by Num;";

            using (SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql))
            {
                while (dater.Read())
                {
                    T_BackMenu mode_BackMenu = new T_BackMenu();
                    mode_BackMenu.Id = new Guid(dater["Id"].ToString());
                    mode_BackMenu.ParentID = new Guid(dater["ParentID"].ToString());
                    mode_BackMenu.MenuName = dater["MenuName"].ToString();
                    mode_BackMenu.URL = dater["URL"].ToString();
                    mode_BackMenu.Num = Convert.ToInt32(dater["Num"]);

                    list.Add(mode_BackMenu);
                }
            }

            return list;
        }

        public int AddBackMenu(Guid id)
        {
//            IList<T_BackMenu> list = new List<T_BackMenu>();
//            string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

//            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
//            str_sqlcnn.Open();

//            string str_sql = @"select *
//                    from dbo.T_BackMenu
//                    where Id=@id;";
//            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);
//            cmd.Parameters.AddWithValue("@id", id);
//            SqlDataReader data = cmd.ExecuteReader();

//            T_BackMenu mode_BackMenu = new T_BackMenu();
//            mode_BackMenu.Id = new Guid(data["Id"].ToString());
//            mode_BackMenu.ParentID = new Guid(data["ParentID"].ToString());
//            mode_BackMenu.MenuName = data["MenuName"].ToString();
//            mode_BackMenu.URL = data["URL"].ToString();

//            list.Add(mode_BackMenu);
//            str_sqlcnn.Close();
                return 0;
        }

        public int DeleteBackMenu(Guid id)
        {
            int i = 0;
            IList<T_BackMenu> list = new List<T_BackMenu>();

            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();

            string str_sql = @"delete 
                    from dbo.T_BackMenu 
                    where id= @id ";

            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);

            cmd.Parameters.AddWithValue("@id", id);

            i = cmd.ExecuteNonQuery();

            str_sqlcnn.Close();

            return i;
        }

        public IList<T_BackMenu> GetRootBackMenu(Guid statusId)
        {
            IList<T_BackMenu> list = new List<T_BackMenu>();

            string str_sql = @"select b.Id,b.ParentId,b.MenuName,b.URL,b.Num
                        from dbo.T_BackMenu b inner join dbo.T_BackMenuAndUsers u on b.Id=u.BackMenuId
                        where u.StatusId = @statusId and (b.Id = b.ParentId or b.ParentId=null)
                        order by b.Num;";
                
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@statusId", statusId) };

            using (SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param))
            {
                while (dater.Read())
                {
                    T_BackMenu mode_BackMenu = new T_BackMenu();

                    mode_BackMenu.Id = new Guid(dater["Id"].ToString());
                    mode_BackMenu.ParentID = new Guid(dater["ParentID"].ToString());
                    mode_BackMenu.MenuName = dater["MenuName"].ToString();
                    mode_BackMenu.URL = dater["URL"].ToString();
                    mode_BackMenu.Num = Convert.ToInt32(dater["Num"]);

                    list.Add(mode_BackMenu);
                }
            }
            return list;
        }

        public IList<T_BackMenuAndUsers> GetBackMenuAndUsersByRank(Guid statusId)
        {
            IList<T_BackMenuAndUsers> list = new List<T_BackMenuAndUsers>();

            string str_sql = "select * from dbo.T_BackMenuAndUsers where StatusId = @statusId;";

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@statusId", statusId) };

            SqlDataReader dater = SqlHelper.ExecuteReader(str_cnn, CommandType.Text, str_sql, param);

            while (dater.Read())
            {
                T_BackMenuAndUsers backMenuAndUsers = new T_BackMenuAndUsers();
                backMenuAndUsers.Id = new Guid(dater["Id"].ToString());
                backMenuAndUsers.StatusId = new Guid(dater["StatusId"].ToString());
                backMenuAndUsers.BackMenuId = new Guid(dater["BackMenuId"].ToString());

                list.Add(backMenuAndUsers);
            }

            return list;
        }
    }
}
