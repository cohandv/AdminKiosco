<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminKiosco.Web._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script type="text/javascript">
            $(document).ready(function () {


            });
    </script>   
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Cooperativa de canillitas</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Sindicato de Canillitas</h3>
    <div style="width: 900px;height: 211px; position: relative; background: url(http://www.sivendia.org.ar/slogan_section_bg.png) no-repeat top center #320712; ">
    <p><a>http://www.sivendia.org.ar/</a></p>
    </div>
</asp:Content>
