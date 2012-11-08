<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AtividadeForm.aspx.cs" Inherits="CRMOnline.AtividadeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Cadastro de Atividade
        <br />
    </h2>
    <fieldset class="login">
        <legend>Dados da Atividade</legend>
        <p>
            <asp:Label ID="lblCliente" runat="server" Text="Cliente:"></asp:Label>
            <asp:DropDownList ID="txtCliente" runat="server" style="margin-left: 50px" Width="355px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblDescricao" runat="server" Text="Descrição: "></asp:Label>
            <asp:TextBox ID="txtDescricao" runat="server" style="margin-left: 32px" 
                Width="349px" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server" style="margin-left: 63px" 
                Width="200px" MaxLength="100"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblData" runat="server" Text="Data:"></asp:Label>
            <asp:TextBox ID="txtData" runat="server" style="margin-left: 62px" 
                Width="100px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblHora" runat="server" Text="Hora:"></asp:Label>
            <asp:TextBox ID="txtHora" runat="server" style="margin-left: 60px" 
                Width="100px" MaxLength="5" onkeyup="formataHora(this,event);"></asp:TextBox>
        </p>
        <p>
            Participantes:
            <asp:CheckBoxList ID="lstParticipantes" runat="server" BorderStyle="Dashed" BorderWidth="2px" CellPadding="1" CellSpacing="1" RepeatColumns="2" RepeatDirection="Horizontal" Width="452px"></asp:CheckBoxList>
        </p>
    </fieldset>
    <p class="submitButton">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" Height="40px" Width="84px" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="40px" Width="84px" OnClick="btnCancelar_Click"/>
    </p>
</asp:Content>
