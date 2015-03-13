using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;

namespace Web
{
    public partial class Frame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["uid"] != null)
                //{
                //    string uid = Request.QueryString["uid"].ToString();
                //    GetCurrentUser(uid);
                //}
                GetCurrentUser("CCD64E33-9CF5-41E7-AD85-2F9A71ABB3AB");
            }
        }

        private void GetCurrentUser(string userId)
        {
            if (!CurrentUserHelp.currentUserBLL.GetUserById(userId))
            {
                string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                string js = "<script type=\"text/javascript\">parent.location=\"" + url + " \";</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangePassword", js, false);
            }
        }
    }
}