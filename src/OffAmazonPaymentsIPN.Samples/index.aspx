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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="index" %>
<%@ Import Namespace="OffAmazonPaymentsService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Samples Index Page</title>
</head>
<body>
    <h1>DotNet IPN Sample Code</h1>

    <br />

    <h2>Order Reference Samples</h2>

    <p>Click <a href="OrderReferencePayments/login.aspx" target="_blank">here</a> to create a new
    order reference before running one of the samples below</p>

    <ul>
        <li><a href="Samples/PaymentsNotificationSimpleCheckout.aspx" target="_blank">Simple Checkout</a></li>
        <li><a href="Samples/PaymentsNotificationMultipleShipment.aspx" target="_blank">Split Shipment</a></li>
        <li><a href="Samples/PaymentsNotificationRefund.aspx" target="_blank">Refund</a></li>
        <li><a href="Samples/PaymentsNotificationCancellation.aspx" target="_blank">Cancellation</a></li>
        <li><a href="Samples/AddressConsentSample.aspx" target="_blank">Address Consent</a></li>
    </ul>

    <br />

    <h2>Billing Agreement Samples</h2>
    <p>(Note: Billing Agreement Samples are only applicable in US and UK)</p>
    <p>Click <a href="AutomaticPayments/login.aspx" target="_blank">here</a> to create a new 
    billing agreement before running one of the samples below</p>

    <ul>
        <li><a href="Samples/PaymentsNotificationAutomaticPaymentsSimpleCheckout.aspx" target="_blank">Automatic payments simple checkout</a></li>
    </ul>


    <br />

    <h2>Provider Credit Samples</h2>
    <p>(Note: Provider Credit Samples are only applicable in US)</p>
    <p>Click <a href="OrderReferencePayments/login.aspx" target="_blank">here</a> to create a new
    order reference before running one of the samples below</p>

    <ul>
        <li><a href="Samples/PaymentsNotificationProviderCheckout.aspx" target="_blank">Provider Checkout</a></li>
        <li><a href="Samples/PaymentsNotificationProviderRefund.aspx" target="_blank">Provider Refund</a></li>
        <li><a href="Samples/PaymentsNotificationReverseProviderCredit.aspx" target="_blank">Reverse Provider Credit</a></li>
    </ul>


</body>
</html>
