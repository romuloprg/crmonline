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
        <asp:Button ID="btnNovo" runat="server" Text="NOVA ATIVIDADE" Height="40px" Width="130px" OnClick="btnNovo_Click"/>
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
                DataKeyNames="codAti" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="AtividadeGridView_RowDataBound" OnRowDeleting="AtividadeGridView_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("codAti") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente" ItemStyle-Width="200px">
                        <ItemTemplate>    <%#Eval("nomCli") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição" ItemStyle-Width="350px">
                        <ItemTemplate>    <%#Eval("desAti") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo" ItemStyle-Width="100px">
                        <ItemTemplate>    <%#Eval("tipAti") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("datAti") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horário" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("horAti") %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lembr." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="Lembrete.aspx?codAti=<%#Eval("codAti") %>"> <img alt="Lembr." src="Imagem/clock.gif" /> </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="AtividadeForm.aspx?codAti=<%#Eval("codAti") %>"> <img alt="Editar" src="Imagem/editar.gif" /> </a>
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
