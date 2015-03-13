using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;
using SJmedia.Model;

namespace Web.WebManage
{
    public partial class UsersManage : System.Web.UI.Page
    {
        //成员序号
        public int xh=0;

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
            IList<T_Users> users =  Users.GetUsers();
            rpt1.DataSource = users;
            rpt1.DataBind();
        }

        public string ChangeToStatus(string StatusId)
        {
            T_Status status = Users.GetStatusById(StatusId);
            return status.Type;
        }

        protected void lbtn1_Command(object sender, CommandEventArgs e)
        {
            string uid = e.CommandArgument.ToString();

            int count = Users.DeleteUserById(uid);
            if (count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "DeleteUser", "<script type=\"text/javascript\">alert('删除成功');</script>", false);
                BindData();
            }
        }

        public int Count()
        {
            xh++;
            return xh;
        }

        public int GetAllCount()
        {
            IList<T_Users> users = Users.GetUsers();
            return users.Count; 
        }
    }
}