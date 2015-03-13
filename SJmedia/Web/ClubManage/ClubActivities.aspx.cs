using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using SJmedia.Model;
using System.Configuration;

namespace Web.ClubManage
{
    public partial class ClubActivities : System.Web.UI.Page
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
            IList<T_ClubActive> list = clubCenterBLL.GetClubActiveList(CurrentUserHelp.currentUserBLL.Id);
            rpt1.DataSource = list;
            rpt1.DataBind();

            //绑定权限
            //1.绑定编辑权限
            string editClubActive = ConfigurationManager.AppSettings["EditClubActive"].ToString();
            Power power = new Power();
            bool possessPower = power.CheckPower(CurrentUserHelp.currentUserBLL.RankId, editClubActive);
            if (possessPower)
            {
                foreach (RepeaterItem item in rpt1.Items)
                {
                    HyperLink a_editClubActive = item.FindControl("a_editClubActive") as HyperLink;
                    a_editClubActive.Visible = true;
                }
            }
            else
            {
                foreach (RepeaterItem item in rpt1.Items)
                {
                    HyperLink a_editClubActive = item.FindControl("a_editClubActive") as HyperLink;
                    a_editClubActive.Visible = false;
                }
            }

            //2.绑定添加社团活动权限
            string addClubActive = ConfigurationManager.AppSettings["AddClubActive"].ToString();
            bool addPower = power.CheckPower(CurrentUserHelp.currentUserBLL.RankId, addClubActive);
            if (addPower)
            {
                a_addclubactive.Visible = true;
            }
            else
            {
                a_addclubactive.Visible = false;
            }

            //3.绑定删除社团活动权限
            string deleteClubActive = ConfigurationManager.AppSettings["DeleteClubActive"].ToString();
            bool deletePower = power.CheckPower(CurrentUserHelp.currentUserBLL.RankId, deleteClubActive);
            if (deletePower)
            {
                foreach (RepeaterItem item in rpt1.Items)
                {
                    LinkButton lbtn1 = item.FindControl("lbtn1") as LinkButton;
                    lbtn1.Visible = true;
                }
            }
            else
            {
                foreach (RepeaterItem item in rpt1.Items)
                {
                    LinkButton lbtn1 = item.FindControl("lbtn1") as LinkButton;
                    lbtn1.Visible = false;
                }
            }
        }

        protected void lbtn1_Command(object sender, CommandEventArgs e)
        {
            string activeId = e.CommandArgument.ToString();

            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            int count = clubCenterBLL.DeleteClubActive(activeId);
            if (count > 0)
            {
                BindData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AddClubActive", "<script type=\"text/javascript\">alert('删除成功');</script>", false);
            }
        }
    }
}