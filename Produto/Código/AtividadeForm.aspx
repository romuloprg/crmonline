<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AtividadeForm.aspx.cs" Inherits="CRMOnline.AtividadeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Atividades
        <br />
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="login">
        <legend>Dados da Atividade</legend>
        <p>
            <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
            <asp:TextBox ID="txtDescricao" runat="server" style="margin-left: 59px" 
                Width="350px" MaxLength="200"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server" style="margin-left: 90px" 
                Width="350px" MaxLength="50"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblData" runat="server" Text="Data:"></asp:Label>
            <asp:TextBox ID="txtData" runat="server" style="margin-left: 89px" 
                Width="150px" MaxLength="10" TextMode="Date"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblHora" runat="server" Text="Hora:"></asp:Label>
            <asp:TextBox ID="txtHora" runat="server" style="margin-left: 87px" 
                Width="150px" MaxLength="5" onkeyup="formataHora(this,event);"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblDuracao" runat="server" Text="Duração:"></asp:Label>
            <asp:TextBox ID="txtDuracao" runat="server" style="margin-left: 67px" 
            Width="150px" MaxLength="2" onkeyup="formataInteiro(this,event);"></asp:TextBox> hora(s)    
        </p>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClick="btnCancelar_Click"/>
    </p>
</asp:Content>