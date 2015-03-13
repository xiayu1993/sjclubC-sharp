<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="ChangeClubInformation.aspx.cs" Inherits="Web.ClubManage.ChangeClubInformation" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                社团名：
            </td>
            <td>
                <asp:TextBox ID="txt_ClubName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                社团Logo：
            </td>
            <td>
                <asp:Image ID="img_ClubLogo" runat="server" /><br />
                <span style="color:Red">*图片大小应为120px*90px，且格式为.jpg(.jpeg)或.png</span>
                <br />
                <asp:FileUpload ID="fupload" runat="server" />
                <asp:Button ID="btn_changeLogo" runat="server" Text="确定上传" 
                    onclick="btn_changeLogo_Click" />

            </td>
        </tr>
        <tr>
            <td>
                社团详情：
            </td>
            <td>
                <CKEditor:CKEditorControl ID="txt_Instruction" runat="server" BasePath="~/ckeditor2"></CKEditor:CKEditorControl>
            </td>
        </tr>
    </table>
    <asp:LinkButton ID="btn_save" runat="server" onclick="btn_save_Click">确认更改</asp:LinkButton>
    <%--<asp:Button ID="btn_save" runat="server" Text="确认更改" onclick="btn_save_Click" />--%>
<%--    <asp:Button ID="btn_back" runat="server" Text="返回" />--%>
    <a href="ClubData.aspx">返回</a>
    <asp:HiddenField ID="hidfile" runat="server" />
</asp:Content>
