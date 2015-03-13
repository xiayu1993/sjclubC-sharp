using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.DALFactory;
using SJmedia.Model;

namespace SJmedia.BusinessLogicLayer
{
    public class Users
    {
        #region 通过用户账号查询是否存在该用户
        public static bool GetUserByAccount(string account)
        {
            return Factory.GetUsersDALInstance().QueryUser(account);
        }
        #endregion

        #region 通过用户id查某个用户账号
        public static string GetAccountById(Guid userId)
        {
            string userAccount;
            if (userId != null)
            {
                userAccount = Factory.GetUsersDALInstance().GetUsersById(userId) == null ? 
                    string.Empty : Factory.GetUsersDALInstance().GetUsersById(userId).Account;
            }
            else
            {
                userAccount = string.Empty;
            }
            return userAccount; 
        }
        #endregion

        #region 获取所有用户
        public static IList<T_Users> GetUsers()
        {
            IList<T_Users> users = Factory.GetUsersDALInstance().GetUsers();
            return users;
        }
        #endregion

        #region 删除某个用户
        public static int DeleteUserById(string uid)
        {
            int count = Factory.GetUsersDALInstance().DeleteUsersById(Guid.Parse(uid));
            return count;
        }
        #endregion

        #region 获取某一个用户信息
        public static T_Users GetUserById(string uid)
        {
            T_Users user = Factory.GetUsersDALInstance().GetUsersById(Guid.Parse(uid));
            return user;
        }
        #endregion

        #region 根据身份id获取身份信息
        public static T_Status GetStatusById(string statusId)
        {
            T_Status status = Factory.GetStatusDALInstance().GetStatusById(Guid.Parse(statusId));
            return status;
        }
        #endregion

        #region 获取所有社长副社的信息
        public static IList<President> GetAllPresidentAndVicePresident()
        {
            IList<President> list = new List<President>();
            
            //先获取所有的用户
            IList<T_Users> users = Factory.GetUsersDALInstance().GetUsers();

            foreach (T_Users u in users)
            { 
                //获取身份等级
                T_Status status = Factory.GetStatusDALInstance().GetStatusById(u.Status);

                int rank = status.Rank;

                //如果是社长或副社
                if (rank == 2 || rank == 3)
                { 
                    President president = new President();
                    president.Account = u.Account;
                    president.ClubName = Factory.GetClubInstance().GetClubInformationByUserId(u.Id.ToString()).ClubName;
                    president.Name = u.Name;
                    president.Rank = status.Type;

                    list.Add(president);
                }
            }
            return list;
        }
        #endregion
    }
}
