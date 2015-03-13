<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upimg.aspx.cs" Inherits="Web.ClubManage.upimg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../script/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../script/popup_layer.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #CEFFCE">
    <div> 
         <br /> 
        &nbsp;&nbsp;&nbsp; 
        <asp:FileUpload ID="upLoadFile" runat="server" /> 
         <br /> 
         <br /> 
         &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text="上传" onclick="Button1_Click" /> 
        &nbsp;&nbsp;&nbsp; 
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="取消" /> 
        &nbsp;&nbsp; 
        </div> 
    </form>
</body>
</html>
