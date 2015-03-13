using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;
using SJmedia.Model;

namespace Web.IndividualCenter
{
    public partial class EditPersonalData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        { 
            txt_Name.Text = CurrentUserHelp.currentUserBLL.Name;                        //昵称
            bool? sex = CurrentUserHelp.currentUserBLL.Sex;
            if (sex!=null)
            {
                rdbtnl_Sex.SelectedIndex = Convert.ToBoolean(sex) ? 0 : 1;              //性别
            }
      
            txt_Birthday.Text = CurrentUserHelp.currentUserBLL.Birthday.ToShortDateString();                //生日
            txt_Introducation.Text = CurrentUserHelp.currentUserBLL.Introducation;      //个人说明
            txt_Number.Text = CurrentUserHelp.currentUserBLL.Number.ToString();         //学号
            txt_TrueName.Text = CurrentUserHelp.currentUserBLL.TrueName;                //真实姓名
            txt_Academy.Text = CurrentUserHelp.currentUserBLL.Academy;                  //学院
        }

        protected void CheckId()
        {
            //检查当前用户是否存在
            if (string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.Id))
            {
                string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                string js = "<script type=\"text/javascript\">parent.location=\"" + url + " \";</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangePassword", js, false);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string userId = CurrentUserHelp.currentUserBLL.Id;  //用户id

            string name = txt_Name.Text;                        //昵称
            string sex = string.IsNullOrEmpty(rdbtnl_Sex.SelectedValue) ?
                "男" : rdbtnl_Sex.SelectedValue;        //性别
            string birthday = txt_Birthday.Text == "" ? null : txt_Birthday.Text;                //生日
            string introducation = txt_Introducation.Text;      //个人说明
            string number = txt_Number.Text;                    //学号
            string trueName = txt_TrueName.Text;                //真实姓名
            string academy = txt_Academy.Text;                  //学院

            T_Users user = new T_Users();
            user.Id = new Guid(userId);
            user.Name = name;
            if(string.IsNullOrEmpty(sex))
                user.Sex = null;
            else
                user.Sex = Convert.ToBoolean(sex);

            user.Birthday = birthday;
            user.Introducation = introducation;
            if(string.IsNullOrEmpty(number))
                user.Number = null;
            else
                user.Number = Convert.ToInt64(number);

            user.TrueName = trueName;
            user.Academy = academy;

            int count = CurrentUserHelp.currentUserBLL.UpdateUserInformation(user);
            if(count>0)
            {
                CurrentUserHelp.currentUserBLL.GetUserById(user.Id.ToString());
                Page.ClientScript.RegisterStartupScript(GetType(), "ChangeUserInformation", "<script type=\"text/javascript\">alert('修改信息成功');window.location=\"PersonalData.aspx\"</script>", false);
            }
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalData.aspx");
        }
    }
}