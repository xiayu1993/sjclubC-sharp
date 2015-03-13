using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;
using SJmedia.Model;

namespace Web.ClubManage
{
    public partial class ClubData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void CheckId()
        {
            //检查当前用户是否存在
            if (string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.Id))
            {
                string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                string js = "<script type=\"text/javascript\">parent.location=\"" + url + " \";</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CheckUser", js, false);
            }
        }

        protected void BindData()
        {
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);

            lab_ClubName.Text = club.ClubName;
            lab_Instruction.Text = club.ClubIntroduction;
            lab_President.Text = clubCenterBLL.QueryClubPresident(club.Id);
            img_ClubLogo.ImageUrl = string.Format("~/{0}/ClubLogo/{1}", club.ClubRoute, club.ClubLogo);

            //绑定权限
            string changeClubInformation = ConfigurationManager.AppSettings["ChangeClubInformation"].ToString();
            Power power = new Power();
            bool possessPower = power.CheckPower(CurrentUserHelp.currentUserBLL.RankId, changeClubInformation);
            if (possessPower)
            {
                a_changeclubinformation.Visible = true;
            }
            else
            {
                a_changeclubinformation.Visible = false;
            }
        }
    }
}