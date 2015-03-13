<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="ClubActivities.aspx.cs" Inherits="Web.ClubManage.ClubActivities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>社团活动列表</h2>
    <a id="a_addclubactive" href="AddClubActive.aspx" runat="server">添加社团活动</a>
    <hr />
    <asp:Repeater ID="rpt1" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" border="1" style="border-collapse:collapse;border:1px solid Gray;">
                <tr>
                    <th align="center">活动名称</th>
                    <th align="center">活动时间</th>
                    <th align="center">操作</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("ActiveHead") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("ActiveTime") %>'></asp:Label></td>
                <td>
                <asp:HyperLink ID="a_checkclubactiveActive" NavigateUrl='<%#Eval("Id","ClubActiveDetail.aspx?ClubActiveId={0}") %>' runat="server">查看活动详情</asp:HyperLink>
                <asp:HyperLink ID="a_editClubActive" NavigateUrl='<%#Eval("Id","AddClubActive.aspx?ClubActiveId={0}") %>' runat="server">编辑</asp:HyperLink>
                <asp:LinkButton ID="lbtn1" runat="server"
                 OnClientClick='return confirm("确定要删除此条活动信息吗？")'
                 CommandArgument='<%#Eval("Id") %>'
                 OnCommand="lbtn1_Command"
                 CommandName="delete"
                 >删除</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
