using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Common
{
    public class Mail
    {
        //对原始邮件进行加工
        public string ChangeOldMail(string content, string sender, string receiver, string sendTime,string sendHead)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<br/><br/><br/><div style=\"font-size:20px;font-family:Arial Narrow;padding:2px 0 2px 0;\">-------------------&nbsp;<b>原始邮件</b>&nbsp;-------------------</div>");
            str.Append("<div style=\"font-size:12px;background-color:#d5d5d5;padding:8px;\">");
            str.Append("<div><b>发件人：</b>&nbsp" + sender + "</div>");
            str.Append("<div><b>发送时间：</b>&nbsp" + sendTime + "</div>");
            str.Append("<div><b>收件人：</b>&nbsp" + receiver + "</div>");
            str.Append("<div><b>标题：</b>&nbsp" + sendHead + "</div>");
            str.Append("</div><br/>");​
            str.Append(content);

            string str_value = str.ToString();
            return str_value;
        }
    }
}
