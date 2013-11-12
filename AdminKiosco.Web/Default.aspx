<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminKiosco.Web._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Principal Functions</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Administration</h5>
            Basic funcions:
            <a href="~/Pages/Bla.aspx">Add a Product…</a>
        </li>
        <li class="two">
            <h5>Billing</h5>
            Create a Billing
            <a href="~/Pages/Bla.aspx">View older billings</a>
            <a href="~/Pages/Bla.aspx">Create a billing</a>
        </li>
        <li class="three">
            <h5>Reporting</h5>
            Create and view reports
            <a href="~/Report/Report1.aspx">Report 1</a>
        </li>
    </ol>
</asp:Content>
