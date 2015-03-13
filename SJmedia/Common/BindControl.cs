using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using SJmedia.Model;

namespace SJmedia.Common
{
    public class BindControl
    {
        #region 绑定CheckBoxList
        public static void BindCheckBoxList(CheckBoxList checkBoxList, string text, string value)
        {
            ListItem listItem = new ListItem(text, value);
            checkBoxList.Items.Add(listItem);
        }
        #endregion

        #region 绑定TreeView
        public static void BindTreeView(TreeNode node, IList<T_BackMenu> list, IList<T_FunctionAuthority> listFunctionAuthority)
        {
            foreach (T_BackMenu backMenu in list)
            {
                if (backMenu.Id != backMenu.ParentID && backMenu.ParentID != null && node.Value == backMenu.ParentID.ToString())
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = backMenu.MenuName;
                    childNode.Value = backMenu.Id.ToString();

                    childNode.ToolTip = backMenu.Id.ToString();

                    foreach (T_FunctionAuthority functionAuthority in listFunctionAuthority)
                    {
                        if (childNode.Value.ToLower() == functionAuthority.BackMenuId.ToString().Trim().ToLower())
                        {
                            TreeNode node_functionAuthority = new TreeNode();
                            node_functionAuthority.Text = functionAuthority.FunctionName;
                            node_functionAuthority.Value = functionAuthority.Id.ToString();

                            childNode.ChildNodes.Add(node_functionAuthority);
                        }
                    }

                    node.ChildNodes.Add(childNode);
                    BindTreeView(childNode, list, listFunctionAuthority);
                }
            }
        }
        #endregion

        #region 绑定DropDownList
        public static void BindDropDownList(DropDownList dropDownList,IList<T_Status> list)
        {
            foreach (T_Status status in list)
            {
                ListItem listItem = new ListItem(status.Type, status.Id.ToString());
                dropDownList.Items.Add(listItem);
            }
        }
        #endregion
    }
}
