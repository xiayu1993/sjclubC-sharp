<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Web.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .top_ul
        {
            padding:0px;    
        }
        .top_li
        {
            list-style-type:none;
            float:left;    
        }
        .top_li + .top_li
        {
            margin-left:20px;   
        }
    </style>
    <%--<script src="script/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".top_li").click(function () {
                alert("hah");
                window.opener = null;
                window.close();
            })
        })
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="top_ul">
            <li class="top_li"><a target="main" href="<%=ConfigurationManager.AppSettings["PageIndex"].ToString() %>">首页</a></li>
            <li class="top_li"><a target="main" href="<%=ConfigurationManager.AppSettings["PageActive"].ToString() %>">社团活动</a></li>
            <li class="top_li"><a target="main" href="<%=ConfigurationManager.AppSettings["PageList"].ToString() %>">社团列表</a></li>
            <li class="top_li"><a target="main" href="<%=ConfigurationManager.AppSettings["PageUtility"].ToString() %>">实用工具</a></li>
            <li class="top_li"><a target="main" href="<%=ConfigurationManager.AppSettings["PageAbout"].ToString() %>">关于我们</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
