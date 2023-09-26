<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebFinal.Registro" %>

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


    <div class="mb-4">
        <asp:Label CssClass="h4" ID="Label1" runat="server" Text="Crea tu perfil"></asp:Label>
    </div>
    <div class="mb-3 row">
        <div class="col-1">
            <label for="inputPassword"  class="form-label">Email</label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="TextBoxEmail" required  CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ControlToValidate="TextBoxEmail" runat="server" cssClass="validacion"
                ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" 
                ErrorMessage="Solo dirección de email"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="mb-3 row">
        <div class="col-1">
            <label for="inputPassword" class="form-label">Password</label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="TextBoxPass" TextMode="Password" required CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="ButtonRegistro" CssClass="btn btn-primary" style="margin-right:5px;" runat="server" OnClick="ButtonRegistro_Click" Text="Registrarse" />
    <a href="Default.aspx">Cancelar</a>


</asp:Content>
