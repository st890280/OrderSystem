<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OrderSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .login{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <div>
                請輸入帳號 : <asp:TextBox runat="server" class="input100" type="text" name="帳號" ID="txtAccount" />
            </div>
            <div>
                請輸入密碼 : <asp:TextBox ID="txtPassword" runat="server" class="input100" type="password" name="密碼"></asp:TextBox>
            </div>
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <asp:Label ID="lbMessage" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            </asp:PlaceHolder>
            <div>
                <button runat="server" class="loginbtn" onserverclick="Button1_Click" id="Login1" type="submit" name="btn1">登入</button>
            </div>
        </div>

    </form>
</body>
</html>
