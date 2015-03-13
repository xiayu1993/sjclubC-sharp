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
    public class MessageDAL : IMessageDAL
    {
        private string str_cnn = ConfigurationManager.ConnectionStrings["ClubConnectionString"].ToString();

        public IList<T_Message> GetSendedMessage(string id)
        {
            IList<T_Message> list = new List<T_Message>();
            
            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();
            string str_sql = @"select m.Id,m.SendUsersId,m.ReceiveUsersId,m.SendTime,m.SendHead,m.SendContent,m.IsCheck,m.Name as SendUserName,users.Name as ReceiveUsersName
                        from dbo.T_Users users right join 
                        (
	                    select m.Id,m.SendUsersId,m.ReceiveUsersId,m.SendTime,m.SendHead,m.SendContent,m.IsCheck,u.Name
	                    from dbo.T_Message m left join dbo.T_Users u on m.SendUsersId = u.Id
                        ) as m on m.ReceiveUsersId=users.Id
                        where m.SendUsersId = @id
                        order by m.SendTime desc;";
            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);
            cmd.Parameters.AddWithValue("@id", Guid.Parse(id));

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                T_Message message = new T_Message();

                message.Id = new Guid(data["Id"].ToString());
                message.SendUsersId = new Guid(data["SendUsersId"].ToString());
                message.ReceiveUsersId = new Guid(data["ReceiveUsersId"].ToString());
                message.SendTime = data["SendTime"].ToString();
                message.SendHead = data["SendHead"].ToString();
                message.SendContent = data["SendContent"].ToString();
                message.IsCheck = Convert.ToBoolean(data["IsCheck"]);

                message.SendUserName = data["SendUserName"].ToString();
                message.ReceiveUsersName = data["ReceiveUsersName"].ToString();

                list.Add(message);
            }

            str_sqlcnn.Close();
            return list;
        }

        public IList<T_Message> GetReceivedMessage(string id)
        {
            IList<T_Message> list = new List<T_Message>();

            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();
            string str_sql = @"select m.Id,m.SendUsersId,m.ReceiveUsersId,m.SendTime,m.SendHead,m.SendContent,m.IsCheck,m.Name as SendUserName,users.Name as ReceiveUsersName
                        from dbo.T_Users users right join 
                        (
	                    select m.Id,m.SendUsersId,m.ReceiveUsersId,m.SendTime,m.SendHead,m.SendContent,m.IsCheck,u.Name
	                    from dbo.T_Message m left join dbo.T_Users u on m.SendUsersId = u.Id
                        ) as m on m.ReceiveUsersId=users.Id
                        where m.ReceiveUsersId = @id
                        order by m.SendTime desc;";
            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);
            cmd.Parameters.AddWithValue("@id", Guid.Parse(id));

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                T_Message message = new T_Message();

                message.Id = new Guid(data["Id"].ToString());
                message.SendUsersId = new Guid(data["SendUsersId"].ToString());
                message.ReceiveUsersId = new Guid(data["ReceiveUsersId"].ToString());
                message.SendTime = data["SendTime"].ToString();
                message.SendHead = data["SendHead"].ToString();
                message.SendContent = data["SendContent"].ToString();
                message.IsCheck = Convert.ToBoolean(data["IsCheck"]);

                message.SendUserName = data["SendUserName"].ToString();
                message.ReceiveUsersName = data["ReceiveUsersName"].ToString();

                list.Add(message);
            }

            str_sqlcnn.Close();
            return list;
        }

        public int SendMessage(string senderId, string recivierId, string sendHead, string sendContent)
        {
            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();
            string str_sql = @"insert into dbo.T_Message
                        values(
                        NEWID(),
                        @senderId,
                        @recivierId,
                        GETDATE(),
                        @sendHead,
                        @sendContent,
                        0);";
            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);
            cmd.Parameters.AddWithValue("@senderId", senderId);
            cmd.Parameters.AddWithValue("@recivierId", recivierId);
            cmd.Parameters.AddWithValue("@sendHead", sendHead);
            cmd.Parameters.AddWithValue("@sendContent", sendContent);

            int count = cmd.ExecuteNonQuery();
            return count;
        }

        public T_Message GetMessageById(string mailId)
        {
            SqlConnection str_sqlcnn = new SqlConnection(str_cnn);
            str_sqlcnn.Open();
            string str_sql = @"select m.Id,m.SendUsersId,m.ReceiveUsersId,m.SendTime,m.SendHead,m.SendContent,m.IsCheck,m.Name as SendUserName,users.Name as ReceiveUsersName
                        from dbo.T_Users users right join 
                        (
	                    select m.Id,m.SendUsersId,m.ReceiveUsersId,m.SendTime,m.SendHead,m.SendContent,m.IsCheck,u.Name
	                    from dbo.T_Message m left join dbo.T_Users u on m.SendUsersId = u.Id
                        ) as m on m.ReceiveUsersId=users.Id 
                        where m.Id = @mailId;";
            SqlCommand cmd = new SqlCommand(str_sql, str_sqlcnn);
            cmd.Parameters.AddWithValue("@mailId", Guid.Parse(mailId));

            SqlDataReader data = cmd.ExecuteReader();

            //只需读一行
            T_Message message = new T_Message();
            data.Read();
            message.Id = new Guid(data["Id"].ToString());
            message.SendUsersId = new Guid(data["SendUsersId"].ToString());
            message.ReceiveUsersId = new Guid(data["ReceiveUsersId"].ToString());
            message.SendTime = data["SendTime"].ToString();
            message.SendHead = data["SendHead"].ToString();
            message.SendContent = data["SendContent"].ToString();
            message.IsCheck = Convert.ToBoolean(data["IsCheck"]);

            message.SendUserName = data["SendUserName"].ToString();
            message.ReceiveUsersName = data["ReceiveUsersName"].ToString();

            return message;
        }

        public int ChangeMessageState(Guid mailId)
        {
            string str_sql = @"update dbo.T_Message
                    set dbo.T_Message.IsCheck = 1
                    where dbo.T_Message.Id = @mailId;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@mailId",mailId)};

            return SqlHelper.ExecuteNonQuery(str_cnn, CommandType.Text, str_sql, param);
        }
    }
}
