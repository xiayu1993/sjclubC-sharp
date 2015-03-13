using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJmedia.DALFactory;
using SJmedia.Model;
using SJmedia.SQLSeverDAL;
using System.Web;
using AjaxControlToolkit;
using System.Web.UI.WebControls;
using System.Web.UI;
using SJmedia.Common;

namespace SJmedia.BusinessLogicLayer
{
    public class MenuBLL
    {
        #region 绑定左侧菜单
        public void BindLeftMenu(Accordion acc)
        {
            IList<T_BackMenu> list_RootMenu = Factory.GetMenuDALInstance().GetRootBackMenu(CurrentUserHelp.currentUserBLL.RankId);
            IList<T_BackMenu> list = Factory.GetMenuDALInstance().GetBackMenu(CurrentUserHelp.currentUserBLL.RankId);

            for(int j=0;j<list_RootMenu.Count;j++)
            //foreach (T_BackMenu i in list_RootMenu)
            {
                T_BackMenu i = list_RootMenu[j];

                AccordionPane accPanl = new AccordionPane();
                accPanl.ID = "acc1_" + i.Id;

                Label lab_Header = new Label();
                lab_Header.ID = "lab_" + i.Id;
                lab_Header.Text = i.MenuName;

                accPanl.HeaderContainer.Controls.Add(lab_Header);
                //accPanl.HeaderContainer.CssClass = "menu_lab";

                foreach (T_BackMenu s in list)
                {
                    if (s.Id != s.ParentID && s.ParentID != null && i.Id == s.ParentID)
                    {
                        HyperLink a_Content = new HyperLink();
                        a_Content.ID = "a_" + s.Id;
                        a_Content.Text = s.MenuName;
                        //不是社团会员的用户将看不到社团里面的信息
                        if (i.MenuName == "社团中心")
                        {
                            a_Content.NavigateUrl = string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.ClubName) ?
                                "ClubManage/EmptyClub.aspx" : s.URL;
                        }
                        else
                        {
                            a_Content.NavigateUrl = s.URL;
                        }
                        a_Content.Target = "right";

                        Panel panl = new Panel();
                        panl.CssClass = "menu_a";
                        panl.Controls.Add(a_Content);

                        accPanl.ContentContainer.Controls.Add(panl);
                        ////控件之间换行
                        //accPanl.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                    }
                }

                acc.Panes.Add(accPanl);
                //每个panl下加个中间横线层,如果是最后一个则不加
                if (j != list_RootMenu.Count - 1)
                {
                    AccordionPane accPanel = new AccordionPane();
                    accPanel.ID = "panl_hr" + i.Id;
                    Panel panel = new Panel();
                    panel.CssClass = "hr_black";
                    accPanel.HeaderContainer.Controls.Add(panel);

                    acc.Panes.Add(accPanel);
                }
            }
        }
        #endregion

        #region 在左侧菜单中添加菜单
        public void AddLeftMenu()
        {

        }
        #endregion

        #region 在左侧菜单中删除菜单
        public void DeleteLeftMenu()
        {

        }
        #endregion

        #region 绑定权限菜单
        public void BindPowerMenu(TreeView treeView, Guid rankId)
        {
            treeView.CollapseAll();

            IList<T_BackMenu> list = Factory.GetMenuDALInstance().GetAllBackMenu();
            IList<T_BackMenuAndUsers> listPower = Factory.GetMenuDALInstance().GetBackMenuAndUsersByRank(rankId);
            Power power = new Power();
            IList<T_FunctionAuthority> listFunctionAuthority = power.GetAllFunctionAuthority();

            foreach (T_BackMenu backMenu in list)
            {
                if (backMenu.Id == backMenu.ParentID || backMenu.ParentID == null)
                {
                    TreeNode node = new TreeNode();
                    node.Text = backMenu.MenuName;
                    node.Value = backMenu.Id.ToString();
                    //node.ToolTip = backMenu.Id.ToString();

                    foreach (T_FunctionAuthority functionAuthority in listFunctionAuthority)
                    {
                        if (node.Value.ToLower() == functionAuthority.BackMenuId.ToString().Trim().ToLower())
                        {
                            TreeNode node_functionAuthority = new TreeNode();
                            node_functionAuthority.Text = functionAuthority.FunctionName;
                            node_functionAuthority.Value = functionAuthority.Id.ToString();

                            node.ChildNodes.Add(node_functionAuthority);
                        }
                    }

                    treeView.Nodes.Add(node);

                    //绑定子菜单
                    BindControl.BindTreeView(node, list, listFunctionAuthority);
                }
            }

            //判断权限
            CheckPower(treeView.Nodes, listPower);
        }

        public void CheckPower(TreeNodeCollection nodes, IList<T_BackMenuAndUsers> listPower)
        {
            if (nodes != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (listPower.Count > 0)
                    {
                        foreach (T_BackMenuAndUsers backMenuPower in listPower)
                        {
                            if (node.Value == backMenuPower.BackMenuId.ToString())
                            {
                                node.Checked = true;
                                node.Expand();
                                break;
                            }
                            else
                                node.Collapse();
                        }
                    }
                    else
                        node.Collapse();
                    CheckPower(node.ChildNodes, listPower);
                }
            }
        }
        #endregion
    }
}
