<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="SendedMessageList.aspx.cs" Inherits="Web.MessageCenter.SendedMessageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>发件箱</h2>
    <a href="SendMessage.aspx"><img src="../Images/mail_add.png" alt="" />发送邮件</a>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderImageUrl="~/Images/mail_close.png">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Convert.ToBoolean(Eval("IsCheck"))?"~/Images/mail_open.png":"~/Images/mail_close.png"%>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ReceiveUsersName" HeaderText="收件人" />
            <asp:BoundField DataField="SendHead" HeaderText="标题" />
            <asp:BoundField DataField="SendTime" HeaderText="发送时间" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='CheckMessage.aspx?mailId=<%#Eval("Id").ToString() %>'>查看邮件</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
