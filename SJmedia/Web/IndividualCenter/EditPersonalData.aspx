<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="EditPersonalData.aspx.cs" Inherits="Web.IndividualCenter.EditPersonalData" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>个人资料</h2>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table>
                <tr>
                    <td>
                        昵称：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        性别：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdbtnl_Sex" runat="server">
                            <asp:ListItem Text="男" Value="true"></asp:ListItem>
                            <asp:ListItem Text="女" Value="false"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        生日：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Birthday" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txt_Birthday_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txt_Birthday">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        兴趣爱好：
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server">此功能开发中</asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        个人说明：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Introducation" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txt_Number" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        姓名：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_TrueName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        学院：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Academy" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_save" runat="server" Text="保存" onclick="btn_save_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_cancle" runat="server" Text="取消" 
                            onclick="btn_cancle_Click" />
                    </td>
                </tr>
       </table>
</asp:Content>
