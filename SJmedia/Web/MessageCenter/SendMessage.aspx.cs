using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using SJmedia.Model;
using SJmedia.Common;
using System.Configuration;

namespace Web.MessageCenter
{
    public partial class SendMessage : System.Web.UI.Page
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
            //通过邮件id绑定数据，如果没有则不绑定
            if (Request.QueryString["mailId"] != null)
            {
                //获取数据
                string mailId = Request.QueryString["mailId"].ToString();
                MessageBLL messageBLL = new MessageBLL();
                T_Message message = messageBLL.GetMessageById(mailId);
                //开始绑定
                txt_recivierAccount.Text = Users.GetAccountById(message.SendUsersId);
                txt_sendHead.Text = "回复："+ message.SendHead;
                Mail mail = new Mail();
                edit1.Text = mail.ChangeOldMail(message.SendContent, message.SendUserName, message.ReceiveUsersName, message.SendTime, message.SendHead);
            }

            //绑定社团联系人
            IList<President> list = Users.GetAllPresidentAndVicePresident();
            foreach (President p in list)
            {
                HyperLink a = new HyperLink();
                a.CssClass = "a_president";
                a.Text = p.Name;
                a.ToolTip = string.Format("{0}({1})",p.ClubName,p.Rank);
                a.NavigateUrl = "#";
                a.Attributes.Add("account", p.Account);
                //a.Attributes.Add("account", );

                div_president.Controls.Add(a);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string account = txt_recivierAccount.Text;
            MessageBLL messageBLL = new MessageBLL();
            if (Users.GetUserByAccount(account))
            {
                int count = messageBLL.SendMessage(CurrentUserHelp.currentUserBLL.Id, account, txt_sendHead.Text, edit1.Text);
                if (count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SendMessage", "<script type=\"text/javascript\">alert('发送成功');</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "LoseReciver", "<script type=\"text/javascript\">alert('收件人不存在');</script>", false);
            }
        }
    }
}