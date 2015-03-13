using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;
using System.Configuration;
using SJmedia.Model;
using SJmedia.Common;

namespace Web.WebManage
{
    public partial class AllocationOfRights : System.Web.UI.Page
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
            //绑定下拉框
            Power power = new Power();
            IList<T_Status> list = power.GetAllStatus();
            BindControl.BindDropDownList(ddl_PowerList, list);

            //绑定权限菜单
            //tv_backMenu.Attributes.Add("onclick", "postBackByObject()");//已经在前台加了
            string rankId = ddl_PowerList.SelectedValue;
            MenuBLL menuBll = new MenuBLL();
            menuBll.BindPowerMenu(tv_backMenu, Guid.Parse(rankId));
        }

        protected void ddl_PowerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //清楚原菜单中所有项
            tv_backMenu.Nodes.Clear();
            //绑定权限菜单
            string rankId = ddl_PowerList.SelectedValue;
            MenuBLL menuBLL = new MenuBLL();
            menuBLL.BindPowerMenu(tv_backMenu, Guid.Parse(rankId));
        }

        protected void tv_backMenu_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.Checked)
            {
                ChangeTreeNodeWhenItChecked(e.Node.Parent);
            }
            else
            {
                ChangeTreeNodeWhenItNotChecked(e.Node.ChildNodes);
            }
        }

        protected void ChangeTreeNodeWhenItChecked(TreeNode node)
        {
            if (node != null)
            {
                node.Checked = true;
                ChangeTreeNodeWhenItChecked(node.Parent);
            }
        }

        protected void ChangeTreeNodeWhenItNotChecked(TreeNodeCollection childNodes)
        {
            if (childNodes != null)
            {
                foreach (TreeNode node in childNodes)
                {
                    node.Checked = false;
                    ChangeTreeNodeWhenItNotChecked(node.ChildNodes);
                }
            }
        }

        protected void btn_changePower_Click(object sender, EventArgs e)
        {
            string rankId = ddl_PowerList.SelectedValue;//身份id

            IList<Guid> menuId = new List<Guid>();//权限id集合
            TreeNodeCollection nodes = tv_backMenu.CheckedNodes;
            foreach (TreeNode node in nodes)
            {
                menuId.Add(Guid.Parse(node.Value));
            }

            Power power = new Power();
            int count = power.ChangeBackMenuAndUsersByRank(Guid.Parse(rankId), menuId);
            if (count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangePower", "<script type=\"text/javascript\">alert(\"成功修改权限\");parent.location.reload(true);</script>", false);
            }
        }
    }
}