<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="CRMOnline.Empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>
        Listagem de Empresas
        <br />
    </h2>
    <h3>
        <asp:Button ID="btnNovo" runat="server" Text="NOVA EMPRESA" Height="40px" Width="120px" OnClick="btnNovo_Click"/>
        <br />
        <br />
    </h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="EmpresaGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="cnpjEmp" OnRowDeleting="EmpresaGridView_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="EmpresaGridView_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="CNPJ" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("cnpjEmp") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Razão Social" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("razEmp") %>    </ItemTemplate>
                        <ItemStyle Width="200px"></ItemStyle>
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Nome Fantasia" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("nomEmp") %>    </ItemTemplate>
                        <ItemStyle Width="200px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Endereço" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("endEmp") %>    </ItemTemplate>
                        <ItemStyle Width="200px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UF" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("ufEmp") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cidade" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("cidEmp") %>    </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefone" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("telEmp") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" HeaderText="Editar" ImageUrl="~/Imagem/editar.gif"  />
                    <asp:CommandField ButtonType ="Image" HeaderText="Deletar" ItemStyle-Width="30px" DeleteImageUrl="Imagem/delete.gif" ShowDeleteButton="True">
                        <ItemStyle Width="30px"></ItemStyle>
                    </asp:CommandField>
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