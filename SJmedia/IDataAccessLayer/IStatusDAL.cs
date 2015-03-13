using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IStatusDAL
    {
        /// <summary>
        /// 获取所有身份信息
        /// </summary>
        /// <returns>身份信息集合</returns>
        IList<T_Status> GetStatus();

        /// <summary>
        /// 获取某一个身份信息
        /// </summary>
        /// <param name="id">身份id</param>
        /// <returns>身份信息类</returns>
        T_Status GetStatusById(Guid id);

        /// <summary>
        /// 增加一个身份
        /// </summary>
        /// <param name="StatusName">身份名字</param>
        /// <param name="StatusRank">身份等级</param>
        /// <returns>增加的条数</returns>
        int AddStatusById(string StatusName, int StatusRank);

        /// <summary>
        /// 删除某一个身份信息
        /// </summary>
        /// <param name="id">身份id</param>
        /// <returns>删除的条数</returns>
        int DeleteStatusById(string id);
    }
}
