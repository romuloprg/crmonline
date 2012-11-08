<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="CRMOnline.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>
        Listagem de Clientes
        <br />
    </h2>
    <h3>
        <asp:Button ID="btnNovo" runat="server" Text="NOVO CLIENTE" Height="40px" Width="110px" OnClick="btnNovo_Click"/>
        <br />
    </h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset class="login">
                <legend>Digite uma palavra para filtrar</legend>
                <p>
                    <asp:Label ID="lblBusca" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtBusca" runat="server" Width="860px" MaxLength="50" OnTextChanged="txtBusca_TextChanged" AutoPostBack="true"></asp:TextBox>
                </p>
            </fieldset>
            <asp:GridView ID="ClienteGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="codCli" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="ClienteGridView_RowDataBound" OnRowDeleting="ClienteGridView_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("codCli") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CNPJ" ItemStyle-Width="200px">
                        <ItemTemplate>    <%#Eval("cnpjCli") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="350px">
                        <ItemTemplate>    <%#Eval("nomCli") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vendedor" ItemStyle-Width="250px">
                        <ItemTemplate>    <%#Eval("nomVen") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="ClienteForm.aspx?codCli=<%#Eval("codCli") %>"> <img alt="Editar" src="Imagem/editar.gif" /> </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagem/delete.gif" HeaderText="Excluir" ShowDeleteButton="True" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
