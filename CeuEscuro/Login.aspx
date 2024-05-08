<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CeuEscuro.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Authentication</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Authentication</h1>
            <ul>
                <li>
                    <asp:TextBox ID="txtNomeUsuario" placeholder="Nome" MaxLength="150" runat="server"></asp:TextBox>
                </li>

                <li>
                    <asp:TextBox ID="txtSenhaUsuario" placeholder="Senha" MaxLength="6" runat="server"></asp:TextBox>
                </li>

                <li>
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                </li>

                <li>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
