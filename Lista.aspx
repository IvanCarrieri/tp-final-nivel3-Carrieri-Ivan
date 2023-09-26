<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="WebFinal.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <label for="TextBoxBuscarPorNombre" class="col-sm-4 col-form-label">Buscar por nombre</label>
            <div class="mb-4">
                <div class="row">
                    <div class="col-6">
                        <asp:TextBox ID="TextBoxBuscarPorNombre" TextMode="Search" AutoPostBack="true" CssClass="form-control" OnTextChanged="TextBoxBuscarPorNombre_TextChanged" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-auto">
                        <asp:CheckBox ID="CheckBoxFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="CheckBoxFiltroAvanzado_CheckedChanged" runat="server" />
                        <label for="CheckBoxFiltroAvanzado" class="form-check-label">Filtro avanzado</label>
                    </div>

                </div>
            </div>

            <%if (CheckBoxFiltroAvanzado.Checked == true)
                { %>
            <div class="row">
                <div class="col-auto">
                    <div class="mb-4">
                        <label for="exampleFormControlInput1" class="form-label">Categoria</label>
                        <asp:DropDownList ID="DropDownListCategoria" CssClass="btn btn-secondary dropdown-toggle" AutoPostBack="false"
                            runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-auto">
                    <div class="mb-4">
                        <label for="exampleFormControlInput1" class="form-label">Marca</label>
                        <asp:DropDownList ID="DropDownListMarca" CssClass="btn btn-secondary dropdown-toggle" AutoPostBack="false" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-auto">
                    <div class="mb-4">
                        <label for="exampleFormControlInput1" class="form-label">Precio</label>
                        <asp:DropDownList ID="DropDownListPrecio" CssClass="btn btn-secondary dropdown-toggle" AutoPostBack="false" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Mayor a" />
                            <asp:ListItem Text="Menor a" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-auto">
                    <div class="mb-3">
                        <asp:TextBox ID="TextBoxPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-auto">
                    <div class="mb-4">
                        <label for="exampleFormControlInput1" class="form-label">Estado</label>
                        <asp:DropDownList ID="DropDownListEstado" CssClass="btn btn-secondary dropdown-toggle" AutoPostBack="false" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="mb-3">
                    <div>
                        <asp:Button ID="ButtonBuscarFiltroAvanzado" OnClick="ButtonBuscarFiltroAvanzado_Click" CssClass="btn btn-info" runat="server" Text="Buscar" />
                    </div>

                </div>
            </div>

            <% } %>

            <br />
            <blockquote class="blockquote">
                <p>Lista de articulos</p>
            </blockquote>
            <asp:GridView DataKeyNames="Id" ID="GridViewArticulos" CssClass="table table-success table-striped"  AutoGenerateColumns="false" runat="server"
                OnSelectedIndexChanged="GridViewArticulos_SelectedIndexChanged"
                OnPageIndexChanging="GridViewArticulos_PageIndexChanging" OnPageIndexChanged="ButtonBuscarFiltroAvanzado_Click"
                AllowPaging="True" PageSize="8">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✍" />
                </Columns>
            </asp:GridView>
            <a href="FormularioArticulo.aspx" class="btn btn-info">Agregar</a>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>




