﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="CRMOnline.ClienteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Clientes
        <br />
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="login">
        <legend>Dados do Cliente</legend>
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
            <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:"></asp:Label>
            <asp:DropDownList ID="txtEmpresa" runat="server" style="margin-left: 44px" Width="180px">
                <asp:ListItem Value="0" Text=""></asp:ListItem>
            </asp:DropDownList>
        </p>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClick="btnCancelar_Click"/>
    </p>
</asp:Content>