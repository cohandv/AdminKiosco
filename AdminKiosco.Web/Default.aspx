<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminKiosco.Web._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Funciones principales</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Opciones comunes:</h3>
    <ol class="round">
        <li class="one">
            <h5>Administracion</h5>
            Funciones principales:
            <a href="~/Pages/Bla.aspx">Agregar un producto…</a>
        </li>
        <li class="two">
            <h5>Facturacion</h5>
            Crear una facturación
            <a href="~/Pages/Bla.aspx">Revisar facturaciones anteriores</a>
            <a href="~/Pages/Bla.aspx">Crear una facturacion</a>
        </li>
        <li class="three">
            <h5>Reporting</h5>
            Visualizar reportes
            <a href="~/Report/Report1.aspx">Report 1</a>
        </li>
    </ol>
</asp:Content>
