<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="CRMOnline.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>
        Listagem de Clientes
        <br />
    </h2>
    <h3>
        <a id="link" href="~/ClienteForm.aspx" runat="server" enableviewstate="false">NOVO CLIENTE</a>
        <br /><br />
    </h3>
    <asp:GridView ID="ClienteGridView" runat="server" AutoGenerateColumns="False"
        DataKeyNames="codCli" OnRowCancelingEdit="ClienteGridView_RowCancelingEdit" OnRowEditing="ClienteGridView_RowEditing" OnRowDeleting="ClienteGridView_RowDeleting" OnRowUpdating="ClienteGridView_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="ClienteGridView_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Cod." ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>    <%#Eval("codCli") %>    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nome" ItemStyle-Width="200px">
                <ItemTemplate>    <%#Eval("nomCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNome" runat="server" Text='<%#Eval("nomCli") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>    
            <asp:TemplateField HeaderText="Endereço" ItemStyle-Width="200px">
                <ItemTemplate>    <%#Eval("endCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEndereco" runat="server" Text='<%#Eval("endCli") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UF" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>    <%#Eval("ufCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="txtUf" runat="server" Text='<%#Eval("ufCli") %>'>
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>AC</asp:ListItem>
                        <asp:ListItem>AL</asp:ListItem>
                        <asp:ListItem>AP</asp:ListItem>
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>BA</asp:ListItem>
                        <asp:ListItem>CE</asp:ListItem>
                        <asp:ListItem>DF</asp:ListItem>
                        <asp:ListItem>ES</asp:ListItem>
                        <asp:ListItem>GO</asp:ListItem>
                        <asp:ListItem>MA</asp:ListItem>
                        <asp:ListItem>MT</asp:ListItem>
                        <asp:ListItem>MS</asp:ListItem>
                        <asp:ListItem>MG</asp:ListItem>
                        <asp:ListItem>PA</asp:ListItem>
                        <asp:ListItem>PB</asp:ListItem>
                        <asp:ListItem>PR</asp:ListItem>
                        <asp:ListItem>PE</asp:ListItem>
                        <asp:ListItem>PI</asp:ListItem>
                        <asp:ListItem>RJ</asp:ListItem>
                        <asp:ListItem>RN</asp:ListItem>
                        <asp:ListItem>RS</asp:ListItem>
                        <asp:ListItem>RO</asp:ListItem>
                        <asp:ListItem>RR</asp:ListItem>
                        <asp:ListItem>SC</asp:ListItem>
                        <asp:ListItem>SP</asp:ListItem>
                        <asp:ListItem>SE</asp:ListItem>
                        <asp:ListItem>TO</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cidade" ItemStyle-Width="150px">
                <ItemTemplate>    <%#Eval("cidCli") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="txtCidade" runat="server" Text='<%#Eval("cidCli") %>'>
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Belo Horizonte</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empresa" ItemStyle-Width="200px">
                <ItemTemplate>    <%#Eval("nomEmp") %>    </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="txtEmpresa" runat="server" DataValueField='<%#Eval("nomEmp") %>'></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" ButtonType ="Image" 
                EditImageUrl="Imagem/editar.gif" 
                UpdateImageUrl="Imagem/confirmar.png"
                CancelImageUrl="Imagem/cancelar.png" HeaderText="Editar" ItemStyle-Width="30px"/>
            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="Imagem/delete.gif" HeaderText="Deletar" ItemStyle-Width="30px"/>
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