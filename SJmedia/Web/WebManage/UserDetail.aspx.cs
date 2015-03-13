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
    public partial class UserDetail : System.Web.UI.Page
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
            if (string.IsNullOrEmpty(Request.QueryString["uid"]))
            {
                Response.Redirect("UsersManage.aspx");
            }
        }

        protected void BindData()
        {
            string uid = Request.QueryString["uid"].ToString();

            T_Users user = Users.GetUserById(uid);
            lab_Name.Text = user.Name;
            lab_Account.Text = user.Account;
            lab_password.Text = user.Password;

            T_Status status = Users.GetStatusById(user.Status.ToString());
            lab_StatusName.Text = status.Type;

            if (user.Sex != null)
                lab_Sex.Text = Convert.ToBoolean(user.Sex) ? "男" : "女";
            else
                lab_Sex.Text = string.Empty;

            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_Club club = clubCenterBLL.GetClubInformation(uid);
            if (club != null)
                lab_ClubName.Text = club.ClubName;  
            else
                lab_ClubName.Text = "暂无社团";
            DateTime dt;
            DateTime.TryParse(user.Birthday,out dt);
            lab_Birthday.Text = dt.ToShortDateString();
            lab_Introducation.Text = user.Introducation;
            lab_Number.Text = user.Number.ToString();
            lab_TrueName.Text = user.TrueName;
            lab_Academy.Text = user.Academy;
        }
    }
}