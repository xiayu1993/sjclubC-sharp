using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using SJmedia.IDataAccessLayer;

namespace SJmedia.DALFactory
{
    public static class Factory
    {
        public static object GetInstance(string name)
        {
            string str_DALAssembly = ConfigurationManager.AppSettings["DALAssembly"].ToString();

            Assembly DALAssembly = Assembly.Load(str_DALAssembly);

            object classname = DALAssembly.CreateInstance(name);

            return classname;
        }

        public static IMenuDAL GetMenuDALInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.MenuDAL") as IMenuDAL;
        }

        public static IUsersDAL GetUsersDALInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.UsersDAL") as IUsersDAL;
        }

        public static IStatusDAL GetStatusDALInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.StatusDAL") as IStatusDAL;
        }

        public static IMessageDAL GetMessageDALInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.MessageDAL") as IMessageDAL;
        }

        public static IClubActive GetClubActiveInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.ClubActive") as IClubActive;
        }

        public static IClub GetClubInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.Club") as IClub;
        }

        public static IClubMember GetClubMemberInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.ClubMember") as IClubMember;
        }

        public static IPowerDAL GetPowerInstance()
        {
            return Factory.GetInstance("SJmedia.SQLSeverDAL.PowerDAL") as IPowerDAL;
        }
    }
}
