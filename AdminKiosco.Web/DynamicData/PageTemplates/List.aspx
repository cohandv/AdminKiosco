<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="List.aspx.cs" Inherits="AdminKiosco.Web.List" %>

<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>  
    <script type="text/javascript">
        function getCookie(c_name) {
            if (document.cookie.length > 0) {
                c_start = document.cookie.indexOf(c_name + "=");
                if (c_start != -1) {
                    c_start = c_start + c_name.length + 1;
                    c_end = document.cookie.indexOf(";", c_start);
                    if (c_end == -1) {
                        c_end = document.cookie.length;
                    }
                    return unescape(document.cookie.substring(c_start, c_end));
                }
            }
            return "";
        }

        function EnableAction(action, link) {
            var tableName = document.getElementsByTagName("h2")[0].innerHTML;
            var RoleId = 'david';

            if (!window.Permissions) {
                $.ajax({
                    url: '../Services/CRUDServices.svc/RoleAction?$format=json&Table=' + tableName + '&RoleId='+RoleId,
                    success: function (data) {
                        var response = data.value;

                        if (data.value) {

                            if (action == 'delete') {
                                link.hidden = response.Delete;
                            }
                        }
                        else {
                            link.hidden = false;
                        }
                    }
                });
            }
        }

        $(document).ready(function () {

            console.log(getCookie('Paper.Roles'));
            
            
            //element ids
            var rows = document.getElementById('MainContent_GridView1').getElementsByTagName("tbody")[0].getElementsByTagName("tr");

            for (index = 1; index < rows.length; index++) {
                   
                console.log(index);
                var deleteItem = document.getElementById('MainContent_GridView1_DeleteLink_' + index);
                EnableAction('delete', deleteItem);

                var editItem = document.getElementById('MainContent_GridView1_EditLink_' + index);
                EnableAction('edit', editItem);
            }
        });
    </script>   
</asp:Content>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2><%= table.DisplayName %></h2>
            </hgroup>
        </div>
    </section>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="DD">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                    HeaderText="Lista de errores" CssClass="DDValidator" />
                <asp:DynamicValidator runat="server" ID="GridViewValidator" ControlToValidate="GridView1" Display="None" CssClass="DDValidator" />

                <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("DisplayName") %>' OnPreRender="Label_PreRender" />
                        <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged"/><br />
                    </ItemTemplate>
                </asp:QueryableFilterRepeater>
                <br />
                <asp:Label runat="server" Text="Nombre" ID="TextBox1" />
                <asp:TextBox runat="server" Text="" ID="NombreFilter"/>
                <br />
            </div>

            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true"
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DynamicHyperLink runat="server" Action="Edit" Text="Editar" ID="EditLink" 
                            />&nbsp;<asp:LinkButton ID="DeleteLink" runat="server" CommandName="Delete" Text="Borrar" 
                                OnClientClick='return confirm("Esta seguro de borrar el elemento?");' 
                            />&nbsp;<asp:DynamicHyperLink runat="server" Text="Detalles" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerStyle CssClass="DDFooter"/>        
                <PagerTemplate>
                    <asp:GridViewPager runat="server" />
                </PagerTemplate>
                <EmptyDataTemplate>
                    Actualmente no hay registros.
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:EntityDataSource ID="GridDataSource" runat="server" EnableDelete="true" OnDeleting="GridDataSource_Deleting"  AutoPage="true" />
            
            <asp:QueryExtender TargetControlID="GridDataSource" ID="GridQueryExtender" runat="server">
                <asp:DynamicFilterExpression ControlID="FilterRepeater"/>
                <asp:SearchExpression DataFields="Nombre" SearchType="Contains">
                    <asp:ControlParameter ControlID="NombreFilter" />
                </asp:SearchExpression>
            </asp:QueryExtender>

            <br />

            <div class="DDBottomHyperLink">
                <asp:DynamicHyperLink ID="InsertHyperLink" runat="server" Action="Insert"><img runat="server" src="~/DynamicData/Content/Images/plus.gif" alt="Agregar nuevo elemento." />Agregar nuevo elemento</asp:DynamicHyperLink>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

