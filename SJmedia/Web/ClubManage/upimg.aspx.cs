using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using SJmedia.BusinessLogicLayer;
using SJmedia.Model;
using System.Configuration;

namespace Web.ClubManage
{
    public partial class upimg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();
        }

        protected void CheckId()
        {
            //检查当前用户是否存在
            if (string.IsNullOrEmpty(CurrentUserHelp.currentUserBLL.Id))
            {
                string url = ConfigurationManager.AppSettings["ReceptionPage"].ToString();
                Response.Redirect(url);
            }
        }

        //点击上传按钮，如果文件路径不为空进行上传操作 
        protected void Button1_Click(object sender, EventArgs e) 
        { 
            if (this.upLoadFile.PostedFile.ContentLength != 0) 
            { 
                string imgdir = UpImg();

                //调用前台JS函数，将图片插入编辑器中即我们在addpic.js写的upimg函数 
                string script = "window.parent.upimg('" + imgdir + "');";

                ResponseScript(script); 
            } 
            else 
            { 
                Response.Write("请选择图片"); 
            } 
        }

      //点击取消按钮，关闭弹出窗口 
        protected void Button2_Click(object sender, EventArgs e) 
        { 
            string script = "window.parent.close();"; 
            ResponseScript(script); 
        } 
        /// <summary> 
        /// 输出脚本 
        /// </summary> 
        public void ResponseScript(string script) 
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder("<script language='javascript' type='text/javascript'>"); 
            sb.Append(script); 
            sb.Append("</script>"); 
            ClientScript.RegisterStartupScript(this.GetType(), RandomString(1), sb.ToString()); 
        } 
        /// <summary> 
        /// 获得随机数 
        /// </summary> 
        /// <param name="count">长度</param> 
        /// <returns></returns> 
        public static string RandomString(int count) 
        { 
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); 
            byte[] data = new byte[count]; 
            rng.GetBytes(data); 
            return BitConverter.ToString(data).Replace("-", ""); 
        }

        //上传函数我将图片都存在了服务器相应的社团路径下文件夹下 
        public string UpImg()
        {
            string imgdir = "";
            if (this.upLoadFile.PostedFile.ContentLength != 0)
            {
                string fileFullName = this.upLoadFile.PostedFile.FileName;// 
                int i = fileFullName.LastIndexOf(".");
                string fileType = fileFullName.Substring(i);
                if (fileType != ".gif" && fileType != ".jpg" &&
                    fileType != ".bmp" && fileType != ".jpeg" &&
                    fileType != ".png")
                {
                    Response.Write("文件格式不正确");
                    Response.End();
                }
                else
                {
                    DateTime now = DateTime.Now;
                    string newFileName = now.Millisecond + '_' + upLoadFile.PostedFile.ContentLength.ToString() + fileType;
                    //获取社团路径
                    ClubCenterBLL clubCenterBLL = new ClubCenterBLL();
                    T_Club club = clubCenterBLL.GetClubInformation(CurrentUserHelp.currentUserBLL.Id);
                    upLoadFile.PostedFile.SaveAs(Server.MapPath("../" + club.ClubRoute + "/ClubActiveImages/" + newFileName));
                    imgdir = "../" + club.ClubRoute + "/ClubActiveImages/" + newFileName;
                }
            }
            return imgdir;
        }
    }
}