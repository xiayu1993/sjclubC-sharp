<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="UsersManage.aspx.cs" Inherits="Web.WebManage.UsersManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>用户资料</h2>
    <span>用户总数:<asp:Label ID="Label6" runat="server"><%=GetAllCount()%></asp:Label></span>
    <asp:Repeater ID="rpt1" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" border="1" style="border-collapse:collapse;border:1px solid Gray;">
                <tr>
                    <th align="center">序号</th>
                    <th align="center">账号</th>
                    <th align="center">昵称</th>
                    <th align="center">真名</th>
                    <th align="center">性别</th>
                    <th align="center">身份</th>
                    <th align="center">查看</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="Label5" runat="server"><%=Count()%>
                </asp:Label></td>
                <td><asp:Label ID="Label7" runat="server" Text='<%#Eval("Account") %>'></asp:Label></td>
                <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("TrueName") %>'></asp:Label></td>
                <td><asp:Label ID="Label3" runat="server" Text='<%#Eval("Sex") == null?"":(Convert.ToBoolean(Eval("Sex"))?"男":"女") %>'></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server"><%#ChangeToStatus(Eval("Status").ToString())%></asp:Label></td>
                <td><a href="UserDetail.aspx?uid=<%#Eval("Id") %>">查看详细信息</a>
                <asp:LinkButton ID="lbtn1" runat="server"
                 OnClientClick='return confirm("确定要删除此用户吗？")'
                 CommandArgument='<%#Eval("Id") %>'
                 OnCommand="lbtn1_Command"
                 >删除</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
