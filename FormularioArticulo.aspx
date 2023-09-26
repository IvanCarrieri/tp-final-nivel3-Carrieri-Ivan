<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="WebFinal.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
    <style>

        .validacion{
             color: red;
             font-size: 12px;
             font-style:oblique;
        }

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-5">

            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Id</label>
                <asp:TextBox ID="TextBoxId" CssClass="form-control" runat="server"></asp:TextBox>

            </div>

            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Codigo</label>
                <asp:TextBox ID="TextBoxCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ControlToValidate="TextBoxCodigo" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>

            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Nombre</label>
                <asp:TextBox ID="TextBoxNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxNombre" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Marca</label>
                <asp:DropDownList ID="DropDownListMarca" CssClass="form-select" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Categoria</label>
                <asp:DropDownList ID="DropDownListCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Precio</label>
                <asp:TextBox ID="TextBoxPrecio" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxPrecio" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator cssclass="validacion" ControlToValidate="TextBoxPrecio" runat="server" ValidationExpression="^[0-9]+$" ErrorMessage="Debe ingresar dato numérico"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="ButtonAceptar" OnClientClick="return validar()" OnClick="ButtonAceptar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                <a href="Lista.aspx" class="btn btn-info">Cancelar</a>
            </div>
        </div>
        <div class="col-5">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Descripción</label>
                <asp:TextBox ID="TextBoxDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxDescripcion" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            </div>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Url de imagen</label>
                        <asp:TextBox ID="TextBoxUrlImagen" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="TextBoxUrlImagen_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ID="ImageArticulo" OnError="this.onerror=null; this.src='https://www.casablancasrl.com.ar/images/fotos/640x480/foto-no-disponible.jpg'"
                        ImageUrl="https://www.casablancasrl.com.ar/images/fotos/640x480/foto-no-disponible.jpg"  CssClass="img-fluid mb-3" runat="server" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="Row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Button ID="ButtonEliminar" CssClass="btn btn-danger" runat="server" OnClick="ButtonEliminar_Click" Text="Eliminar" />
                    </div>
                    <%if (ConfirmaEliminacion == true)
                        {
                    %>
                    <div class="mb-3">
                        <asp:CheckBox ID="CheckBoxEliminar" Text="Confirma eliminar?" runat="server" />
                        <asp:Button ID="ButtonConfirmaEliminar" CssClass="btn btn-outline-danger" OnClick="ButtonConfirmaEliminar_Click" runat="server" Text="Eliminar" />
                    </div>

                    <%  } %>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>






























