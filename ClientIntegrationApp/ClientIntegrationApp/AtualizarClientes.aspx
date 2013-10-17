<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AtualizarClientes.aspx.cs" Inherits="ClientIntegrationApp.AtualizarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" 
        Text="Tabela com Clientes que possuem dados incompletos"></asp:Label>
    <asp:GridView ID="ClienteGridView" runat="server" AutoGenerateColumns="False"
    onrowcancelingedit="EmployeeGridView_RowCancelingEdit" 
    onrowediting="EmployeeGridView_RowEditing"             
    onrowdeleting="EmployeeGridView_RowDeleting" 
    onrowupdating="EmployeeGridView_RowUpdating" BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        CellSpacing="2" DataSourceID="ObjectDataSource2" AllowPaging="True">
       
        <Columns>
            
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome"/>
            
            <asp:BoundField DataField="TelefoneResidencial" HeaderText="TelefoneResidencial" SortExpression="TelefoneResidencial" ReadOnly="True" />
            <asp:BoundField DataField="Endereco" HeaderText="Endereco" SortExpression="Endereco" ReadOnly="True" />

            <asp:BoundField DataField="DataNascimento" HeaderText="DataNascimento" 
                SortExpression="DataNascimento" DataFormatString="{0: dd/MM/yyyy}" />
            <asp:BoundField DataField="NumeroCelular" HeaderText="NumeroCelular" SortExpression="NumeroCelular" />
            
            <asp:CommandField ShowEditButton="true" ButtonType ="Image" 
                              EditImageUrl="Imagem/edit.png" UpdateImageUrl="Imagem/ok.png" CancelImageUrl="Imagem/cancel.png" HeaderText="Editar"/>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="retornaClientes" 
        
        TypeName="ClientIntegrationApp.IntegrationServiceReference.IntegrationClient" 
        UpdateMethod="atualizarCliente">
        <UpdateParameters>
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="dataNascimento" Type="DateTime" />
            <asp:Parameter Name="numeroCelular" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
