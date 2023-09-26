<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFinal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-4">
        <asp:Label CssClass="h4" ID="Label1" runat="server" Text="Ingresar"></asp:Label>
    </div>
    <div class="mb-3 row">
        <div class="col-1">
            <label  class="form-label">Email</label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="TextBoxEmail"  TextMode="Email" CssClass="form-control" required runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="mb-3 row">
        <div class="col-1">
            <label  class="form-label">Password</label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="TextBoxPass" TextMode="Password" required CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="ButtonLogin" CssClass="btn btn-primary" style="margin-right:5px;" OnClick="ButtonLogin_Click" runat="server" Text="Aceptar" />
    <a href="Default.aspx">Cancelar</a>



</asp:Content>
