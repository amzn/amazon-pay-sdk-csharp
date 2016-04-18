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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentsNotificationProviderCheckout.aspx.cs" Inherits="OffAmazonPaymentsNotifications.Samples.ProviderCheckout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Login and Pay with Amazon Provider Checkout Sample</h1>
        <table>
            <tr>
                <td>OrderReferenceId:</td>
                <td>
                    <asp:TextBox ID="tb_ORId" runat="server" Width="215px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_ORId" ErrorMessage="The order reference cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>OrderAmount:</td>
                <td>
                    <asp:TextBox ID="tb_OrderAmount" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_OrderAmount" ErrorMessage="The order amount cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_OrderAmount" ErrorMessage="The order amount is not in number format" ForeColor="Red" ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>AuthorizationType:</td>
                <td>
                    <asp:RadioButtonList ID="rb_AuthrorizationOption" runat="server">
                        <asp:ListItem Selected="True" Value="1">Regular (Asynchronous)</asp:ListItem>
                        <asp:ListItem Value="2">Fast (Synchronous)</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>ShippingOption:</td>
                <td>
                    <asp:RadioButton ID="rb_StandardShipping" runat="server" Text="Standard Shipping" GroupName="ShippingOption" Checked="true" /><br />
                    <asp:RadioButton ID="rb_TwoDayShipping" runat="server" Text="Two Day Shipping" GroupName="ShippingOption" /><br />
                    <asp:RadioButton ID="rb_NextDayShipping" runat="server" Text="Next Day Shipping" GroupName="ShippingOption" />
                </td>
            </tr>
            <tr>
                <td>Provider Id:</td>
                <td>
                    <asp:TextBox ID="tb_ProviderId" runat="server" Width="215px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_ProviderId" ErrorMessage="The  provider id cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator> 
                </td>
            </tr>
            <tr>
                <td>Credit Amount:</td>
                <td>
                    <asp:TextBox ID="tb_CreditAmount" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_CreditAmount" ErrorMessage="The credit amount cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_CreditAmount" ErrorMessage="The credit amount is not in number format or there are invalid characters." ForeColor="Red" ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <h2>Output:</h2>
        <asp:Label ID="lblShipping" runat="server" Text=""></asp:Label>
        <br />
        <asp:Literal ID="lblNotification" runat="server" Mode="PassThrough" Text=""></asp:Literal>
    </div>
    </form>
</body>
</html>
