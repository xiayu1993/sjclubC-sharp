using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.DALFactory;
using SJmedia.Model;

namespace SJmedia.BusinessLogicLayer
{
    public class ClubCenterBLL
    {
        #region 根据条件获取此用户所在社团的社团活动列表
        public IList<T_ClubActive> GetClubActiveList(string id)
        {
            IList<T_ClubActive> list = Factory.GetClubActiveInstance().GetClubActiveListByUserId(Guid.Parse(id));
            return list;
        }
        #endregion

        #region 获取社团活动的详情
        public T_ClubActive GetClubActiveDetail(string id)
        {
            T_ClubActive clubActive = Factory.GetClubActiveInstance().GetClubActiveDetail(Guid.Parse(id));
            return clubActive;
        }
        #endregion

        #region 获取社团详情
        public T_Club GetClubInformation(string id)
        {
            T_Club club = Factory.GetClubInstance().GetClubInformationByUserId(id);
            return club;
        }
        #endregion

        #region 更改社团信息
        public int ChangeClubInformation(Guid clubId, string clubName,string clubIntroduction,string clubLogo)
        {
            T_Club club = new T_Club();
            club.Id = clubId;
            club.ClubName = clubName;
            club.ClubIntroduction = clubIntroduction;
            club.ClubLogo = clubLogo;

            int count = Factory.GetClubInstance().ChangeClubInformation(club);
            return count;
        }
        #endregion

        #region 上传活动详情
        public int AddClubActive(string activeHead, string activeContent, DateTime endtime, string imgName, Guid clubId)
        {
            T_ClubActive clubActive = new T_ClubActive();
            clubActive.ActiveContent = activeContent;
            clubActive.ActiveHead = activeHead;
            clubActive.ActiveTime = DateTime.Now.ToString();
            clubActive.ClubId = clubId;
            clubActive.Id = Guid.NewGuid();
            clubActive.ActiveEndTime = endtime;
            clubActive.ActivePosterName = imgName;

            int count = Factory.GetClubActiveInstance().AddClubActive(clubActive);
            return count;
        }
        #endregion

        #region 更改活动信息
        public int ChangeClubActiveInformation(string activeId, string activeHead, string activeContent, DateTime ActiveEndTime, string ActivePosterName)
        {
            int count = Factory.GetClubActiveInstance().UpdateClubActive(Guid.Parse(activeId), activeHead, activeContent, ActiveEndTime, ActivePosterName);
            return count;
        }
        #endregion

        #region 删除某条活动信息
        public int DeleteClubActive(string activeId)
        {
            int count = Factory.GetClubActiveInstance().DeleteClubActive(Guid.Parse(activeId));
            return count;
        }
        #endregion

        #region 根据社团id查社长名字
        public string QueryClubPresident(Guid ClubId)
        {
            IList<T_Users> list = Factory.GetClubMemberInstance().GetAllClubMember(ClubId);
            foreach (T_Users user in list)
            {
                //查用户的等级是否为社长
                T_Status status = Factory.GetStatusDALInstance().GetStatusById(user.Status);
                if (status.Rank == 3)
                    return user.TrueName;
            }

            return string.Empty;
        }
        #endregion
    }
}
