using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IPowerDAL
    {
        /// <summary>
        /// 获取所有功能权限
        /// </summary>
        /// <returns></returns>
        IList<T_FunctionAuthority> GetFunctionAuthority();
        /// <summary>
        /// 删除所有rank值为
        /// </summary>
        /// <param name="rankId"></param>
        /// <returns></returns>
        int DeleteBackMenuAndUsersByRank(Guid rankId);
        /// <summary>
        /// 增加权限
        /// </summary>
        /// <param name="rankId"></param>
        /// <returns></returns>
        int AddBackMenuAndUsersByRank(Guid rankId,IList<Guid> menuIdList);
        /// <summary>
        /// 检查功能权限
        /// </summary>
        /// <param name="rankId"></param>
        /// <param name="functionId"></param>
        /// <returns></returns>
        object CheckPower(Guid rankId, Guid functionId);
    }
}
