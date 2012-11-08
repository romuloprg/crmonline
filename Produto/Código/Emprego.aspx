<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Emprego.aspx.cs" Inherits="CRMOnline.Emprego" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Listagem de Empregos
        <br />
    </h2>
    <asp:Panel ID="panelButton" runat="server">
        <h3>
            <asp:Button ID="btnEditar" runat="server" Text="EDITAR CONTRATO" Height="40px" Width="135px" OnClick="btnEditar_Click"/>
            <br />
        </h3>
    </asp:Panel>
    <br />
    <asp:GridView ID="EmpregoGridView" runat="server" AutoGenerateColumns="False"
        DataKeyNames="cpfUsu" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Código" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>    <%#Eval("codCtr") %>    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empresa" ItemStyle-Width="350px">
                <ItemTemplate>    <%#Eval("nomEmp") %>    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cargo" ItemStyle-Width="350px">
                <ItemTemplate>    <%#Eval("nomCar") %>    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Início" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>    <%#Eval("iniCtr") %>    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fim" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>    <%#Eval("fimCtr") %>    </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
