using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SJmedia.DALFactory;
using SJmedia.Model;
using SJmedia.SQLSeverDAL;
using SJmedia.IDataAccessLayer;
using System.Web.UI;

namespace SJmedia.BusinessLogicLayer
{
    public class CurrentUserBLL
    {
        #region 基本信息
        public string Id = string.Empty;            //用户id，也是判断用户状态的标准

        public string Name{ get; set; }              //用户昵称
        public string TrueName { get; set; }         //用户真实姓名
        public string Account { get; set; }          //用户账号
        public string Password { get; set; }         //用户密码
        public bool? Sex { get; set; }                //用户性别，1为男，0为女
        public DateTime Birthday { get; set; }         //用户生日（带年份）
        public string Introducation { get; set; }    //用户介绍
        public bool IsInSchool { get; set; }         //用户是否是学校里的，1是在学校，0是不在学校
        public Int64? Number { get; set; }            //用户学号
        public string Academy { get; set; }          //用户所在学院
        public Guid RankId { get; set; }             //用户身份id
        #endregion

        #region 扩展信息
        public string StatusName { get; set; }       //用户身份
        public int Rank { get; set; }                //用户身份等级
        
        public Guid ClubId { get; set; }            //社团id
        public string ClubName { get; set; }        //社团名字
        #endregion

        #region 通过id来得到用户信息，返回是否存在此用户
        public bool GetUserById(string id)
        {
            bool isExist = false;
            //获取用户信息
            T_Users usersDAL = Factory.GetUsersDALInstance().GetUsersById(Guid.Parse(id));

            if (usersDAL != null)
            {
                isExist = true;
                //currentUserBLL = new CurrentUserBLL();
                //保存用户基本信息
                this.Id = usersDAL.Id.ToString();
                this.TrueName = usersDAL.TrueName;
                this.Name = usersDAL.Name;
                this.Account = usersDAL.Account;
                this.Password = usersDAL.Password;
                this.Sex = usersDAL.Sex;
                //判断生日类型
                DateTime dt;
                DateTime.TryParse(usersDAL.Birthday, out dt);

                this.Birthday = dt;

                this.Introducation = usersDAL.Introducation;
                this.IsInSchool = usersDAL.IsInSchool;
                this.Number = usersDAL.Number;
                this.Academy = usersDAL.Academy;
                this.RankId = usersDAL.Status;

                //根据身份id获取身份信息
                T_Status status = Factory.GetStatusDALInstance().GetStatusById(this.RankId);
                this.StatusName = status.Type;
                this.Rank = status.Rank;

                //获取社团信息
                T_Club club = Factory.GetClubInstance().GetClubInformationByUserId(this.Id);
                if (club != null)
                {
                    this.ClubId = club.Id;
                    this.ClubName = club.ClubName;

                    SJmedia.Common.File file = new Common.File();
                    //给自己社团创建个文件夹，如果已经有了则不用创建
                    file.CreatFile(System.Web.HttpContext.Current.Server.MapPath(club.ClubRoute));
                    //创建社团活动文件夹
                    file.CreatFile(System.Web.HttpContext.Current.Server.MapPath(club.ClubRoute + "/ClubActiveImages"));
                    //创建社团logo文件夹
                    file.CreatFile(System.Web.HttpContext.Current.Server.MapPath(club.ClubRoute + "/ClubLogo"));
                    //创建社团活动海报文件夹
                    file.CreatFile(System.Web.HttpContext.Current.Server.MapPath(club.ClubRoute + "/ClubActivePosterImg"));
                }
                else
                {
                    this.ClubId = Guid.Empty;
                    this.ClubName = string.Empty;
                }
            }

            CurrentUserHelp.currentUserBLL = this;

            return isExist;
        }
        #endregion

        #region 修改当前用户密码
        public int ChangeUserPassword(string oldPassword, string newPassword)
        {
            int count = 0;
            //Id判断当前用户状态
            if (!string.IsNullOrEmpty(this.Id))
            {
                //获取用户原始密码
                IUsersDAL usersDAL = Factory.GetUsersDALInstance();
                T_Users user = usersDAL.GetUsersById(Guid.Parse(this.Id));

                //如果用户原始密码和输入的密码一样，则允许修改密码
                if (user.Password == oldPassword)
                {
                    count = Factory.GetUsersDALInstance().ChangeUserPassword(this.Id, newPassword);
                }
            }
            else
            {
                //count=-1表示当前没用用户Id
                count = -1;
            }

            return count;
        }
        #endregion

        #region 修改当前用户信息
        public int UpdateUserInformation(T_Users userInformation)
        {
            return Factory.GetUsersDALInstance().ChangeUserInformation(userInformation);
        }
        #endregion
    }

    //当前用户的助手类
    public class CurrentUserHelp
    {
        public static CurrentUserBLL currentUserBLL
        {
            get 
            { 
                HttpContext context = HttpContext.Current;
                return context.Session["User"] == null ? new CurrentUserBLL() : context.Session["User"] as CurrentUserBLL;
            }
            set 
            {
                HttpContext context = HttpContext.Current;
                context.Session["User"] = value;
            }
        }
    }
}

