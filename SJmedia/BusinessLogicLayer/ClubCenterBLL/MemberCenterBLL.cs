using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.DALFactory;
using SJmedia.Model;

namespace SJmedia.BusinessLogicLayer
{
    public class MemberCenterBLL
    {
        #region 获取社团所有成员信息
        public IList<MemberInformation> GetAllClubMember(Guid clubId)
        {
            IList<MemberInformation> list = new List<MemberInformation>();
            IList<T_Users> users = Factory.GetClubMemberInstance().GetAllClubMember(clubId);
            foreach (T_Users u in users)
            {
                MemberInformation memberInformation = new MemberInformation();
                //保存社团成员基本信息
                memberInformation.Id = u.Id.ToString();
                memberInformation.TrueName = u.TrueName;
                memberInformation.Name = u.Name;
                memberInformation.Account = u.Account;
                memberInformation.Sex = u.Sex;
                memberInformation.Birthday = u.Birthday;
                memberInformation.Introducation = u.Introducation;
                memberInformation.IsInSchool = u.IsInSchool;
                memberInformation.Number = u.Number;
                memberInformation.Academy = u.Academy;
                memberInformation.RankId = u.Status;

                //根据身份id获取身份信息
                T_Status status = Factory.GetStatusDALInstance().GetStatusById(u.Status);
                memberInformation.StatusName = status.Type;
                memberInformation.Rank = status.Rank;

                list.Add(memberInformation);
            }

            return list;
        }
        #endregion

        #region 将某个会员设置为副社
        public int SetAssociatePublisher(Guid userId)
        {
            if (userId != null)
            {
                return Factory.GetUsersDALInstance().SetUserRank(userId, 2);
            }
            else
                return 0;
        }
        #endregion

        #region 将某个副社设置为会员
        public int RevokeAssociatePublisher(Guid userId)
        {
            if (userId != null)
            {
                return Factory.GetUsersDALInstance().SetUserRank(userId, 1);
            }
            else
                return 0;
        }
        #endregion
    }

    public class MemberInformation
    { 
        //信息里面不包含用户密码
        #region 基本信息  
        public string Id { get; set; }               //用户id
        public string Name { get; set; }             //用户昵称
        public string TrueName { get; set; }         //用户真实姓名
        public string Account { get; set; }          //用户账号
        public bool? Sex { get; set; }                //用户性别，1为男，0为女
        public string Birthday { get; set; }         //用户生日（带年份）
        public string Introducation { get; set; }    //用户介绍
        public bool IsInSchool { get; set; }         //用户是否是学校里的，1是在学校，0是不在学校
        public Int64? Number { get; set; }            //用户学号
        public string Academy { get; set; }          //用户所在学院
        public Guid RankId { get; set; }             //用户身份id
        #endregion

        #region 扩展信息
        public string StatusName { get; set; }       //用户身份
        public int Rank { get; set; }                //用户身份等级
        #endregion
    }
}
