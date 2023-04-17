<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QCCode.aspx.cs" Inherits="QrCodeGeneratorand_Reader.QCCode"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<meta http-equiv="refresh" content="5"  />--%>
</head>
<body>
    <form id="QCFrom" runat="server">
        <div>
        <asp:TextBox ID="txtQCCode" runat="server">
        </asp:TextBox>
        <asp:Button ID="btnQCGenerate" runat="server"
            Text="Create My QR Code"
            OnClick="btnQCGenerate_Click" />
        <hr/>
        <asp:Image ID="imgageQRCode" Width="50%"
            Height="50%" runat="server"
            Visible="false" /> <br /><br />
        <asp:Button ID="btnQCRead" Text="Read My QR Code"
            runat="server" OnClick="btnQCRead_Click" />
        <asp:Label ID="lblQRCode" runat="server">
        </asp:Label>
            <asp:Button ID="Button1" Text="Create hash"
            runat="server"  OnClick="hashing" />
            <asp:Timer ID="Timer1" runat="server" Interval="4000" ontick="Timer1_Tick">
            </asp:Timer>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
