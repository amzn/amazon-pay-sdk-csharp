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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentsNotificationMultipleShipment_2.aspx.cs" Inherits="OffAmazonPaymentsNotifications.Samples.Samples.PaymentsNotificationMultipleShipment_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Item to choose for each round shipment: 
        <asp:DropDownList ID="ddl_item1" runat="server">
            <asp:ListItem Value="0">Apple</asp:ListItem>
            <asp:ListItem Value="1">Pineapple</asp:ListItem>
            <asp:ListItem Value="2">Banana</asp:ListItem>
            <asp:ListItem Value="3">Orange</asp:ListItem>
            <asp:ListItem Value="4">Pear</asp:ListItem>
        </asp:DropDownList>
            , # 
        <asp:DropDownList ID="ddl_item1Number" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>

            <br />
            <br />
            <asp:Panel ID="panel_2" runat="server">
                Item to choose for each round shipment: 
        <asp:DropDownList ID="ddl_item2" runat="server">
            <asp:ListItem Value="0">Apple</asp:ListItem>
            <asp:ListItem Value="1">Pineapple</asp:ListItem>
            <asp:ListItem Value="2">Banana</asp:ListItem>
            <asp:ListItem Value="3">Orange</asp:ListItem>
            <asp:ListItem Value="4">Pear</asp:ListItem>
        </asp:DropDownList>
                , # 
        <asp:DropDownList ID="ddl_item2Number" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
            </asp:Panel>
            <br />

            <asp:Panel ID="panel_3" runat="server">
                Item to choose for each round shipment: 
        <asp:DropDownList ID="ddl_item3" runat="server">
            <asp:ListItem Value="0">Apple</asp:ListItem>
            <asp:ListItem Value="1">Pineapple</asp:ListItem>
            <asp:ListItem Value="2">Banana</asp:ListItem>
            <asp:ListItem Value="3">Orange</asp:ListItem>
            <asp:ListItem Value="4">Pear</asp:ListItem>
        </asp:DropDownList>
                , # 
        <asp:DropDownList ID="ddl_item3Number" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
            </asp:Panel>
            <br />
            <br />
            <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />
        </div>
        <div>
            <h2>Output:</h2>
            <asp:Label ID="lblShipping" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblNotification" runat="server" Text=""></asp:Label>
        </div>

    </form>
</body>
</html>
