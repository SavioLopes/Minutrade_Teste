<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ClientIntegrationApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Sistema de Integração
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Testar" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </h2>
</asp:Content>
