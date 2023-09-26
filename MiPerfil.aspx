<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="WebFinal.MiPerfil" %>

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

    <h3>Mi Perfil</h3>
    
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Email</label>
                <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Nombre</label>
                <asp:TextBox ID="TextBoxNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxNombre" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Apellido</label>
                <asp:TextBox ID="TextBoxApellido" CssClass="form-control" runat="server"></asp:TextBox>               
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxApellido" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
               
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Imagen de perfil</label>
                <input type="file" id="TextBoxImagen" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Image ID="ImagePerfil" ImageUrl="https://img.icons8.com/stickers/100/name.png" CssClass="img-fluid mp-3" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <div class="mt-3">
         
                <asp:Button ID="ButtonGuardar" OnClick="ButtonGuardar_Click" style="margin-right:5px;" CssClass="btn btn-primary" runat="server" Text="Guardar" />        
                <a href="/">Volver</a>                
            </div>
        </div>
      </div>
</asp:Content>
