<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFinal.Default" %>

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
        <div class="col">

            <blockquote class="blockquote my-3">
                <p>
                    Bienvenido a la tienda de Valen.
                </p>
            </blockquote>
            <blockquote class="blockquote my-3">
                <p>
                    Donde encontrarás todo tipo de articulos electrónicos y tecnología.
                </p>
            </blockquote>
        </div>
    </div>
    <br />


    <div class="mb-4">
      <div class="row ml-auto">
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
              <asp:TextBox ID="TextBoxPrecio"  CssClass="form-control" runat="server"></asp:TextBox>
              <%if (validarPrecio == true)
                  { %>
                     <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxPrecio" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator cssclass="validacion" ControlToValidate="TextBoxPrecio" runat="server" ValidationExpression="^[0-9]+$" ErrorMessage="Debe ingresar dato numérico"></asp:RegularExpressionValidator>
                <%} %>
          </div>
      </div>

      <div class="mb-3">
          <div>
              <asp:Button ID="ButtonBuscarFiltroAvanzado" OnClick="ButtonBuscarFiltroAvanzado_Click" CssClass="btn btn-info" runat="server" Text="Buscar" />
          </div>

      </div>
  </div>
        </div>


    <asp:ScriptManager runat="server" />
<asp:UpdatePanel runat="server">
    <ContentTemplate>

  
 <div class="container mt-5">
    <div class="row">
        <asp:Repeater ID="RepeaterArticulos"  runat="server">
            <itemtemplate>
                <div class="col-md-3">
                    <div class="card mb-3">
                        <img src="<%#Eval("ImagenUrl")%>" style="width: 17rem; height: 18rem; border-radius: 7px;" class="mx-2 my-2 img-fluid " onerror="this.onerror=null; this.src='https://thumbs.dreamstime.com/b/ning%C3%BAn-icono-disponible-de-la-imagen-c%C3%A1mara-foto-plano-ejemplo-del-vector-132483296.jpg';">
                        <div class="card-body">
                            <div class="ml-auto">
                                <asp:CheckBox ID="CheckBoxFavoritos" OnCheckedChanged="CheckBoxFavoritos_CheckedChanged1" idArticulo='<%#Eval("Id")%>' AutoPostBack="true" CssClass="form-check-switch"  runat="server" />                   
                                <label class="form-check-label" for="flexSwitchCheckDefault">Agregar a favoritos</label>
                            </div>
                            <p class="card-text"><%#Eval("Categoria")%></p>
                            <p class="card-text"><%#Eval("Marca")%></p>
                            <p class="card-title"><%#Eval("Nombre")%></p>
                            <p class="card-title"><%#((decimal)Eval("Precio")).ToString("N2")%></p>
                            <row class="mt-3" "ml-auto">
                                <div class="mt-3">   
                            <a href="Detalle.aspx?id=<%#Eval("Id")%>">Ver detalle</a>
                            <asp:Button ID="ButtonEjemplo" CssClass="btn btn-primary col-6" runat="server" Style="margin-left: 5px;" Text="Comprar" CommandArgument='<%#Eval("Id")%>' CommandName="articuloId" OnClick="ButtonEjemplo_Click" />                                                                 
                                    </div>
                            </row>
                        </div>
                        </div>
                    </div>
                
            </itemtemplate>
        </asp:Repeater>
    </div>

            </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>





