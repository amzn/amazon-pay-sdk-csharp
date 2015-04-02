<!-- /*******************************************************************************
 *  Copyright 2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License");	
 *
 *  You may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at:
 *  http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License
 *  for the
 *  specific language governing permissions and limitations under the
 *  License.
 * *****************************************************************************	
 */
 -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentsNotificationReverseProviderCredit.aspx.cs" Inherits="OffAmazonPaymentsNotifications.Samples.PaymentsNotificationReverseProviderCredit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr><td><h1>Login and Pay with Amazon Reverse Provider Credit Sample</h1></td></tr>
            <tr><td><h3>This page demonstrates the scenario where solution provider needs to perform a reverse provider credit on a previously captured amount where provider credit was taken for a closed order reference.</h3></td></tr>
            <tr><td>Amazon Provider Credit Id:</td><td><asp:TextBox ID="tb_ProiverCreditId" runat="server" Width="215px"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_ProiverCreditId" ErrorMessage="The amazon provider credit id cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
            <tr><td>Credit Reversal Amount:</td><td><asp:TextBox ID="tb_CreditReversalAmt" runat="server" Width="215px"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_CreditReversalAmt" ErrorMessage="The credit reversal amount cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_CreditReversalAmt" ErrorMessage="The order amount is not in number format" ForeColor="Red" ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator></td></tr>
            <tr><td><asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /></td></tr>
        </table>
    </div>
    <div>
        <h2>Output:</h2>
        <br />
        <asp:Label ID="lblNotification" runat="server" Text=""></asp:Label>
    </div>

    </form>
</body>
</html>
