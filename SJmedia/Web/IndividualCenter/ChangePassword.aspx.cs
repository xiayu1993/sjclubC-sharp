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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn1_OnClick(object sender, EventArgs e)
        {
            string oldPassword = tb_oldPassword.Text;
            string newPassword = tb_newPassword.Text;

            if (!string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.Id))
            {
                int count = CurrentUserHelp.currentUserBLL.ChangeUserPassword(oldPassword, newPassword);
                //count=1时表示修改密码成功，count=0时表示修改密码失败，count=-1时表示无当前Id时执行的操作
                switch (count)
                {
                    case -1:
                        string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                        string js = "<script type=\"text/javascript\">parent.location=\"" + url + " \";</script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CheckUser", js, false);
                        break;
                    case 0:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangePassword", "<script type=\"text/javascript\">alert('账号错误');</script>", false);
                        break;
                    case 1:
                        tb_oldPassword.Text = "";
                        tb_newPassword.Text = "";
                        tb_newPassword2.Text = "";
                        Page.ClientScript.RegisterStartupScript(this.GetType(),"ChangePassword","<script type=\"text/javascript\">alert('修改密码成功');</script>",false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //无当前Id时执行的操作
                string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                string js = "<script type=\"text/javascript\">parent.location=\"" + url + " \";</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CheckUser", js, false);
            }
        }
    }
}