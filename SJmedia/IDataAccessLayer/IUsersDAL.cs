using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IUsersDAL
    {
        /// <summary>
        /// 根据账号查询用户是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Boolean QueryUser(string account);

        /// <summary>
        /// 获取Users所有项
        /// </summary>
        /// <returns></returns>
        IList<T_Users> GetUsers();

        /// <summary>
        /// 根据id获取某一个用户,如果是空返回一个空对象
        /// </summary>
        /// <returns></returns>
        T_Users GetUsersById(Guid id);

        /// <summary>
        /// 根据id删除某一个用户
        /// </summary>
        /// <returns></returns>
        int DeleteUsersById(Guid id);

        /// <summary>
        /// 更改某个用户的密码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="newPassword">用户新密码</param>
        /// <returns></returns>
        int ChangeUserPassword(string id, string newPassword);

        /// <summary>
        /// 更改某个用户的信息
        /// </summary>
        /// <param name="newPassword">用户新信息</param>
        /// <returns></returns>
        int ChangeUserInformation(T_Users user);

        /// <summary>
        /// 根据用户账号查用户id
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns>用户id</returns>
        Guid QueryIdByAccount(string userAccount);

        /// <summary>
        /// 设置某个用户新的身份
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        int SetUserRank(Guid userId, int rank);
    }
}
