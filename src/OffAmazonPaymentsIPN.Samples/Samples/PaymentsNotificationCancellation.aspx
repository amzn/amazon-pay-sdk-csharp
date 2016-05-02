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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentsNotificationCancellation.aspx.cs" Inherits="OffAmazonPaymentsNotifications.Samples.PaymentsNotificationCancellation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>@@ProductName@@ Cancellation Sample</h1>  
        <h4>This page demonstrates a merchant use case where the order needs to be cancelled before the first Capture has been performed</h4>
        <h4>This is done using the CancelOrderReference call to cancel to order, and this should be called prior to the first Capture. </h4>
        <br />
        OrderReferenceId:
        <asp:TextBox ID="tb_ORId" runat="server" Width="215px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_ORId" ErrorMessage="The order reference cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        OrderAmount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_OrderAmount" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_OrderAmount" ErrorMessage="The order amount cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_OrderAmount" ErrorMessage="The order amount is not in number format" ForeColor="Red" ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />

    </div>
    <div>
        <h2>Output:</h2>
        <asp:Label ID="lblNotification" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
