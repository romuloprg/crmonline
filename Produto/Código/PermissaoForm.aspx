<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PermissaoForm.aspx.cs" Inherits="CRMOnline.PermissaoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Permissões
        <br />
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="login">
        <legend>Dados da Permissão</legend>
        <p>
            <asp:Label ID="lblCpf" runat="server" Text="CPF: "></asp:Label>
            <asp:TextBox ID="txtCpf" runat="server" style="margin-left: 74px" 
                Width="150px" MaxLength="11" Enabled="False"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" style="margin-left: 59px" 
                Width="350px" MaxLength="50" Enabled="False"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblPermissao" runat="server" Text="Permissão:"></asp:Label>
            <asp:DropDownList ID="txtPermissao" runat="server" style="margin-left: 35px" Width="150px">
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