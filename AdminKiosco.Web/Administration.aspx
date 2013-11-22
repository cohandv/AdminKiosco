<%@ Page Title="Adminitration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="AdminKiosco.Web.Administration" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Administracion de paradas</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <article>
        <asp:GridView ID="Menu1" runat="server" AutoGenerateColumns="false"
            CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
            <Columns>
                <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                    <ItemTemplate>
                        <asp:DynamicHyperLink ID="HyperLink1" runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </article>

    <aside>
        <h3>Administración de Usuarios</h3>
        <ul>
            <li><a runat="server" href="~/Usuarios/List.aspx">Usuarios</a></li>
            <li><a runat="server" href="~/Roles/List.aspx">Roles</a></li>
            <li><a runat="server" href="~/Permisos/List.aspx">Permisos</a></li>
        </ul>
    </aside>
</asp:Content>