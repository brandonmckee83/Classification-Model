<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ClassificationModel.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="title" runat="server">Simplified Classification Model</asp:Label>
        <asp:Table ID="tblData" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblContent" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
