<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRMOnline.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Bem Vindo ao CRM Online!
    </h2>
    <p>
        Para acessar o sistema entre com os dados de usuário.
        Se você não possui uma conta clique <a id="A1" href="LoginForm.aspx" runat="server" enableviewstate="false">aqui</a>.
    </p>
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Dados de Usuário</legend>
            <p>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuário:"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" style="margin-left: 8px" 
                    Width="245px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" 
                    style="margin-left: 18px" Width="245px"></asp:TextBox>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnOk" runat="server" Text="OK" Height="24px" 
                style="margin-left: 0px; margin-top: 0px" Width="101px" 
                onclick="btnOk_Click" />
        </p>
    </div>
</asp:Content>
