# Amazon Pay SDK (C#)
Amazon Pay API Integration

## Requirements

* Amazon Pay account - [Register here](https://pay.amazon.com/signup)
* .NET 2.0 or higher
* Newtonsoft.json (JSON.NET)

## Documentation

* The Integration steps can be found [here](https://pay.amazon.com/documentation)

## Sample

* View the sample integration demo [here](https://amzn.github.io/amazon-pay-sdk-samples/)

## Quick Start

Instantiating the client:
Client takes in parameters in the following format

1. Configuration class object
2. Path to the JSON file containing configuration information.

## Installing using nuget
```code
Install-Package AmazonPay

```

## Directory Structure
```
Folder PATH listing       
+---lib
|       Common.Logging.dll
|       config.json
|       Json.txt
|       Newtonsoft.Json.dll
|       nunit.framework.dll
|       AmazonPay.dll
|       TestResult.xml
|       UnitTests.dll
|                     
+---AmazonPay
|   |   Client.cs
|   |   Constants.cs
|   |   HttpImpl.cs
|   |   IpnHandler.cs
|   |   NestedJsonToDictionary.cs
|   |   AmazonPay.csproj
|   |   region.Designer.cs
|   |   Regions.cs
|   |   ResponseParser.cs
|   |   packages.config
|   |   Signature.cs
|   |   SanitizeData.cs     
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
|   +---Responses
|   |       AuthorizeResponse.cs
|   |       BillingAddressDetails.cs
|   |       BillingAgreementDetailsResponse.cs
|   |       CancelOrderReferenceResponse.cs
|   |       CaptureResponse.cs
|   |       CloseAuthorizationResponse.cs
|   |       CloseBillingAgreementResponse.cs
|   |       CloseOrderReferenceResponse.cs
|   |       ConfirmBillingAgreementResponse.cs
|   |       ConfirmOrderReferenceResponse.cs
|   |       ErrorResponse.cs
|   |       GetProviderCreditDetailsResponse.cs
|   |       GetProviderCreditReversalDetailsResponse.cs
|   |       GetServiceStatusResponse.cs
|   |       OrderReferenceDetailsResponse.cs
|   |       PaymentDetailsResponse.cs
|   |       RefundResponse.cs
|   |       ValidateBillingAgreementResponse.cs
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
|                 
\---UnitTests
    |   App.config
    |   AuthorizeNotification.json
    |   config.json
    |   Json.txt
    |   packages.config
    |   AmazonPayUnitTests.cs
    |   UnitTests.csproj
```

## Parameters List


#### Mandatory Parameters
| Parameter    | Json file Key name | Values          								|
|--------------|--------------------|-----------------------------------------------|
| Merchant Id  | `merchant_id` 		| Default : `null`								|
| Access Key   | `access_key`  		| Default : `null`								|
| Secret Key   | `secret_key`  		| Default : `null`								|
| Region       | `region`      		| Default : `null`<br>Other: `us`,`de`,`uk`,`jp`|

#### Optional Parameters
| Parameter           		| Json file Key name         	| Values                                      	   	|
|---------------------------|-------------------------------|---------------------------------------------------|
| Currency Code       		| `currency_code`       	   	| Default : `null`<br>Other: `USD`,`EUR`,`GBP`,`JPY`|
| Environment         		| `sandbox`             		| Default : `false`<br>Other: `true`	    		|
| Platform ID         		| `platform_id`         		| Default : `null` 			    				   	|
| CA Bundle File      		| `cabundle_file`       		| Default : `null`			    				   	|
| Application Name    		| `application_name`    		| Default : `null`			    				   	|
| Application Version 		| `application_version` 		| Default : `null`			    				   	|
| Proxy Host          		| `proxy_host`          		| Default : `null`			    				   	|
| Proxy Port          		| `proxy_port`          		| Default : `-1`  			    				   	|
| Proxy Username      		| `proxy_username`      		| Default : `null`			    				   	|
| Proxy Password      		| `proxy_password`      		| Default : `null`			    				   	|
| LWA Client ID       		| `client_id`           		| Default : `null`			    				   	|
| Auto Retry On Throttle   	| `auto_retry_on_throttle`    	| Default : `true`<br>Other: `false`	    		|

## Setting Configuration

**Setting configuration while instantiating the Client object**
```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;

// Your Amazon Pay keys are available in your Seller Central account

// Configuration class object
Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	
	/* Supported regions are mentioned in the Regions class and accessed by the enum supportedRegions. 
	 * Example for 'us' is shown below
	 */
	.WithRegion(Regions.supportedRegions.us);

// Or you can also provide a JSON file path which has the above configuration information in JSON format
string config = "PATH_TO_JSON_FILE\filename.fileextension";

// Instantiate the client class with the config type
Client client = new Client(config);
```
**Setting configuration while instantiating the Client object with Json file**
* key names for json are mentioned in the table [Parameters List](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/README.md#parameters-list)
* keys are not case sensitive, Ex `merchant_id` can also be named as `Merchant_ID`
* The full path with the file name that has correct readbale permissions should be provided to the client class constructor

```csharp
// Your AmazonPay keys are available in your Seller Central account
// Sample Json file input
{
	// Required parameters
	"merchant_id": "YOUR_MERCHANT_ID",
	"access_key": "YOUR_ACCESS_KEY",
	"secret_key": "YOUR_SECRET_KEY",
	"region": "REGION",
	"sandbox": true,
   
	// Optional parameters
	"currency_code": "CURRENCY_CODE",
	"client_id": "amzn.oa2.client.xxx",
	"application_name": "sdk testing",
	"application_version": "1.0",
	"proxy_host": null,
	"proxy_port": -1,
	"proxy_username": null,
	"proxy_password": null
	"auto_retry_on_throttle": true
}
```
```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;

string config = "PATH_TO_JSON_FILE\filename.FileExtension";

// Instantiate the client class with the Json file path
Client client = new Client(config);
```

### Testing in Sandbox Mode

**The sandbox parameter defaults to false if not specified**
```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using AmazonPay.Responses;

Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	.WithRegion(Regions.supportedRegions.us)
	.WithSandbox(true);

Client client = new Client(config);
```

### Making an API Call

**Below is an example on how to make the GetOrderReferenceDetails API call**

```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using Newtonsoft.json;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;

// STEP 1 : Create the object of the GetOrderReferenceDetailsRequest class to add the parameters for the API call
GetOrderReferenceDetailsRequest requestParameters = new GetOrderReferenceDetailsRequest();

// AMAZON_ORDER_REFERENCE_ID is obtained from the Amazon Pay Address/Wallet widgets
// ACCESS_TOKEN is obtained from the GET parameter from the URL.

// Required Parameter
requestParameters.WithAmazonOrderReferenceId("AMAZON_ORDER_REFERENCE_ID");

// Optional Parameters
requestParameters.WithAccessToken("ACCESS_TOKEN");
requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");

/* STEP 2 : Making the API call by passing in the GetOrderReferenceDetailsRequest object i.e requestParameters from step 1.
 * response here is the object of the GetOrderReferenceDetailsResponse class
 */
OrderReferenceDetailsResponse getOrderReferenceDetailsResponse = client.GetOrderReferenceDetails(requestParameters);

// Getting response variables
// Variable values can be obtained directly from the OrderReferenceDetailsResponse object received from making the API call in step 2

// Check if the API call was successful
bool isGetOrderReferenceDetailsSuccess = getOrderReferenceDetailsResponse.GetSuccess(); 
	if(isGetOrderReferenceDetailsSuccess)
	{
		// Getting the XML Response
		string xml = getOrderReferenceDetailsResponse.GetXml();
		
		// Json Response
		string json = getOrderReferenceDetailsResponse.GetJson();
		
		// Dictionary
		Dictionary<string, object> dictionary = getOrderReferenceDetailsResponse.GetDict();
		
		// Getting individual variable values that is parsed in the Response class
		string amazonOrderReferenceId = getOrderReferenceDetailsResponse.GetAmazonOrderReferenceId();
		
		// Checking if any constraints on the Amazon OrderReference ID exist in the response for which an action should be taken.
		if(getOrderReferenceDetailsResponse.GetHasConstraint())
		{
			List<string> constraintIdList = getOrderReferenceDetailsResponse.GetConstraintIdList();
			List<string> constraintDescriptionList = getOrderReferenceDetailsResponse.GetDescriptionList();
		}
	}
	else
	{
		string errorCode = getOrderReferenceDetailsResponse.GetErrorCode();
		string ErrorMessage = getOrderReferenceDetailsResponse.GetErrorMessage();
	}
```
See the [OrderReferenceDetailsResponse](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/Responses/OrderReferenceDetailsResponse.cs) section for all the parameters returned.

* Similarly other API calls can be made. 
sections for Request classes for the required API calls.
	* [Standard Payments Requests](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/StandardPaymentRequests)
	* [Recurring Payments Requests](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/RecurringPaymentRequests)
	* [Provider Credit Requests](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/ProviderCreditRequests)
	* [Common Requests](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/CommonRequests) - This folder contains Configuration class and GerServiceStatus API call.
* Pass the created Request object to the respective API function in the class [Client.cs](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/Client.cs)
* The Response object returned will be specefic to the API call made. See API call functions in [Client.cs](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/Client.cs) for the return type.
* [Response](https://github.com/amzn/amazon-pay-sdk-csharp/tree/master/AmazonPay/Responses) classes contain the variables and their Getters.
* Each Response class provides XML response via responseObject.GetXml(), Json Response via responseObject.GetJson() and Dictionary<string,object> via responseObject.GetDict().

### Setting the Amount parameter
**For API calls that need the Amount parameter, the type of the amount parameter is `decimal`**

```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using Newtonsoft.json;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;

Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	.WithRegion(Regions.supportedRegions.us)
	.WithSandbox(true);

Client client = new Client(config);

// Example SetOrderReferenceDetails API call
// Creating the SetOrderReferenceDetailsRequest object
SetOrderReferenceDetailsRequest requestParameters = new SetOrderReferenceDetailsRequest();

// If the amount type was a string or a non decimal value type, 
// convert it into decimal type.
requestParameters.WithAmount(decimal.Parse("amount"));

// Also in general decimal values can be directly passed by
requestParameters.WithAmount(19.95m);

// Making the SetOrderReferenceDetails API call 
OrderReferenceDetailsResponse setOrderReferenceDetailsResponse = client.SetOrderReferenceDetails(requestParameters);
```

### Setting the Currency Code parameter
**For API calls that need the currency code parameter, there are two ways to set it**

**Setting it in the configuration class object globally**

```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using Newtonsoft.json;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;

Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	.WithRegion(Regions.supportedRegions.us)
	.WithSandbox(true)
	.WithCurrencyCode(Regions.currencyCode.USD);

Client client = new Client(config);
```

**Setting it while making the API call**

This takes priority over setting it globally. If this is not set via the following way the global value is taken.
```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using Newtonsoft.json;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;

Configuration config = new Configuration();
clientConfig.WithAccessKey("YOUR_ACCESS_KEY")
	.WithMerchantId("YOUR_MERCHANT_ID")
	.WithSecretKey("YOUR_SECRET_KEY")
	.WithRegion(Regions.supportedRegions.us)
	.WithSandbox(true);

Client client = new Client(config);

// Creating the SetOrderReferenceDetailsRequest object
SetOrderReferenceDetailsRequest requestParameters = new SetOrderReferenceDetailsRequest();
requestParameters.WithCurrencyCode(Regions.currencyCode.USD);

// Making the SetOrderReferenceDetails API call 
OrderReferenceDetailsResponse setOrderReferenceDetailsResponse = client.SetOrderReferenceDetails(requestParameters);
```

### IPN Handling

1. To receive IPN's successfully you will need an valid SSL on your domain.
2. You can set up your Notification endpoints in Seller Central by accessing the Integration Settings page in the Settings tab.
3. IpnHandler.cs class handles verification of the source and the data of the IPN

In your web project you can create a file (for example ipn.aspx with a CodeBehind file ipn.aspx.cs).  Add the below code into that file and set the URL to the file (ipn.aspx) location in Merchant/Integrator URL by accessing Integration Settings page in the Settings tab.

See [IPN Documentation](https://pay.amazon.com/documentation/lpwa/201749840#201750560) for all the information on IPN and types.
```csharp
using AmazonPay;
using AmazonPay.Responses;
// Get the IPN headers and Message body
Stream s = Request.InputStream;
StreamReader sr = new StreamReader(s);
string ipnMessage = sr.ReadToEnd();
NameValueCollection headers = Request.Headers;

// Create an object of the IpnHandler class
IpnHandler ipnObject = new IpnHandler(headers, ipnMessage);

// Response types
string xml = ipnObject.ToXml();
string json = ipnObject.ToJson();
Dictionary<string,object> dictionary = ipnObject.ToDict();

// Getting IPN common elements
string notificationType = ipnObject.GetNotificationType();
string merchantId = ipnObject.GetSellerId();
string notificationReferenceId = ipnObject.GetNotificationReferenceId();
string releaseEnvironment = ipnObject.GetReleaseEnvironment();
```

IPN's contain the XML response for the selective API calls made

**Notification types returned**
* OrderReferenceNotification
* BillingAgreementNotification
* PaymentAuthorize
* PaymentCapture
* PaymentRefund
* ProviderCredit
* ProviderCreditReversal

```csharp
using AmazonPay;
using AmazonPay.Responses;

// Getting response objects.
string notificationType = ipnObject.GetNotificationType();

AuthorizeResponse authResponse = null;

// Example - In this case the Authorize notification was returned 
if (notificationType.Equals(NotificationType.PaymentAuthorize.ToString()))
{
	authResponse = ipnObject.GetAuthorizeResponse();
}
// With the authResponse object you can get the required variable values
// Example - see AuthorizeResponse class for all variables and their Getter functions. 
string amazonAuthorizationId = authResponse.GetAmazonAuthorizationId();
```

### Convenience Methods

##### Charge Method

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
| Charge Note         	     | no        | Note that is sent to the buyer. <br>Maps to API call variables `seller_note` , `SellerAuthorizationNote`	 |
| Charge Order ID     	     | no        | Custom order ID provided <br>Maps to API call variables `SellerOrderId` , `SellerBillingAgreementId` 	 |
| Store Name          	     | no        | Name of the store                                                                                         |
| Platform ID         	     | no        | Merchant ID of the Solution Provider                                                                      |
| Custom Information  	     | no        | Any custom string                                                                                         |
| Inherit Shipping Address   | no        | Specifies whether to inherit the shipping address details, Default: true                                  |
| Soft Descriptor  			 | no        | The description to be shown on the buyer's payment instrument statement, Default: AMZ*                    |
| Provider Credit Details  	 | no        | Marketplace information                                                                                   |
| MWS Auth Token      	     | no        | MWS Auth Token required if API call is made on behalf of the seller                                       |

```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using Newtonsoft.json;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.RecurringPaymentRequests;
using AmazonPay.Responses;

try
{
	// ChargeRequest class object
	ChargeRequest requestParameters = new ChargeRequest();

	// Adding the parameters values to the ChargeRequest class
	requestParameters.WithAmazonReferenceId("AMAZON_REFERENCE_ID")
		.WithChargeReferenceId("AUTHORIZATION_REFERENCE_ID")
		.WithAmount("100.50")
		.WithMerchantId("MERCHANT_ID")
		.WithCurrencyCode(Regions.currencyCode.USD)
		.WithPlatformId("SOLUTION_PROVIDER_MERCHANT_ID")
		.WithSoftDescriptor("AMZ*")
		.WithStoreName("cool stuff store")
		.WithMWSAuthToken("MWS_AUTH_TOKEN")
		.WithChargeNote("sample note")
		.WithChargeOrderId("1234-1234")
		.WithCaptureNow(false)
		.WithProviderCreditDetails("PROVIDER_MERCHANT_ID", "10", Regions.currencyCode.USD)
		.WithInheritShippingAddress(true)
		.WithTransactionTimeout(5)
		.WithCustomInformation("custom information");

	// Get the Authorization response from the charge method
	AuthorizeResponse response = client.Charge(requestParameters);
}
catch (InvalidDataException ex)
{
 string errorMessage = ex.Data["errorMessage"];
 string errorCode = ex.Data["errorCode"];
 string exceptionMessage = ex.Message;
}
```
##### Obtain profile information (GetUserInfo method)
1. obtains the user's profile information from Amazon using the access token returned by the Button widget.
2. An access token is granted by the authorization server when a user logs in to a site.
3. An access token is specific to a client, a user, and an access scope. A client must use an access token to retrieve customer profile data.

| Parameter           | Variable Name         | Mandatory | Values                                                                       	     		|
|---------------------|-----------------------|-----------|---------------------------------------------------------------------------------------------|
| Access Token        | `access_token`        | yes       | Retrieved as GET parameter from the URL                                      	     		|
| Region              | `region`              | yes       | Default :`null` <br>Other:`us`,`de`,`uk`,`jp`<br>Value is set in Client class Configuration |
| LWA Client ID       | `client_id`           | yes       | Default: null<br>Value should be set in the Client class Configuration                        	     	|

```csharp
using AmazonPay;
using AmazonPay.CommonRequests;
using AmazonPay.Responses;

// Your AmazonPay keys are available in your Seller Central account

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

### Enable Logging in (Client, IpnHandler)

##### Simple Common Logging Implementation
1. Update "appSettings" within App.config or Web.config with Sanitize Data list with things you would like to be sanitize. See example bellow.
    ```xml
	<add key="sanitizeList" value="RequestID;Error;SellerId;SignatureMethod;CaptureNow"/>
	```
2. Create Simple Logger Adapter and Logger
	```csharp
	// Setting Simple Logger Adapter
    Common.Logging.LogManager.Adapter = new Common.Logging.Simple.TraceLoggerFactoryAdapter();
    // Create logger of type "Client"
    Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger<Client>();
	```
3.	Set Logger property for instance of Client.
	```csharp
	Client client = new Client(clientConfig);
	// Set Logger for Client
    client.Logger = logger;
	```

###	Convenience Method Workflow

##### This API allows you to make one API call 'GetPaymentDetails' to retrieve OrderReference, Authorize, Capture and Refund Details Response.

```
    //GetPaymentDetails takes two parameters - AmazonOrderReferenID(required) and MWSAuthToken(optional)
    PaymentDetailsResponse payDetailsResponse = client.GetPaymentDetails("S01-9111020-6707923", null); 
    System.Diagnostics.Debug.WriteLine(payDetailsResponse.GetOrderReferenceDetails().GetXml());
        
    foreach (var group in payDetailsResponse.GetAuthorizationDetails())
        {
            System.Diagnostics.Debug.WriteLine("Key: {0} Value: {1}", group.Key, group.Value.GetXml());
        }
    foreach (var group in payDetailsResponse.GetCaptureDetails())
        {
            System.Diagnostics.Debug.WriteLine("Key: {0} Value: {1}", group.Key, group.Value.GetXml());
        }
    foreach (var group in payDetailsResponse.GetRefundDetails())
        {
            System.Diagnostics.Debug.WriteLine("Key: {0} Value: {1}", group.Key, group.Value.GetXml());
        }
```

### Retrieving Payment Descriptor in GetOrderReferenceDetails call

##### This feature allows you to retrieve Payment Descriptor in the GetOrderReferenceDetails call. Steps to follow to retrieve payment Descriptor as are below -
1. Your Amazon Pay Client ID (amzn1.xxxxxxx) needs to be whitelisted with the “payments:instrument_descriptor” scope. Please contact Amazon Pay Support for whitelisting your Client ID.
2. Add the “payments:instrument_descriptor” scope to your (test) site button.
3. Pass the obtained “access_token” and Order Reference ID’s to the GetOrderReferenceDetails request.

```
    GetOrderReferenceDetailsRequest getOrderReferenceDetailsRequest = new GetOrderReferenceDetailsRequest();
    getOrderReferenceDetailsRequest.WithAmazonOrderReferenceId("AMAZON_ORDER_REFERENCE_ID");
    getOrderReferenceDetailsRequest.WithaccessToken(ACCESS_TOKEN);
          
    OrderReferenceDetailsResponse getOrderReferenceDetailsResponse = client.GetOrderReferenceDetails(getOrderReferenceDetailsRequest);
	
    System.Diagnostics.Debug.WriteLine(getOrderReferenceDetailsResponse.GetFullDescriptor());
    System.Diagnostics.Debug.WriteLine(getOrderReferenceDetailsResponse.GetAmazonBalanceFirst());
    System.Diagnostics.Debug.WriteLine(getOrderReferenceDetailsResponse.GetXml());
```
