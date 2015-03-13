<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="AddClubActive.aspx.cs" Inherits="Web.ClubManage.AddClubActive" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../script/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../script/popup_layer.js" type="text/javascript"></script>
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../ckeditor/addImage.js" type="text/javascript"></script>
    <style type ="text/css">
        .errorMessage
        {
            color:Red;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
            <div> 
                <div id="ele6" style="cursor:hand; color: blue; display:none;">
                </div> 
                <div id="blk6" class="blk" style="display:none;"> 
                    <div class="head"><div class="head-right"></div>
                </div> 
                    <div class="main">                 
                    <a href="javascript:void(0)"  id="close6" class="closeBtn"></a>                 
                    <iframe src="upimg.aspx"></iframe>                     
                    </div>           
                </div> 
            </div>
    <table>
        <tr>
            <td>活动名称</td>
            <td><asp:TextBox ID="tb_head" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>活动海报</td>
            <td>
                <asp:Image ID="img_poster" runat="server" /><br />
                <asp:FileUpload ID="fup_poster" runat="server" />
                <asp:Button ID="btn_poster" runat="server"
                    Text="上传海报" onclick="btn_poster_Click" /></td>
        </tr>
        <tr>
            <td>活动截止日期</td>
            <td>
                <asp:TextBox ID="txt_endtime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="errorMessage" ID="RequiredFieldValidator1" ControlToValidate="txt_endtime" runat="server" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txt_endtime">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>活动内容</td>
            <td>
                <CKEditor:CKEditorControl ID="ckedit1" runat="server" ClientIDMode="Static" EnterMode="BR">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
    </table>
    <div id="div_add" runat="server">
        <asp:LinkButton ID="btn1" runat="server" onclick="btn1_Click">创建活动</asp:LinkButton>
        <a href="ClubActivities.aspx">返回</a>
    </div>
    <div id="div_save" runat="server">
        <asp:Button ID="btn_save" runat="server" Text="保存" onclick="btn_save_Click" />
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
