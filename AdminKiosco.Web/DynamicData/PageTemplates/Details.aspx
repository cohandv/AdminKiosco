<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Details.aspx.cs" Inherits="AdminKiosco.Web.Details" %>


<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Detalle de <%= table.DisplayName %></h2>
            </hgroup>
        </div>
    </section>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="FormView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                HeaderText="Lista de errores" CssClass="DDValidator" />
            <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />

            <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" OnItemDeleted="FormView1_ItemDeleted" RenderOuterTable="false">
                <ItemTemplate>
                    <table id="detailsTable" class="DDDetailsTable" cellpadding="6">
                        <asp:DynamicEntity runat="server" />
                        <tr class="td">
                            <td colspan="2">
                                <asp:DynamicHyperLink runat="server" Action="Edit" Text="Editar" ID="lnkEditBtn"  />
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Borrar"
                                    OnClientClick='return confirm("Esta seguro de borrar este elemento?");' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="DDNoItem">No existe el elemento.</div>
                </EmptyDataTemplate>
            </asp:FormView>

            <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="false" />

            <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
                <asp:DynamicRouteExpression />
            </asp:QueryExtender>

            <br />

            <div class="DDBottomHyperLink">
                <asp:DynamicHyperLink ID="ListHyperLink" runat="server" Action="List">Mostrar todos los elementos</asp:DynamicHyperLink>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

