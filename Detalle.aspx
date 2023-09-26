<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebFinal.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    

    <div class="container mt-5">
        <div class="row">
            <div class="col-md-5">
                <asp:Image ID="ImageDetalle" OnError="this.onerror=null; this.src='https://www.casablancasrl.com.ar/images/fotos/640x480/foto-no-disponible.jpg'"
                        ImageUrl="https://www.casablancasrl.com.ar/images/fotos/640x480/foto-no-disponible.jpg"  runat="server" CssClass="img-fluid" />
            </div>
            <div class="col-md-5 offset-md-2 mb-4">
                <div class="mb-3">
                    <asp:Label ID="LabelCategoria" CssClass="h4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-4">
                    <asp:Label ID="LabelMarca" CssClass="h4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-4">
                    <asp:Label ID="LabelNombre" CssClass="h1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-4">
                    <asp:Label ID="LabelDascripcion" CssClass="p" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-4">
                    <asp:Label ID="LabelP" CssClass="h4" runat ="server" Text="Precio:"></asp:Label>
                    <asp:Label ID="LabelPrecio" CssClass="h4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-4">
                    <asp:Button ID="ButtonComprar" CssClass="btn btn-primary col-4" runat="server" Text="Comprar ahora" />
                </div>
            </div>
        </div>


    </div>


</asp:Content>
