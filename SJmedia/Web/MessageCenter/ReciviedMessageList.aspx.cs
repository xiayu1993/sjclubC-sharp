using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using SJmedia.Model;
using System.Configuration;

namespace Web.MessageCenter
{
    public partial class ReciviedMessageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetReciviedMessageList();
            }
        }

        protected void GetReciviedMessageList()
        {
            if (!string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.Id))
            {
                MessageBLL messageBLL = new MessageBLL();
                IList<T_Message> list = messageBLL.GetReceivedMessage(CurrentUserHelp.currentUserBLL.Id);

                //绑定数据控件
                gv1.DataSource = list;
                gv1.DataBind();
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