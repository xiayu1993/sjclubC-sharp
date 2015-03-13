using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.DALFactory;
using SJmedia.Model;

namespace SJmedia.BusinessLogicLayer
{
    public class Power
    {
        #region 获取所有身份
        public IList<T_Status> GetAllStatus()
        {
            IList<T_Status> list = Factory.GetStatusDALInstance().GetStatus();
            return list;
        }
        #endregion

        #region 获取所有功能权限
        public IList<T_FunctionAuthority> GetAllFunctionAuthority()
        {
            IList<T_FunctionAuthority> list = Factory.GetPowerInstance().GetFunctionAuthority();
            return list;
        }
        #endregion

        #region 更改身份权限
        public int ChangeBackMenuAndUsersByRank(Guid rankId,IList<Guid> menuIdList)
        {
            //先删除全部
            int count1 = Factory.GetPowerInstance().DeleteBackMenuAndUsersByRank(rankId);
            
            //然后添加
            int count2 = Factory.GetPowerInstance().AddBackMenuAndUsersByRank(rankId, menuIdList);
            return count1 + count2;
        }
        #endregion

        #region 判断是否有功能权限
        public bool CheckPower(Guid rankId, string functionId)
        {
            bool power;

            object id = Factory.GetPowerInstance().CheckPower(rankId, Guid.Parse(functionId));
            if (id == null)
            {
                power = false;
            }
            else
            {
                power = true; ;
            }

            return power;
        }
        #endregion
    }
}
