<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="CRMOnline.ClienteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Cliente
        <br />
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="login">
        <legend>Dados do Cliente</legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                    <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:"></asp:Label>
                    <asp:DropDownList ID="txtEmpresa" runat="server" Width="250px" style="margin-left: 80px" AutoPostBack="True" OnSelectedIndexChanged="txtEmpresa_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="lblCnpj" runat="server" Text="CNPJ:"></asp:Label>
                    <asp:TextBox ID="txtCnpj" runat="server" style="margin-left: 100px" 
                        Width="150px" MaxLength="18" Enabled="false"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblVendedor" runat="server" Text="Vendedor:"></asp:Label>
                    <asp:DropDownList ID="txtVendedor" runat="server" style="margin-left: 72px" Width="250px">
                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                        <asp:ListItem Value="0">Selecione uma empresa</asp:ListItem>
                    </asp:DropDownList>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClick="btnCancelar_Click"/>
    </p>
</asp:Content>
