using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using SJmedia.Common;
using System.Configuration;

namespace Web.ClubManage
{
    public partial class AllocationPower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();
            if (!IsPostBack)
            {
                
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
            else
            {
                BindData();
            }
        }

        protected void BindData()
        {
            ckbl_ClubMember.Items.Clear();
            ckbl_AssociatePublisher.Items.Clear();
            MemberCenterBLL memberCenterBLL = new MemberCenterBLL();
            IList<MemberInformation> list = memberCenterBLL.GetAllClubMember(CurrentUserHelp.currentUserBLL.ClubId);
            
            foreach (MemberInformation memberInformation in list)
            {
                string trueName = string.IsNullOrEmpty(memberInformation.TrueName)? string.Empty : memberInformation.TrueName.ToString();
                switch (memberInformation.Rank)
                {
                    case 1:
                        BindControl.BindCheckBoxList(ckbl_ClubMember, trueName, memberInformation.Id);
                        break;
                    case 2:
                        BindControl.BindCheckBoxList(ckbl_AssociatePublisher, trueName, memberInformation.Id);
                        break;
                    default: break;
                }
            }
        }

        //点击撤销副社按钮
        protected void btn_AssociatePublisher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ckbl_AssociatePublisher.Items.Count; i++)
            {
                if (ckbl_AssociatePublisher.Items[i].Selected)
                {
                    MemberCenterBLL memberCenterBLL = new MemberCenterBLL();
                    memberCenterBLL.RevokeAssociatePublisher(Guid.Parse(ckbl_AssociatePublisher.Items[i].Value));
                }
            }
            BindData();
        }

        //点击设置为副社
        protected void btn_ClubMember_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ckbl_ClubMember.Items.Count; i++)
            {
                if (ckbl_ClubMember.Items[i].Selected)
                {
                    MemberCenterBLL memberCenterBLL = new MemberCenterBLL();
                    memberCenterBLL.SetAssociatePublisher(Guid.Parse(ckbl_ClubMember.Items[i].Value));
                }
            }
            BindData();
        }
    }
}