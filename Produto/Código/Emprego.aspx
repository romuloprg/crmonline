<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Emprego.aspx.cs" Inherits="CRMOnline.Emprego" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>
        Listagem de Empregos
        <br />
    </h2>
    <h3>
        <asp:Button ID="btnEditar" runat="server" Text="EDITAR CONTRATO" Height="40px" Width="135px" OnClick="btnEditar_Click"/>
        <br /><br />
    </h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="EmpregoGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="cpfUsu" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" ItemStyle-Width="100px">
                        <ItemTemplate>    <%#Eval("codCtr") %>    </ItemTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Empresa" ItemStyle-Width="350px">
                        <ItemTemplate>    <%#Eval("nomEmp") %>    </ItemTemplate>
                        <ItemStyle Width="350px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cargo" ItemStyle-Width="350px">
                        <ItemTemplate>    <%#Eval("nomCar") %>    </ItemTemplate>
                        <ItemStyle Width="350px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Início" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("iniCtr") %>    </ItemTemplate>
                        <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fim" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>    <%#Eval("fimCtr") %>    </ItemTemplate>
                        <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>