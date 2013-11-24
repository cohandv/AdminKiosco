<%@ Control Language="C#" CodeBehind="Enumeration.ascx.cs" Inherits="AdminKiosco.Web.EnumerationFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
  <asp:ListItem Text="Todos" Value="" />
</asp:DropDownList>

