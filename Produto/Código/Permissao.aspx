<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permissao.aspx.cs" Inherits="CRMOnline.Permissao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>
        Listagem de Funcionários
        <br />
    </h2>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="PermissaoGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="cpfUsu" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="PermissaoGridView_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="CPF" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("cpfUsu") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="600px">
                        <ItemTemplate>    <%#Eval("nomUsu") %>    </ItemTemplate>
                        <ItemStyle Width="600px"></ItemStyle>
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Permissão" ItemStyle-Width="150px">
                        <ItemTemplate>    <%#Eval("nomCar") %>    </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" HeaderText="Editar" ImageUrl="~/Imagem/editar.gif"  />
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