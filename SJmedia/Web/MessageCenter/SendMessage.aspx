<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="Web.MessageCenter.SendMessage" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../script/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../script/JScript.js" type="text/javascript"></script>
    <style type="text/css">
        .a_president
        {
            display:block;            
        }
        #div_president
        {
             height:350px;
             overflow-y:scroll;
             width:240px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>收件人</td>
            <td><asp:TextBox ID="txt_recivierAccount" runat="server" ClientIDMode="Static"></asp:TextBox></td>
            <td rowspan="3">
                <div>
                    <h4>和社团联系吧</h4>
                    <div id="div_president" runat="server" clientidmode="Static">
                        
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>主题</td>
            <td><asp:TextBox ID="txt_sendHead" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>正文</td>
            <td>
                <CKEditor:CKEditorControl ID="edit1" runat="server" EnterMode="BR" 
                    FullPage="True" BasePath="~/ckeditor2"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">发送</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
