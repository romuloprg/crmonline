<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="CRMOnline.ClienteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Clientes
        <br />
    </h2>
    <fieldset class="login">
        <legend>Dados do Cliente</legend>
        <p>
            <asp:Label ID="lblCod" runat="server" Text="Código:"></asp:Label>
            <asp:TextBox ID="txtCod" runat="server" style="margin-left: 52px" 
                Width="50px" TextMode="Number"></asp:TextBox>
            <asp:Label ID="lblAvisoCod" runat="server">(Digite somente números)</asp:Label>
        </p>
        <p>
            <asp:Label ID="lblRazao" runat="server" Text="Razão Social:"></asp:Label>
            <asp:TextBox ID="txtRazao" runat="server" style="margin-left: 21px" 
                Width="350px" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblNome" runat="server" Text="Nome Fantasia:"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" style="margin-left: 8px" 
                Width="350px" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:"></asp:Label>
            <asp:TextBox ID="txtEndereco" runat="server" style="margin-left: 40px" 
                Width="350px" MaxLength="100"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblUf" runat="server" Text="UF:"></asp:Label>
            <asp:DropDownList ID="txtUf" runat="server" style="margin-left: 80px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>AC</asp:ListItem>
                <asp:ListItem>AL</asp:ListItem>
                <asp:ListItem>AP</asp:ListItem>
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>BA</asp:ListItem>
                <asp:ListItem>CE</asp:ListItem>
                <asp:ListItem>DF</asp:ListItem>
                <asp:ListItem>ES</asp:ListItem>
                <asp:ListItem>GO</asp:ListItem>
                <asp:ListItem>MA</asp:ListItem>
                <asp:ListItem>MT</asp:ListItem>
                <asp:ListItem>MS</asp:ListItem>
                <asp:ListItem>MG</asp:ListItem>
                <asp:ListItem>PA</asp:ListItem>
                <asp:ListItem>PB</asp:ListItem>
                <asp:ListItem>PR</asp:ListItem>
                <asp:ListItem>PE</asp:ListItem>
                <asp:ListItem>PI</asp:ListItem>
                <asp:ListItem>RJ</asp:ListItem>
                <asp:ListItem>RN</asp:ListItem>
                <asp:ListItem>RS</asp:ListItem>
                <asp:ListItem>RO</asp:ListItem>
                <asp:ListItem>RR</asp:ListItem>
                <asp:ListItem>SC</asp:ListItem>
                <asp:ListItem>SP</asp:ListItem>
                <asp:ListItem>SE</asp:ListItem>
                <asp:ListItem>TO</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblCidade" runat="server" Text="Cidade:"></asp:Label>
            <asp:DropDownList ID="txtCidade" runat="server" style="margin-left: 54px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Belo Horizonte</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:"></asp:Label>
            <asp:DropDownList ID="txtEmpresa" runat="server" style="margin-left: 44px">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </p>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClientClick="window.open('Cliente.aspx');"/>
    </p>
</asp:Content>