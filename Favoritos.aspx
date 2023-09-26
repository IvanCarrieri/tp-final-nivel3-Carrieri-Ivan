<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="WebFinal.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Favoritos</h3>
    <div class="container mt-5">
   <div class="row">
     <asp:Repeater ID="RepeaterArticulos"  runat="server">
         <itemtemplate>
              <div class="col-md-3">
     <div class="card mb-3">                             
                     <img src="<%#Eval("ImagenUrl")%>" style="width: 17rem; height: 18rem; border-radius: 7px;" class="mx-2 my-2 " onerror="this.onerror=null; this.src='https://thumbs.dreamstime.com/b/ning%C3%BAn-icono-disponible-de-la-imagen-c%C3%A1mara-foto-plano-ejemplo-del-vector-132483296.jpg';">
                     <div class="card-body">
                         <div class="ml-auto">
                             <asp:CheckBox ID="CheckBoxFavoritos" Checked="true"  OnCheckedChanged="CheckBoxFavoritos_CheckedChanged" idArticulo='<%#Eval("Id")%>' AutoPostBack="true" CssClass="form-check-switch"  runat="server" />                        
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
 </div>

</asp:Content>
