<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="CRMOnline.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:GridView ID="ClienteGridView" runat="server" AutoGenerateColumns="False"
        DataKeyNames="codCli" OnRowCancelingEdit="ClienteGridView_RowCancelingEdit" OnRowEditing="ClienteGridView_RowEditing" OnRowDeleting="ClienteGridView_RowDeleting" OnRowUpdating="ClienteGridView_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="ClienteGridView_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Cod.">
                <ItemTemplate>    <%#Eval("codCli") %>    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>    <%#Eval("nomCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNome" runat="server" Text='<%#Eval("nomCli") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>    
            <asp:TemplateField HeaderText="Endereço">
                <ItemTemplate>    <%#Eval("endCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEndereco" runat="server" Text='<%#Eval("endCli") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cidade">
                <ItemTemplate>    <%#Eval("cidCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCidade" runat="server" Text='<%#Eval("cidCli") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UF">
                <ItemTemplate>    <%#Eval("ufCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUf" runat="server" Text='<%#Eval("ufCli") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" ButtonType ="Image" 
                EditImageUrl="Imagem/editar.gif" 
                UpdateImageUrl="Imagem/confirmar.png"
                CancelImageUrl="Imagem/cancelar.png" HeaderText="Editar" />
            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="Imagem/delete.gif" HeaderText="Deletar" />  
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

