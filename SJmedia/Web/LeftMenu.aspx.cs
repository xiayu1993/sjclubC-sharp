using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJmedia.BusinessLogicLayer;

namespace Web
{
    public partial class LeftMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLeftMenu();
            }
        }

        private void BindLeftMenu()
        {
            MenuBLL menuBLL = new MenuBLL();
            menuBLL.BindLeftMenu(acc1);
        }
    }
}