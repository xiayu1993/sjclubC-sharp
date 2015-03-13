using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IClubMember
    {
        /// <summary>
        /// 获取社团所有成员
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        IList<T_Users> GetAllClubMember(Guid clubId);
    }
}
