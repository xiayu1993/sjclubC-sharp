<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="PersonalData.aspx.cs" Inherits="Web.IndividualCenter.PersonalData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>个人资料</h2>
    <asp:FormView ID="fv1" runat="server">
        <ItemTemplate>
            <table>
                <tr>
                    <td colspan="2">
                        <a href="EditPersonalData.aspx">修改个人信息</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        昵称：
                    </td>
                    <td>
                        <asp:Label ID="lab_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        账号：
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("Account") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        身份：
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("StatusName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        性别：
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Sex") == null?"":(Convert.ToBoolean(Eval("Sex"))?"男":"女") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        所属社团：
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("ClubName")==null?"暂无社团":Eval("ClubName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        生日：
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Birthday","{0:d}") %>'></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        兴趣爱好：
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" ></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        个人说明：
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("Introducation") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td  colspan="2">
                        *下面三条信息是判断是否为江汉大学校内学生的重要信息
                    </td>
                </tr>
                <tr>
                    <td>
                        学号：
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("Number") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        姓名：
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("TrueName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        学院：
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Academy") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
