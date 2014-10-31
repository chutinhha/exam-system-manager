<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExamSystemManager.Admin.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
	body{background:url(IMG/bg.png); margin:0px;}
    .login{width:400px; margin:200px auto; border:1px #FFFFFF solid; border-radius:10px; box-shadow:#000 5px 5px 5px; background:#FFF;}
	.head{height:50px; font-size:35px; border-bottom:1px #000000 solid; font-weight:bold;}
	table{height:200px; font-size:20px;}
	.style1{width:210px; text-align:right;}
	.style1 input{width:200px; height:20px; font-size:16px;}
	.msg{color:#F00;}
	.style3{text-align:center;}
	input{width:100px; height:30px;}
        .auto-style1 {
            text-align: right;
            width: 114px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login">
    
        <table style="width:100%;">
        <tr>
                <td colspan="3" class="head">
                	Đăng nhập
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Sai tên đăng nhập hoặc mật khẩu" 
                        Visible="False" CssClass="msg"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUserName" ErrorMessage="You must enter Username" 
                        Text="*"></asp:RequiredFieldValidator>
&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Mật khẩu"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="You must enter Password" 
                        Text="*"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="style3" colspan="3">
                    <asp:Button ID="btnlogin" runat="server" Text="Đăng nhập" 
                        onclick="btnlogin_Click" />
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>