<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="UsuarioIndex.aspx.cs" Inherits="CRMOnline.UsuarioIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Usuarios
        <br />
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="login">
        <legend>Dados do Usuario</legend>
        <p>
            <asp:Label ID="lblCpf" runat="server" Text="CPF: "></asp:Label>
            <asp:TextBox ID="txtCpf" runat="server" style="margin-left: 74px" 
                Width="150px" MaxLength="14" onkeyup="formataCPF(this,event);"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" style="margin-left: 59px" 
                Width="350px" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:"></asp:Label>
            <asp:TextBox ID="txtEndereco" runat="server" style="margin-left: 40px" 
                Width="350px" MaxLength="100"></asp:TextBox>
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                    <asp:Label ID="lblUf" runat="server" Text="UF:"></asp:Label>
                    <asp:DropDownList ID="txtUf" runat="server" style="margin-left: 80px" AutoPostBack="True" OnSelectedIndexChanged="txtUf_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="lblCidade" runat="server" Text="Cidade:"></asp:Label>
                    <asp:DropDownList ID="txtCidade" runat="server" style="margin-left: 54px" Width="180px">
                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                        <asp:ListItem Value="0">Selecione um estado</asp:ListItem>
                    </asp:DropDownList>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
            <asp:DropDownList ID="txtSexo" runat="server" style="margin-left: 67px" Width="100px">
                <asp:ListItem Value="0" Text=""></asp:ListItem>
                <asp:ListItem Value="M" Text="Masculino"></asp:ListItem>
                <asp:ListItem Value="F" Text="Feminino"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label>
            <asp:TextBox ID="txtTelefone" runat="server" style="margin-left: 45px" 
                Width="200px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" style="margin-left: 64px" 
                Width="350px" MaxLength="50" TextMode="Email"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblGraduacao" runat="server" Text="Graduacao:"></asp:Label>
            <asp:DropDownList ID="txtGraduacao" runat="server" style="margin-left: 31px" Width="180px">
                <asp:ListItem Value="0" Text=""></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server" style="margin-left: 60px" 
                Width="350px" MaxLength="10" TextMode="Password"></asp:TextBox>
        </p>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClick="btnCancelar_Click"/>
    </p>
</asp:Content>