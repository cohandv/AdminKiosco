<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="AdminKiosco.Web.ForeignKeyFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="Todos" Value="" />
</asp:DropDownList>

