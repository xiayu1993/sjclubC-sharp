using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;

namespace Web.IndividualCenter
{
    public partial class PersonalData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFormView();
            }
        }

        protected void BindFormView()
        {
            if (!string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.Id))
            {
                IList<CurrentUserBLL> list = new List<CurrentUserBLL>();
                list.Add(CurrentUserHelp.currentUserBLL);
                fv1.DataSource = list;
                fv1.DataBind();
            }
            else
            {
                string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                string js = "<script type=\"text/javascript\">parent.location=\"" + url + " \";</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CheckUser", js, false);
            }
        }
    }
}