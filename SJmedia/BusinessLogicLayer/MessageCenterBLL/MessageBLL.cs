using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.DALFactory;
using SJmedia.Model;

namespace SJmedia.BusinessLogicLayer
{
    public class MessageBLL
    {
        #region 根据条件查询某个用户的所有发送消息
        public IList<T_Message> GetSendedMessage(string userId)
        {
            IList<T_Message> list = Factory.GetMessageDALInstance().GetSendedMessage(userId);
            return list;
        }
        #endregion

        #region 根据条件查询某个用户的所有接受消息
        public IList<T_Message> GetReceivedMessage(string userId)
        {
            IList<T_Message> list = Factory.GetMessageDALInstance().GetReceivedMessage(userId);
            return list;
        }
        #endregion

        #region 发送消息
        public int SendMessage(string senderId, string recivierAccount,string sendHead, string sendContent)
        {
            string recivierId = Factory.GetUsersDALInstance().QueryIdByAccount(recivierAccount).ToString();
            int count = Factory.GetMessageDALInstance().SendMessage(senderId, recivierId, sendHead, sendContent);
            return count;
        }
        #endregion

        #region 通过邮件id获取某个邮件信息
        public T_Message GetMessageById(string mailId)
        {
            T_Message mail;
            if (mailId == null)
            {
                mail = null;
            }
            else
            {
                mail = Factory.GetMessageDALInstance().GetMessageById(mailId);
            }

            return mail;
        }
        #endregion

        #region 更改邮件查看状态
        public int ChangeMessageState(string mailId)
        {
            return Factory.GetMessageDALInstance().ChangeMessageState(Guid.Parse(mailId));
        }
        #endregion
    }
}
