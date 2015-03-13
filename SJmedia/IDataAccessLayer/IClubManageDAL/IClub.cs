using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.Model;

namespace SJmedia.IDataAccessLayer
{
    public interface IClub
    {
        /// <summary>
        /// 根据用户id获取社团相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T_Club GetClubInformationByUserId(string id);
        /// <summary>
        /// 更改社团信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ChangeClubInformation(T_Club club);
    }
}
