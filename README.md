# Login and Pay with Amazon CSHARP SDK
Login and Pay with Amazon API Integration

## Requirements

* Login and Pay With Amazon account - [Register here](https://payments.amazon.com/signup)
* .NET 2.0 or higher
* Newtonsoft.json (JSON.NET)

## Documentation

* The Integration steps can be found [here](https://payments.amazon.com/documentation)

## Sample

* View the sample integration demo [here](https://amzn.github.io/login-and-pay-with-amazon-sdk-samples/)

## Quick Start

Instantiating the client:
Client takes in parameters in the following format

1. Configuration class object
2. Path to the JSON file containing configuration information.

## Installing using nuget
```
```

## Directory Structure
```
Folder PATH listing
|   PayWithAmazon.sln
|   PayWithAmazonDoc-CHM.shfbproj
|   README.md
|   
+---Helpdocs
|       Pay With Amazon Documentation.chm
|       
+---lib
|       config.json
|       Json.txt
|       Newtonsoft.Json.dll
|       nunit.framework.dll
|       PayWithAmazon.dll
|       TestResult.xml
|       UnitTests.dll             
+---PayWithAmazon
|   |   Client.cs - Main fine with the API calls
|   |   HttpImpl.cs - HTTP POST/GET requests 
|   |   IClient.cs - Interface class for Client class
|   |   IpnHandler.cs -  IPN handller and verifier class
|   |   JsonParser.cs - Recursive JSON parser for Client class
|   |   PayWithAmazon.csproj
|   |   region.Designer.cs
|   |   Regions.cs - Regions supported
|   |   ResponseParser.cs - API Respone format class
|   |         
|   +---CommonRequests
|   |       Configuration.cs - Client class configuration parameters request class
|   |       GetServiceStatusRequest.cs    
|   +---ProviderCreditRequests
|   |       GetProviderCreditDetailsRequest.cs
|   |       GetProviderCreditReversalDetailsRequest.cs
|   |       ReverseProviderCreditRequest.cs
|   |       
|   +---RecurringPaymentRequests
|   |       AuthorizeOnBillingAgreementRequest.cs
|   |       CloseBillingAgreementRequest.cs
|   |       ConfirmBillingAgreementRequest.cs
|   |       CreateOrderReferenceForIdRequest.cs
|   |       GetBillingAgreementDetailsRequest.cs
|   |       SetBillingAgreementDetailsRequest.cs
|   |       ValidateBillingAgreementRequest.cs
|   |       
|   \---StandardPaymentRequests
|           AuthorizeRequest.cs
|           CancelOrderReferenceRequest.cs
|           CaptureRequest.cs
|           ChargeRequest.cs
|           CloseAuthorizationRequest.cs
|           CloseOrderReferenceRequest.cs
|           ConfirmOrderReferenceRequest.cs
|           GetAuthorizationDetailsRequest.cs
|           GetCaptureDetailsRequest.cs
|           GetOrderReferenceDetailsRequest.cs
|           GetRefundDetailsRequest.cs
|           RefundRequest.cs
|           SetOrderReferenceDetailsRequest.cs
|           
+---snk
|       PayWithAmazonPublic.snk
|                  
\---UnitTests
    |   config.json
    |   Json.txt
    |   packages.config
    |   PayWithAmazonTest.cs
    |   UnitTests.csproj
```

##Parameters List

####Mandatory Parameters
| Parameter    | Values          								|
|--------------|------------------------------------------------|
| Merchant Id  | Default : `null`								|
| Access Key   | Default : `null`								|
| Secret Key   | Default : `null`								|
| Region       | Default : `null`<br>Other: `us`,`de`,`uk`,`jp`	|

####Optional Parameters
| Parameter           | Values                                      	   |
|---------------------|----------------------------------------------------|
| Currency Code       | Default : `null`<br>Other: `USD`,`EUR`,`GBP`,`JPY` |
| Environment         | Default : `false`<br>Other: `true`	    		   |
| Platform ID         | Default : `null` 			    				   |
| CA Bundle File      | Default : `null`			    				   |
| Application Name    | Default : `null`			    				   |
| Application Version | Default : `null`			    				   |
| Proxy Host          | Default : `null`			    				   |
| Proxy Port          | Default : `-1`  			    				   |
| Proxy Username      | Default : `null`			    				   |
| Proxy Password      | Default : `null`			    				   |
| LWA Client ID       | Default : `null`			    				   |
| Handle Throttle     | Default : `true`<br>Other: `false`	    		   |

## Setting Configuration

Setting configuration while instantiating the Client object
```csharp
using PayWithAmazon;
using PayWithAmazon.CommonRequests;

// Your Login and Pay with Amazon keys are available in your Seller Central account

// Configuration class object
Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	.WithRegion("REGION");

// Or you can also provide a JSON file path which has the above configuration information in JSON format
string config = "PATH_TO_JSON_FILE\filename.fileextension";

// Instantiate the client class with the config type
Client client = new Client(config);
```
### Testing in Sandbox Mode

The sandbox parameter is defaults to false if not specified:
```csharp
using PayWithAmazon;
using PayWithAmazon.CommonRequests;

Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	.WithRegion("REGION")
	.WithSandbox(true);

Client client = new Client(config);
```

### Making an API Call

Below is an example on how to make the GetOrderReferenceDetails API call:

```csharp
using PayWithAmazon;
using PayWithAmazon.CommonRequests;
using Newtonsoft.json;
using Log4Net; // if required for logging
using PayWithAmazon.StandardPaymentRequests;

// STEP 1 : Create the object of the GetOrderReferenceDetailsRequest class to add the parameters for the API call
GetOrderReferenceDetailsRequest requestParameters = new GetOrderReferenceDetailsRequest();

// AMAZON_ORDER_REFERENCE_ID is obtained from the Pay with Amazon Address/Wallet widgets
// ACCESS_TOKEN is obtained from the GET parameter from the URL.

// Required Parameter
requestParameters.WithAmazonOrderReferenceId("AMAZON_ORDER_REFERENCE_ID");

// Optional Parameters
requestParameters.WithAddressConsentToken("ACCESS_TOKEN");
requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");

// STEP 2 : Making the API call by passing in the GetOrderReferenceDetailsRequest object i.e requestParameters from step 1.
// response here is the object of the GetOrderReferenceDetailsResponse class
GetOrderReferenceDetailsResponse response = client.GetOrderReferenceDetails(requestParameters);

// Getting response variables
// Variable values can be obtained directly from the GetOrderReferenceDetailsResponse object received from making the API call in step 2

// Check if the API call was successful
bool isGetOrderReferenceDetailsSuccess = response.GetSuccess(); 
	if(isGetOrderReferenceDetailsSuccess)
	{
		string amazonOrderReferenceId = response.GetAmazonOrderReferenceId();
	}
	else
	{
		string errorCode = response.GetErrorCode();
		string ErrorMessage = response.GetErrorMessage();
	}

```
See the [GetOrderReferenceDetailsResponse](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp#api-response) section for all the parameters returned.

* Similarly other API calls can be made. See the [Request](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp#api-response) section for Request classes for the required API call.
* Pass the created Request object to the respective API function in the class [Client.cs](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp#api-response)
* The Response object returned will be specefic to the API call made. See [Response](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp#api-response) section for Response classes

### IPN Handling

1. To receive IPN's successfully you will need an valid SSL on your domain.
2. You can set up your Notification endpoints in Seller Central by accessing the Integration Settings page in the Settings tab.
3. IpnHandler.cs class handles verification of the source and the data of the IPN

In your web project you can create a file (for example ipn.aspx with a CodeBehind file ipn.aspx.cs).  Add the below code into that file and set the URL to the file (ipn.aspx) location in Merchant/Integrator URL by accessing Integration Settings page in the Settings tab.

```csharp
using PayWithAmazon;

// Get the IPN headers and Message body
Stream s = Request.InputStream;
StreamReader sr = new StreamReader(s);
string ipnMessage = sr.ReadToEnd();
NameValueCollection headers = Request.Headers;

// Create an object(ipn) of the IpnHandler class
IpnHandler ipnResponse = new IpnHandler(headers, ipnMessage);

```
See the [IPN Response](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp#ipn-response) section for information on parsing the IPN response.

### Convenience Methods

#####Charge Method

The charge method combines the following API calls:

**Standard Payments / Recurring Payments**

1. SetOrderReferenceDetails / SetBillingAgreementDetails
2. ConfirmOrderReference / ConfirmBillingAgreement
3. Authorize / AuthorizeOnBillingAgreement

For **Standard payments** the first `charge` call will make the SetOrderReferenceDetails, ConfirmOrderReference, Authorize API calls.
Subsequent call to `charge` method for the same Order Reference ID will make the call only to Authorize.

For **Recurring payments** the first `charge` call will make the SetBillingAgreementDetails, ConfirmBillingAgreement, AuthorizeOnBillingAgreement API calls.
Subsequent call to `charge` method for the same Billing Agreement ID will make the call only to AuthorizeOnBillingAgreement.

> **Capture Now** can be set to `true` for digital goods . For Physical goods it's highly recommended to set the Capture Now to `false`
and the amount captured by making the `capture` API call after the shipment is complete.


| Parameter                  | Mandatory | Values                                                                                              	     |
|----------------------------|-----------|-----------------------------------------------------------------------------------------------------------|
| Amazon Reference ID 	     | yes       | OrderReference ID (`starts with P01 or S01`) or <br>Billing Agreement ID (`starts with B01 or C01`)       |
| Merchant ID         	     | no        | Value taken from configuration in the Client class.                                                       |
| Charge Amount       	     | yes       | Amount that needs to be captured        																	 |
| Currency code       	     | no        | If no value is provided, value is taken from the configuration of the Client class  		             	 |
| Authorization Reference ID | yes       | Unique string to be passed									                                             |
| Transaction Timeout 	     | no        | Timeout for Authorization - Defaults to 1440 minutes						                                 |
| Capture Now	             | no        | Will capture the payment automatically when set to `true`. Defaults to `false`						     |
| Charge Note         	     | no        | Note that is sent to the buyer. <br>Maps to API call variables `seller_note` , `seller_authorization_note`|
| Charge Order ID     	     | no        | Custom order ID provided <br>Maps to API call variables `seller_order_id` , `seller_billing_agreement_id` |
| Store Name          	     | no        | Name of the store                                                                                         |
| Platform ID         	     | no        | Merchant ID of the Solution Provider                                                                      |
| Custom Information  	     | no        | Any custom string                                                                                         |
| Inherit Shipping Address   | no        | Specifies whether to inherit the shipping address details, Default: true                                  |
| Soft Descriptor  			 | no        | The description to be shown on the buyer's payment instrument statement, Default: AMZ*                    |
| Provider Credit Details  	 | no        | Marketplace information                                                                                   |
| MWS Auth Token      	     | no        | MWS Auth Token required if API call is made on behalf of the seller                                       |

```csharp
using PayWithAmazon;
using PayWithAmazon.CommonRequests;
using PayWithAmazon.StandardPaymentRequests;
using PayWithAmazon.RecurringPaymentRequests;

// ChargeRequest class object
ChargeRequest requestParameters = new ChargeRequest();

// Adding the parameters values to the ChargeRequest class
requestParameters.WithAmazonReferenceId("AMAZON_REFERENCE_ID")
	.WithChargeReferenceId("AUTHORIZATION_REFERENCE_ID")
	.WithAmount("100.50")
	.WithMerchantId("MERCHANT_ID")
	.WithCurrencyCode("USD")
	.WithPlatformId("SOLUTION_PROVIDER_MERCHANT_ID")
	.WithSoftDescriptor("amz")
	.WithStoreName("cool stuff store")
	.WithMWSAuthToken("MWS_AUTH_TOKEN")
	.WithChargeNote("sample note")
	.WithChargeOrderId("1234-1234")
	.WithCaptureNow(false)
	.WithProviderCreditDetails("PROVIDER_MERCHANT_ID", "10", "USD")
	.WithInheritShippingAddress(true)
	.WithTransactionTimeout(5)
	.WithCustomInformation("custom information");

// Get the Authorization response from the charge method
ResponseParser response = client.Charge(requestParameters);
```
#####Obtain profile information (GetUserInfo method)
1. obtains the user's profile information from Amazon using the access token returned by the Button widget.
2. An access token is granted by the authorization server when a user logs in to a site.
3. An access token is specific to a client, a user, and an access scope. A client must use an access token to retrieve customer profile data.

| Parameter           | Variable Name         | Mandatory | Values                                                                       	     		|
|---------------------|-----------------------|-----------|---------------------------------------------------------------------------------------------|
| Access Token        | `access_token`        | yes       | Retrieved as GET parameter from the URL                                      	     		|
| Region              | `region`              | yes       | Default :`null` <br>Other:`us`,`de`,`uk`,`jp`<br>Value is set in Client class Configuration |
| LWA Client ID       | `client_id`           | yes       | Default: null<br>Value should be set in the Client class Configuration                        	     	|

```csharp
using PayWithAmazon;
using PayWithAmazon.CommonRequests;

// Your Login and Pay with Amazon keys are available in your Seller Central account

// Configuration class object
Configuration config = new Configuration();
clientConfig.WithAccessToken("ACCESS_TOKEN")
	.WithClientId("YOUR_LWA_CLIENT_ID");

Client client = new Client(config);

// Get the Access Token from the URL
string access_token = "ACCESS_TOKEN";
// Calling the function getUserInfo with the access token parameter returns object
string jsonResponse = client.GetUserInfo(access_token);

//using Newtonsoft library
Jobject jsonObject = JObject.Parse(jsonResponse);

// Buyer name
string buyerName = jsonObject.GetValue("name").ToString();
// Buyer Email
string email = jsonObject.GetValue("email").ToString();
// Buyer User Id
string userId = jsonObject.GetValue("user_id").ToString();
```
### Response Parsing

Responses are provided in 3 formats

1. XML response
2. Dictionary
3. JSON format

#####API Response
```csharp
// Returns an object(response) of the class ResponseParser.cs
ResponseParser response = client.GetOrderReferenceDetails(requestParameters);

// XML response
response.ToXml();

// Dictionary response
response.ToDict();

// JSON response
response.ToJson();
```

#####IPN Response
```csharp
IpnHandler ipnResponse = new IpnHandler(headers,ipnMessage);

// XML message response
ipnResponse.ToXml();

// Dictionary response
ipnResponse.ToDict();

// JSON response
ipnResponse.ToJson();
```
