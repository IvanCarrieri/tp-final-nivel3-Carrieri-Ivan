<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebFinal.Contacto" %>

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
    <asp:Label CssClass="h4" ID="Label1" runat="server" Text="Formulario de contacto"></asp:Label>
</div>

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Email</label>
                <asp:TextBox ID="TextBoxEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxEmail" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Asunto</label>
                <asp:TextBox ID="TextBoxAsunto" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxAsunto" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Mensaje</label>
                <asp:TextBox ID="TextBoxMensaje" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator cssclass="validacion" ControlToValidate="TextBoxMensaje" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aceptar" CssClass="btn btn-primary" />

</asp:Content>
