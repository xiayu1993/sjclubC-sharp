using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using SJmedia.Model;
using System.Configuration;

namespace Web.ClubManage
{
    public partial class AddClubActive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();
            if (!IsPostBack)
            {
                CheckClubActiveId();
            }
        }

        protected void CheckClubActiveId()
        {
            //检查当前社团活动id是否存在
            if (Request.QueryString["ClubActiveId"] != null)
            {
                div_add.Visible = false;
                div_save.Visible = true;
                //绑定活动相关信息
                BindData();
            }
            else
            {
                div_add.Visible = true;
                div_save.Visible = false;
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

        protected void btn1_Click(object sender, EventArgs e)
        {
            string str_head = tb_head.Text;
            string str_context = ckedit1.Text;
            DateTime endtime;
            DateTime.TryParse(txt_endtime.Text, out endtime);

            string imgName = HiddenField1.Value;
            
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            int count = clubCenterBLL.AddClubActive(str_head, str_context,endtime,imgName, CurrentUserHelp.currentUserBLL.ClubId);

            if (count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AddClubActive", "<script type=\"text/javascript\">alert('活动创建成功');window.location='ClubActivities.aspx';</script>", false);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //获取保存信息
            string activeId = Request.QueryString["ClubActiveId"].ToString();
            string str_head = tb_head.Text;
            string str_context = ckedit1.Text;
            DateTime endtime;
            DateTime.TryParse(txt_endtime.Text, out endtime);
            
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_ClubActive clubactive = clubCenterBLL.GetClubActiveDetail(activeId);
            string fileName ;

            if (!string.IsNullOrEmpty(HiddenField1.Value))
            {
                fileName = HiddenField1.Value;
            }
            else
            {
                fileName = clubactive.ActivePosterName;
            }

            int count = clubCenterBLL.ChangeClubActiveInformation(activeId, str_head, str_context, endtime, fileName);

            if (count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "UpdateClubActive", "<script type=\"text/javascript\">alert('更改活动信息成功');</script>", false);
            }
        }

        protected void BindData()
        {
            string activeId = Request.QueryString["ClubActiveId"].ToString();
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_ClubActive clubActive = clubCenterBLL.GetClubActiveDetail(activeId);

            tb_head.Text = clubActive.ActiveHead;
            txt_endtime.Text = clubActive.ActiveEndTime.ToShortDateString();
            ckedit1.Text = clubActive.ActiveContent;
            
            T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);
            img_poster.ImageUrl = string.Format("~/{0}/ClubActivePosterImg/{1}", club.ClubRoute, clubActive.ActivePosterName);
        }

        protected void btn_poster_Click(object sender, EventArgs e)
        {
            //将海报存在文件夹中
            ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
            T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);

            string fileName = fup_poster.PostedFile.FileName;
            string filePath = string.Format("~/{0}/ClubActivePosterImg/{1}", club.ClubRoute, fileName);

            HiddenField1.Value = fileName;

            fup_poster.PostedFile.SaveAs(Server.MapPath(filePath));

            img_poster.ImageUrl = filePath;
        }
    }
}