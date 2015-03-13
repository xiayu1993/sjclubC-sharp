using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;
using SJmedia.Model;

namespace Web.ClubManage
{
    public partial class ChangeClubInformation : System.Web.UI.Page
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
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);

            txt_ClubName.Text = club.ClubName;
            txt_Instruction.Text = club.ClubIntroduction;
            img_ClubLogo.ImageUrl = string.Format("~/{0}/ClubLogo/{1}", club.ClubRoute, club.ClubLogo);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);

            Guid clubId = club.Id;
            string clubName = txt_ClubName.Text;
            string clubInstruction = txt_Instruction.Text;
            string clubLogo = string.Empty;

            if (!string.IsNullOrEmpty(hidfile.Value))
            {
                clubLogo = hidfile.Value;
            }
            else
            {
                clubLogo = club.ClubLogo;
            }

            int count = clubCenterBLL.ChangeClubInformation(clubId, clubName, clubInstruction, clubLogo);
            if (count > 0)
            {
                string js = "<script type=\"text/javascript\">alert('更改社团信息成功');window.location='ClubData.aspx';</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeClubInformation", js, false);
            }
        }

        protected void btn_changeLogo_Click(object sender, EventArgs e)
        {
            //将logo存在文件夹中
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);

            string fileName = fupload.PostedFile.FileName;
            string filePath = string.Format("~/{0}/ClubLogo/{1}", club.ClubRoute, fileName);

            hidfile.Value = fileName;

            fupload.PostedFile.SaveAs(Server.MapPath(filePath));

            img_ClubLogo.ImageUrl = filePath;
            //BindData();
        }
    }
}