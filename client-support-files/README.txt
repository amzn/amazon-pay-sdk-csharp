******************************************************************************
@@ProductName@@ ASP.net Library
Copyright 2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
Licensed under the Apache License, Version 2.0 (the "License");
******************************************************************************

******************************************************************************
INTRODUCTION
******************************************************************************

 Please understand that by using the @@ProductName@@ sample code, 
 you are agreeing to understand and abide by the terms of the license, 
 as written in NOTICE.txt & LICENSE.txt accompanying this archive. 
 This sample code has been tested with IIS 7.0 and .net 2.0

******************************************************************************
INCLUDED FILES
******************************************************************************

 * src              - C# files required to execute the code
 * bin              - The library files of OffAmazonPayments SDKs and
                      OffAmazonPayments Notification SDKs
 * lib              - The library file from Newtonsoft.Json
 * LICENSE.txt      - The Apache License this code is licensed under.
 * NOTICE.txt       - Notice file
 * README.txt       - Readme file
 * CHANGES.txt      - List of changes to the SDK.

******************************************************************************
PREREQUISITES 
******************************************************************************

In US, if you have registered with Amazon Payments API Integration prior to
October 7th, 2013, you will need to register with Login with Amazon (LWA) and
get a Login with Amazon (LWA) Client ID.  To register with LWA visit
https://login.amazon.com/ and click on "Sign Up" button.

In EU, if you register with Amazon Payments API Integration prior to
September 9th, 2014, you will need to register with Login with Amazon (LWA) and
get a Login with Amazon (LWA) Client ID. To register with LWA contact Amazon
Payments seller support through Seller Central and request an LwA registration.


Once registered for LWA to get your LWA Client ID, go to Seller Central, select
the “Login with Amazon” marketplace on the top right switcher, click on
"Register Your Application" button on LWA Seller Central page. For additional 
information, please see the following step by step guide to get your Login with 
Amazon Client ID: https://amazonpayments.s3.amazonaws.com/documents/Get_Your_
Login_with_Amazon_Client_ID.pdf

******************************************************************************
USAGE INSTRUCTIONS 
******************************************************************************
 Note: The following steps are for a Windows based operating environment

 This SDK includes two sets of samples - a command line based example that
  requires a minimal setup in order to run, and a webserver based sample that
  demonstrates notification processing.


 To run the command line based examples: 
    a) Configure the accessKeyId, secretAccessKey, and merchantId in the
       App.config file under src\OffAmazonPaymentsService.Sample directory.
       Please also set LWA clientId if Login with Amazon service is available
       in your region. Also make sure that the environment and region keys are
       configured to the right values for your test.
    b) Launch the solution file in the src folder.
    c) Choose the startup main function then run the project in Microsoft
       Visual Studio.
    d) Input the order reference id (or billing agreement id for billing
       agreement example) and order amount based on the prompts.
    e) Change the startup main function to run other use cases.

 To run the web based examples:
    a) Prior to running the webserver based examples, you will need to login
       to seller central using your account credentials and update your IPN
       endpoint. The merchant IPN endpoint will be http://<YOURHOSTNAME>
       (optional /<DIRECTORY>)/IpnHandler.aspx.
    b) You will also need to setup the javascript origin domain for Login with
       Amazon prior to using the payment widgets on your host.
    c) Install IIS web server on the Windows. If you install it after the .net
       framework is installed, refer to the instructions to register the IIS
       to the .net 2.0 framework.
       http://msdn.microsoft.com/en-us/library/k6h9cz8h%28v=vs.80%29.aspx
    d) Use Microsoft Visual Studio 2012 to open the solution file and compule
       the project. If you are using a other version Visual Studio, you can
       use the tool in the link to convert the solution into the version you
       are using. http://vsprojectconverter.codeplex.com/
    e) Include the dll files required in the upper level folder, make sure the
       solution is compiled successfully.
    f) Create a new website in IIS and point it to the physical path where the
       sample project locates. (NOTE: not the solution folder)
    g) Assign the "Everyone" permission to folder if necessary.
    h) For the sandbox use, both http and https connections are eligible. But
       the https connection requires a certificate signed by a recognized CA
       authority.
    i) Configure the accessKeyId, secretAccessKey, and merchantId in the
       Web.config file under src\OffAmazonPaymentsIPN.Samples directory.
       Please also set LWA clientId if Login with Amazon service is available
       in your region. Also make sure that the environment and region keys are
       configured to the right values for your test. Make sure certCN is 
       defined with value sns.amazonaws.com.
    j) Browse the website in the browser, create a new order reference id by
       logging in with a test buyer account. Run the different samples in the
       index.aspx page with the order reference id.
    k) If Automatic Payments service is available in your region, a billing
       agreement id is required for the example
       PaymentsNotificationAutomaticPaymentsSimpleCheckout.
       A billing agreement id can be generated by using the sample pages in
       src\OffAmazonPaymentsIPN.Samples\AutomaticPayments directory.

 Note: Note that production endpoints require a https connection where the
 merchant endpoint uses a certificate signed by a trusted ca authority as
 listed in the integration guide. We recommend that you test this in sandbox
 prior to a production release.

MWS AUTH TOKEN Usage
******************************************************************************
For clients who are acting as integrators or are authorized to make OffAmazonPaymentsService
calls on behalf of another seller, you are now required to provide a MWSAuthToken for
all requests made to the OffAmazonPaymentsService endpoint.
******************************************************************************

SUPPORT & PROJECT HOME
******************************************************************************
The latest documentation on the @@ProductName@@ can be found at the LINKS
section below.

******************************************************************************
LINKS
******************************************************************************

The @@ProductName@@ Documentation:
---------
US Amazon Seller Central: https://sellercentral.amazon.com
EU Amazon Seller Central: https://sellercentral-europe.amazon.com

1. Login to the site and navigate to the integration central tab to view
   available resources.
