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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentsNotificationMultipleShipment.aspx.cs" Inherits="OffAmazonPaymentsNotifications.Samples.PaymentsNotificationMultipleShipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Login and Pay with Amazon Multiple Shipment Sample</h1>

        <h3>This demonstrates a merchant use case where the order needs to be furfilled in multiple shipments, or where a single item is shipped 
        in multiple shipments over time.</h3>
        Number of items to choose, up to 3: 
        <asp:DropDownList ID="ddl_itemNumber" runat="server">
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
        </asp:DropDownList>
        <br />
        OrderReferenceId:
        <asp:TextBox ID="tb_ORId" runat="server" Width="215px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_ORId" ErrorMessage="The order reference cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />

        <br />
        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
        <br />
    </div>

    </form>
</body>
</html>
