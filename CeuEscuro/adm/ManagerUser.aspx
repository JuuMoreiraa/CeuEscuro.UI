<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManagerUser.aspx.cs" Inherits="CeuEscuro.adm.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Conteúdo a partir daqui--%>
    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>

    <%-- Formulario --%>
    <ul>
        <li>
            <asp:TextBox ID="txtIdUsuario" placeholder="Id" runat="server"></asp:TextBox>
        </li>

        <li>
            <asp:TextBox ID="txtNomeUsuario" MaxLength="150" placeholder="Nome" runat="server"></asp:TextBox>
            <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
        </li>

        <li>
            <asp:TextBox ID="txtEmailUsuario" MaxLength="150" placeholder="Email" runat="server"></asp:TextBox>
            <asp:Label ID="lblEmailUsuario" runat="server" Text=""></asp:Label>
        </li>

        <li>
            <asp:TextBox ID="txtSenhaUsuario" MaxLength="6" placeholder="Senha" runat="server"></asp:TextBox>
            <asp:Label ID="lblSenhaUsuario" runat="server" Text=""></asp:Label>
        </li>

        <li>
            <asp:TextBox ID="txtDtNascUsuario" placeholder="Data Nascimento" onKeyPress="$(this).mask('00/00/0000')" runat="server" ></asp:TextBox>
            <asp:Label ID="lblDtNascUsuario" runat="server" Text=""></asp:Label>
        </li>

        <li>
            <%-- AutoPostBack =  --%>
            <asp:DropDownList ID="ddl1" Width="160px" Height="27px" AutoPostBack="false" DataValueField="IdTipoUsuario" DataTextField="DescricaoTipoUsuario" runat="server"></asp:DropDownList>
        </li>

        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click"/>
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja realmente excluir este registro?'))return false" runat="server" Text="Delete" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" placeHolder="Buscar pelo name:" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"/>
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <%--gridView--%>
    <asp:GridView ID="gv1" OnSelectedIndexChanged="gv1_SelectedIndexChanged" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options"/>
            <asp:BoundField DataField="IdUsuario" HeaderText="Código" />
            <asp:BoundField DataField="NomeUsuario" HeaderText="Nome" />
            <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
            <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha" />
            <asp:BoundField DataField="DtNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />
        </Columns>
    </asp:GridView>

    <%--Conteúdo finaliza aqui--%>
</asp:Content>
<%--Se o conteúdo é colocado aqui, ele não é renderizado.--%>
