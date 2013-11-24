<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AdminKiosco.Web.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Cualquier duda comunicarse con alguno de los siguientes datos.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Administrador: David Cohan</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>15-3429-9626</span>
        </p>
        <p>
            <span class="label">Email:</span>
            <span>cohandv@gmail.com</span>
        </p>
    </section

     <section class="contact">
        <header>
            <h3>Dueño: Jonas Cohan</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>15-3429-9626</span>
        </p>
        <p>
            <span class="label">Email:</span>
            <span>cohandv@gmail.com</span>
        </p>
    </section>
</asp:Content>