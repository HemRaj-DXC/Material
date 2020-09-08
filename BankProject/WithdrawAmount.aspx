<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WithdrawAmount.aspx.cs" Inherits="BankProject.WithdrawAmount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 47%;
            height: 206px;
            border-style: solid;
            border-width: 3px;
        }
        .auto-style2 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table align="center" cellpadding="4" cellspacing="5" class="auto-style1">
                <tr>
                    <td class="auto-style2">Account No</td>
                    <td>
                        <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Withdraw Amount</td>
                    <td>
                        <asp:TextBox ID="txtWithdraw" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnWithdraw" runat="server" Text="Withdraw Amount" Width="136px" OnClick="btnWithdraw_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
