using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IMessageDAL
    {
        /// <summary>
        /// 获取用户发件信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        IList<T_Message> GetSendedMessage(string id);

        /// <summary>
        /// 获取用户收件信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        IList<T_Message> GetReceivedMessage(string id);

        /// <summary>
        /// 给某用户发送一条消息
        /// </summary>
        /// <param name="senderId">发送者id</param>
        /// <param name="recivierId">接受者id</param>
        /// <param name="sendHead">发送标题</param>
        /// <param name="sendContent">发送内容</param>
        /// <returns>影响条数</returns>
        int SendMessage(string senderId, string recivierId, string sendHead, string sendContent);

        /// <summary>
        /// 通过邮件id获取某个邮件信息
        /// </summary>
        /// <param name="mailId">邮件id</param>
        /// <returns>邮件信息</returns>
        T_Message GetMessageById(string mailId);

        /// <summary>
        /// 将某邮件状态设为已查看
        /// </summary>
        /// <param name="mailId"></param>
        /// <returns></returns>
        int ChangeMessageState(Guid mailId);
    }
}
