<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuncionarioForm.aspx.cs" Inherits="CRMOnline.FuncionarioForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Cargo
        <br />
    </h2>
    <fieldset class="login">
        <legend>Dados do Cargo</legend>
        <p>
            <asp:Label ID="lblCpf" runat="server" Text="CPF: "></asp:Label>
            <asp:TextBox ID="txtCpf" runat="server" style="margin-left: 74px" 
                Width="150px" MaxLength="14" Enabled="False"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" style="margin-left: 62px" 
                Width="350px" MaxLength="50" Enabled="False"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblCargo" runat="server" Text="Cargo:"></asp:Label>
            <asp:DropDownList ID="txtCargo" runat="server" style="margin-left: 62px" Width="157px">
                <asp:ListItem Value="1" Text="Funcionário"></asp:ListItem>
                <asp:ListItem Value="2" Text="Administrador"></asp:ListItem>
            </asp:DropDownList>
        </p>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClick="btnCancelar_Click"/>
    </p>
</asp:Content>
