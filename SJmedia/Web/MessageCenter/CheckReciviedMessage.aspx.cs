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
    public partial class CheckReciviedMessage : System.Web.UI.Page
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
            //检查邮件id是否存在
            if (Request.QueryString["mailId"] == null)
            {
                Response.Redirect("SendedMessageList.aspx");
            }
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
            string mailId = Request.QueryString["mailId"].ToString();
            MessageBLL messageBLL = new MessageBLL();
            //将此邮件设为已查看
            int count = messageBLL.ChangeMessageState(mailId);

            //绑定数据
            T_Message message = messageBLL.GetMessageById(mailId);
            if (message != null)
            {
                lab_sendAccount.Text = Users.GetAccountById(message.SendUsersId);
                lab_sendHead.Text = message.SendHead;
                lab_content.Text = message.SendContent;
            }
        }

    }
}