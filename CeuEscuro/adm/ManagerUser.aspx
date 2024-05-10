<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManagerUser.aspx.cs" Inherits="CeuEscuro.adm.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Conteúdo a partir daqui--%>
    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>

    <%-- Formulario --%>
    <ul>
        <li>

        </li>

        <li></li>

        <li></li>

        <li></li>

        <li></li>

        <li></li>

        <li></li>

        <li></li>

    </ul>

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <%-- GridView --%>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="IdUsuario" HeaderText="Código"/>
            <asp:BoundField DataField="NomeUsuario" HeaderText="Nome"/>
            <asp:BoundField DataField="EmailUsuario" HeaderText="Email"/>
            <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha"/>
            <asp:BoundField DataField="DtNascUsuario" HeaderText="Data"/>
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão"/>
        </Columns>
    </asp:GridView>

    <%--Conteúdo finaliza aqui--%>
</asp:Content>
<%--Se o conteúdo é colocado aqui, ele não é renderizado.--%>
