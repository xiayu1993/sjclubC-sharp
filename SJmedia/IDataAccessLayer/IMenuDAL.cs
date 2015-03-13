using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IMenuDAL
    {
        /// <summary>
        /// 根据当前用户权限获取BackMenu所有项
        /// </summary>
        /// <returns></returns>
        IList<T_BackMenu> GetAllBackMenu();
        
        /// <summary>
        /// 根据权限获取菜单
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        IList<T_BackMenu> GetBackMenu(Guid statusId);

        /// <summary>
        /// 根据当前用户权限获取BackMenud的根目录项
        /// </summary>
        /// <returns></returns>
        IList<T_BackMenu> GetRootBackMenu(Guid statusId);

        /// <summary>
        /// 添加BackMenu某一项
        /// </summary>
        /// <returns></returns>
        int AddBackMenu(Guid id);

        /// <summary>
        /// 删除BackMenu某一项
        /// </summary>
        /// <returns></returns>
        int DeleteBackMenu(Guid id);

        /// <summary>
        /// 根据权限获取T_BackMenuAndUsers所有数据
        /// </summary>
        /// <returns></returns>
        IList<T_BackMenuAndUsers> GetBackMenuAndUsersByRank(Guid statusId);
    }
}
