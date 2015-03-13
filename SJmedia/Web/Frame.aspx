<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="Web.Frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <frameset rows="90,*,20" frameborder="1" border="1" framespacing="2" bordercolor="#010000" name = "main">
        <frame name="top" src="Top.aspx" noresize="noresize">
        <frameset cols="20%,*" frameborder="1" border="1" framespacing="2" bordercolor="#010000">
            <frame name="left" src="LeftMenu.aspx" noresize="noresize">
            <frame name="right" src="IndividualCenter/PersonalData.aspx" noresize="noresize"> 
        </frameset>
        <frame name="bottom" src="" noresize="noresize">
    </frameset>
    <noframes>
        <body>
            <p>您的浏览器不支持框架</p>
        </body>
    </noframes>
</html>
