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
    public partial class ClubActiveDetail : System.Web.UI.Page
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
            //检查活动id是否存在
            if (Request.QueryString["ClubActiveId"] == null)
            {
                Response.Redirect("ClubActivities.aspx");
            }
            else
            {
                //绑定社团活动
                string clubActiveId = Request.QueryString["ClubActiveId"].ToString();
                ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
                T_ClubActive clubActive = clubCenterBLL.GetClubActiveDetail(clubActiveId);

                img_Poster.ImageUrl = string.Format("~/{0}/{1}", clubActive.ActivePosterRoute, clubActive.ActivePosterName);
                lab_ActiveHead.Text = clubActive.ActiveHead;
                lab_ActiveEndTime.Text = clubActive.ActiveEndTime.ToShortDateString();
                lab_ActiveContent.Text = clubActive.ActiveContent;
            }
        }
    }
}