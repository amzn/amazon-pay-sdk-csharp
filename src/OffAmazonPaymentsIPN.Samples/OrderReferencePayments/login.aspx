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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <script type="text/javascript">
        window.onAmazonLoginReady = function () {
            amazon.Login.setClientId('<%= ClientId %>');
        };
  	</script>
    <script type="text/javascript" src="<%= JavascriptInclude %>"></script>
</head>
<body>
    <div id="AmazonPayButton"></div>
    <script type="text/javascript">
        OffAmazonPayments.Button("AmazonPayButton", "<%= MerchantId %>", {
            type: "Pay",
            authorization: function() {
                    path = location.pathname.replace(/[^\/]+.aspx/, "address.aspx");
                    amazon.Login.authorize({ scope: "profile payments:widget payments:shipping_address" },
                        "https://" + location.host + path);
            },
            onError: function (error) {
                alert(error.getErrorCode() + ": " + error.getErrorMessage());
            }
        });
    </script>
</body>
</html>
