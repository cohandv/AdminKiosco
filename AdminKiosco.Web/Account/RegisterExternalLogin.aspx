<%@ Page Language="C#" Title="Register an external login" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="AdminKiosco.Web.Account.RegisterExternalLogin" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Register with your <%: ProviderDisplayName %> account</h1>
        <h2><%: ProviderUserName %>.</h2>
    </hgroup>

    
    <asp:ModelErrorMessage runat="server" ModelStateKey="Provider" CssClass="field-validation-error" />
    

    <asp:PlaceHolder runat="server" ID="userNameForm">
        <fieldset>
            <legend>Association Form</legend>
            <p>
                Se ha autenticado con <strong><%: ProviderDisplayName %></strong>.
                Por favor, ingrese un usuario debajo para el sitio actual 
                y presione el boton para entrar.
            </p>
            <ol>
                <li class="email">
                    <asp:Label runat="server" AssociatedControlID="userName">Usuario</asp:Label>
                    <asp:TextBox runat="server" ID="userName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="userName"
                        Display="Dynamic" ErrorMessage="Usuario requerido" ValidationGroup="NewUser" />
                    
                    <asp:ModelErrorMessage runat="server" ModelStateKey="UserName" CssClass="field-validation-error" />
                    
                </li>
            </ol>
            <asp:Button runat="server" Text="Entrar" ValidationGroup="NewUser" OnClick="logIn_Click" />
            <asp:Button runat="server" Text="Cancelar" CausesValidation="false" OnClick="cancel_Click" />
        </fieldset>
    </asp:PlaceHolder>
</asp:Content>
