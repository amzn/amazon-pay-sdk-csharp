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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressConsentSample.aspx.cs" Inherits="OffAmazonPaymentsNotifications.Samples.Samples.PayWithAmazonAddressConsentExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>@@ProductName@@  Address Consent Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>@@ProductName@@ Address Consent Example</h1>
        <br />
        <p>This example shows the difference in GetOrderRefenceDetails response when
        using the AddressConsent token field</p>

        <p>Enter an order refererence for a order that is in the draft status, along with the associated access token from the buyer session</p>
    </div>

    <div>
        OrderReferenceId: <asp:TextBox ID="tb_ORId" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv_ORId" runat="server"  ControlToValidate="tb_ORId" ErrorMessage="The order reference cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Access Token: <asp:TextBox ID="tb_AccessToken" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv_AccessToken" runat="server"  ControlToValidate="tb_AccessToken" ErrorMessage="The access token cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />
    </div>

    <div style="width: 100%">
        <div style="float:left; width:45%">
            <div style="font-weight:bold">GetOrderDetails result without address consent token</div>
            <asp:Literal ID="ltOrderDetailsNoConsent" runat="server" Mode="PassThrough" Text=""></asp:Literal>
        </div>
        <div style="float:right; width:45%; border-left:dashed; padding-left:1%">
            <div style="font-weight:bold">GetOrderDetails result with address consent token</div>
            <asp:Literal ID="ltOrderDetailsWithConsent" runat="server" Mode="PassThrough" Text=""></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
