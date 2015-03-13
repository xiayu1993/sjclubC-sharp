using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IClubActive
    {
        /// <summary>
        /// 根据用户查其社团列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        IList<T_ClubActive> GetClubActiveListByUserId(Guid userId);

        /// <summary>
        /// 根据活动id获取社团活动详细信息
        /// </summary>
        /// <param name="clubId">活动id</param>
        /// <returns></returns>
        T_ClubActive GetClubActiveDetail(Guid activeId);

        /// <summary>
        /// 增加一条社团活动
        /// </summary>
        /// <param name="clubActive">社团信息</param>
        /// <returns></returns>
        int AddClubActive(T_ClubActive clubActive);

        /// <summary>
        /// 删除一条社团活动
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        int DeleteClubActive(Guid clubId);

        /// <summary>
        /// 更改活动详情
        /// </summary>
        /// <param name="clubActive"></param>
        /// <returns></returns>
        int UpdateClubActive(Guid activeId, string activeHead, string activeContent, DateTime dt, string ActivePosterName);
    }
}
