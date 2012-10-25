<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atividade.aspx.cs" Inherits="CRMOnline.Atividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>
        Listagem de Atividades
        <br />
    </h2>
    <h3>
        <asp:Button ID="btnNovo" runat="server" Text="NOVA ATIVIDADE" Height="40px" Width="120px" OnClick="btnNovo_Click"/>
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
            <asp:GridView ID="AtividadeGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="codAti" OnRowDeleting="AtividadeGridView_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="AtividadeGridView_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Cod." ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("codAti") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("desAti") %>    </ItemTemplate>
                        <ItemStyle Width="200px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("tipAti") %>    </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("datAti") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hora" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("horAti") %>    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duração" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("durAti") %>  hora(s)  </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
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