using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;

namespace Web.ClubManage
{
    public partial class ClubMember : System.Web.UI.Page
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

        //绑定Repeater
        protected void BindData()
        {
            MemberCenterBLL memberCenterBLL = new MemberCenterBLL();
            IList<MemberInformation> list = memberCenterBLL.GetAllClubMember(CurrentUserHelp.currentUserBLL.ClubId);

            rpt1.DataSource = list;
            rpt1.DataBind();
        }
    }
}