<%@ Page Title="" Language="C#" MasterPageFile="~/rightMaster.Master" AutoEventWireup="true" CodeBehind="AllocationOfRights.aspx.cs" Inherits="Web.WebManage.AllocationOfRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function postBackByObject() {
            var o = window.event.srcElement;
            if (o.tagName == "INPUT" && o.type == "checkbox") {
                __doPostBack("tv_backMenu", ""); //此处前面是两个下划线(UpdatePanel1处是因为用了UpdatePanel所以才写这个控件ID的)
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>权限分配</h2>
    <asp:Button ID="btn_changePower" runat="server" Text="修改权限" 
        OnClientClick='return confirm("确认要修改吗")' onclick="btn_changePower_Click"/><br />
    <asp:DropDownList ID="ddl_PowerList" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddl_PowerList_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TreeView ID="tv_backMenu" runat="server" ShowCheckBoxes="All" ClientIDMode="Static" onclick="postBackByObject()" 
                ontreenodecheckchanged="tv_backMenu_TreeNodeCheckChanged">
            </asp:TreeView>
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
