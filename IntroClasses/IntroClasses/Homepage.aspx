<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="IntroClasses.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lbl_output" Text = " "></asp:Label>
        <asp:TextBox runat="server" ID="txt_input" Text = " "></asp:TextBox>
        <asp:Button runat="server" ID="btn_change" Text="Change name" OnClick="btn_change_Click" />
        <asp:Button runat="server" ID="btn_show" Text ="Show database" OnClick="btn_show_Click" />
        <asp:GridView runat="server" ID="gv1"></asp:GridView>
    </div>
    </form>
</body>
</html>
