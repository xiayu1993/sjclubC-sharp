<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="AllocationPower.aspx.cs" Inherits="Web.ClubManage.AllocationPower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>权限分配</h2>
    <div>
        <h3>副社列表</h3>
        <asp:CheckBoxList ID="ckbl_AssociatePublisher" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="btn_AssociatePublisher" runat="server" Text="撤销副社" 
            onclick="btn_AssociatePublisher_Click" />
    </div>
    <div>
        <h3>会员列表</h3>
        <asp:CheckBoxList ID="ckbl_ClubMember" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="btn_ClubMember" runat="server" Text="设置为副社" 
            onclick="btn_ClubMember_Click" />
    </div>
</asp:Content>
