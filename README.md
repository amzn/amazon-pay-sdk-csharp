# Login and Pay with Amazon CHARP SDK
Login and Pay with Amazon API Integration

## Requirements

* Login and Pay With Amazon account - [Register here](https://payments.amazon.com/signup)
* .NET 2.0 or higher
* Newtonsoft.json (JSON.NET)

## Documentation

* The Integration steps can be found [here](https://payments.amazon.com/documentation)

## Sample

* View the sample integration demo [here](https://amzn.github.io/login-and-pay-with-amazon-sdk-samples/)
> csharp samples will be added soon

## Quick Start

Instantiating the client:
Client Takes in parameters in the following format

1. Hashtable
2. Path to the JSON file containing configuration information.

## Installing using nuget
```
> will be made available soon
```
##Parameters List

####Mandatory Parameters
| Parameter    | variable name | Values          								|
|--------------|---------------|------------------------------------------------|
| Merchant Id  | `merchant_id` | Default : `null`								|
| Access Key   | `access_key`  | Default : `null`								|
| Secret Key   | `secret_key`  | Default : `null`								|
| Region       | `region`      | Default : `null`<br>Other: `us`,`de`,`uk`,`jp`	|

####Optional Parameters
| Parameter           | Variable name         | Values                                      	   |
|---------------------|-----------------------|----------------------------------------------------|
| Currency Code       | `currency_code`       | Default : `null`<br>Other: `USD`,`EUR`,`GBP`,`JPY` |
| Environment         | `sandbox`             | Default : `false`<br>Other: `true`	    		   |
| Platform ID         | `platform_id`         | Default : `null` 			    				   |
| CA Bundle File      | `cabundle_file`       | Default : `null`			    				   |
| Application Name    | `application_name`    | Default : `null`			    				   |
| Application Version | `application_version` | Default : `null`			    				   |
| Proxy Host          | `proxy_host`          | Default : `null`			    				   |
| Proxy Port          | `proxy_port`          | Default : `-1`  			    				   |
| Proxy Username      | `proxy_username`      | Default : `null`			    				   |
| Proxy Password      | `proxy_password`      | Default : `null`			    				   |
| LWA Client ID       | `client_id`           | Default : `null`			    				   |
| Handle Throttle     | `handle_throttle`     | Default : `true`<br>Other: `false`	    		   |

## Setting Configuration

Setting configuration while instantiating the Client object
```csharp
using PayWithAmazon;

// Your Login and Pay with Amazon keys are available in your Seller Central account

// csharp Hashtable
Hashtable config = new Hashtable() {
	{"merchant_id","YOUR_MERCHANT_ID"},
	{"access_key","YOUR_ACCESS_KEY"},
	{"secret_key","YOUR_SECRET_KEY"},
	{"client_id","YOUR_LOGIN_WITH_AMAZON_CLIENT_ID"},
	{"region","REGION"}
};

// Or You can also provide a JSON file path which has the above configuration information in JSON format
string config = "PATH_TO_JSON_FILE";

// Instantiate the client class with the config type
Client client = new Client(config);
```
### Testing in Sandbox Mode

The sandbox parameter is defaulted to false if not specified:
```csharp
using PayWithAmazon;

Hashtable config = new Hashtable() {
	{"merchant_id","YOUR_MERCHANT_ID"},
	{"access_key","YOUR_ACCESS_KEY"},
	{"secret_key","YOUR_SECRET_KEY"},
	{"client_id","YOUR_LOGIN_WITH_AMAZON_CLIENT_ID"},
	{"sandbox",true}
};

Client client = new Client(config);

// Also you can set the sandbox variable in the config HashTable of the Client class by

client.setSandbox(true);
```
### Setting Proxy values
Proxy parameters can be set after Instantiating the Client Object with the following setter
```csharp
Hashtbale proxy =  new Hashtable();
proxy.Add("proxy_user_host", "YOUR_PROXY_HOSTNAME"); // Hostname for the proxy
proxy.Add("proxy_user_port","YOUR_PROXY_PORT"); // Hostname for the proxy
proxy.Add("proxy_user_name","YOUR_PROXY_USER_NAME"); // If your proxy requires a username
proxy.Add("proxy_user_password","YOUR_PROXY_PASSWORD"); // If your proxy requires a password

client.setProxy(proxy);
```

### Making an API Call

Below is an example on how to make the GetOrderReferenceDetails API call:

```csharp
using PayWithAmazon;

Hashtable requestParameters = new Hashtable();

// AMAZON_ORDER_REFERENCE_ID is obtained from the Pay with Amazon Address/Wallet widgets
// ACCESS_TOKEN is obtained from the GET parameter from the URL.

// Required Parameter
requestParameters.Add("amazon_order_reference_id","AMAZON_ORDER_REFERENCE_ID");

// Optional Parameter
requestParameters.Add("address_consent_token","ACCESS_TOKEN");
requestParameters.Add("mws_auth_token","MWS_AUTH_TOKEN");

// response here is the object of the ResponseParser class, 
// You can use this object to get the desired response type in the section Response Parsing 
ResponseParser response = client.getOrderReferenceDetails(requestParameters);

```
See the [API Response](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp/blob/DoDo/README.md#api-response) section for information on parsing the API response.

### IPN Handling

1. To receive IPN"s successfully you will need an valid SSL on your domain.
2. You can set up your Notification endpoints in Seller Central by accessing the Integration Settings page in the Settings tab.
3. IpnHandler.csharp class handles verification of the source and the data of the IPN

In your web project you can create a file( for example ipn.aspx with a CodeBehind file ipn.aspx.cs).  
Add the below code into that file and set the URL to the file (ipn.aspx) location in Merchant/Integrator URL by accessing Integration Settings page in the Settings tab.

```csharp
using PayWithAmazon;

// Get the IPN headers and Message body
Stream s = Request.InputStream;
StreamReader sr = new StreamReader(s);
string json = sr.ReadToEnd();
NameValueCollection headers = Request.Headers;

// Create an object(ipn) of the IpnHandler class
IpnHandler ipn = new IpnHandler(json, headers);

```
See the [IPN Response](https://github.com/amzn/login-and-pay-with-amazon-sdk-csharp/blob/DoDo/README.md#ipn-response) section for information on parsing the IPN response.

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

> **Capture Now** can be set to `true` for digital goods . For Physical goods it"s highly recommended to set the Capture Now to `false`
and the amount captured by making the `capture` API call after the shipment is complete.


| Parameter                  | Variable Name                | Mandatory | Values                                                                                              	    |
|----------------------------|------------------------------|-----------|-----------------------------------------------------------------------------------------------------------|
| Amazon Reference ID 	     | `amazon_reference_id` 	    | yes       | OrderReference ID (`starts with P01 or S01`) or <br>Billing Agreement ID (`starts with B01 or C01`)       |
| Amazon OrderReference ID   | `amazon_order_reference_id`  | no        | OrderReference ID (`starts with P01 or S01`) if no Amazon Reference ID is provided                        |
| Amazon Billing Agreement ID| `amazon_billing_agreement_id`| no        | Billing Agreement ID (`starts with B01 or C01`) if no Amazon Reference ID is provided                     |
| Merchant ID         	     | `merchant_id`         	    | no        | Value taken from config Hashtable in Client.csharp                                                        |
| Charge Amount       	     | `charge_amount`       	    | yes       | Amount that needs to be captured.<br>Maps to API call variables `amount` , `authorization_amount`         |
| Currency code       	     | `currency_code`       	    | no        | If no value is provided, value is taken from the config Hashtable in Client.csharp      		            |
| Authorization Reference ID | `authorization_reference_id` | yes       | Unique string to be passed									                                            |
| Transaction Timeout 	     | `transaction_timeout`        | no        | Timeout for Authorization - Defaults to 1440 minutes						                                |
| Capture Now	             | `capture_now`                | no        | Will capture the payment automatically when set to `true`. Defaults to `false`						    |
| Charge Note         	     | `charge_note`         	    | no        | Note that is sent to the buyer. <br>Maps to API call variables `seller_note` , `seller_authorization_note`|
| Charge Order ID     	     | `charge_order_id`     	    | no        | Custom order ID provided <br>Maps to API call variables `seller_order_id` , `seller_billing_agreement_id` |
| Store Name          	     | `store_name`          	    | no        | Name of the store                                                                                         |
| Platform ID         	     | `platform_id`         	    | no        | Platform ID of the Solution provider                                                                      |
| Custom Information  	     | `custom_information`  	    | no        | Any custom string                                                                                         |
| MWS Auth Token      	     | `mws_auth_token`      	    | no        | MWS Auth Token required if API call is made on behalf of the seller                                       |

```csharp
// Create an Hashtable that will contain the parameters for the charge API call
Hashtable requestParameters = new Hashtable();

// Adding the parameters values to the respective keys in the Hashtable
requestParameters.Add("amazon_reference_id","AMAZON_REFERENCE_ID");

// Or
// If requestParameters["amazon_reference_id"] is not provided,
// either one of the following ID input is needed
requestParameters.Add("amazon_order_reference_id","AMAZON_ORDER_REFERENCE_ID");
requestParameters.Add("amazon_billing_agreement_id","AMAZON_BILLING_AGREEMENT_ID");

requestParameters.Add("seller_id",null);
requestParameters.Add("charge_amount",100.50);
requestParameters.Add("currency_code","USD");
requestParameters.Add("authorization_reference_id","UNIQUE STRING");
requestParameters.Add("transaction_timeout",0) ;
requestParameters.Add("capture_now",false); //`true` for Digital goods
requestParameters.Add("charge_note","Example item note");
requestParameters.Add("charge_order_id","1234-Example-Order");
requestParameters.Add("store_name","Example Store");
requestParameters.Add("platform_id",null);
requestParameters.Add("custom_information","Any_Custom_String");
requestParameters.Add("mws_auth_token",null);

// Get the Authorization response from the charge method
ResponseParser response = client.Charge(requestParameters);
```
#####Obtain profile information (GetUserInfo method)
1. obtains the user"s profile information from Amazon using the access token returned by the Button widget.
2. An access token is granted by the authorization server when a user logs in to a site.
3. An access token is specific to a client, a user, and an access scope. A client must use an access token to retrieve customer profile data.

| Parameter           | Variable Name         | Mandatory | Values                                                                       	     |
|---------------------|-----------------------|-----------|------------------------------------------------------------------------------------------|
| Access Token        | `access_token`        | yes       | Retrieved as GET parameter from the URL                                      	     |
| Region              | `region`              | yes       | Default :`null` <br>Other:`us`,`de`,`uk`,`jp`<br>Value is set in config["region"] Hashtable |
| LWA Client ID       | `client_id`           | yes       | Default: null<br>Value should be set in config Hashtable                        	     |

```csharp
 using PayWithAmazon;

// config Hashtable parameters that need to be instantiated
Hashtable config = new Hashtable(){
	{"client_id","YOUR_LOGIN_WITH_AMAZON_CLIENT_ID"},
	{"region","REGION"}
};

Client client = new Client(config);

// Client ID can also be set using the setter function setClientId(client_id)
client.SetClientId("YOUR_LWA_CLIENT_ID");

// Get the Access Token from the URL
string access_token = "ACCESS_TOKEN";
// Calling the function getUserInfo with the access token parameter returns object
string jsonResponse = client.GetUserInfo(access_token);

// Using Newtonsoft (Json.net) library
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
IpnHandler ipnResponse = new IpnHandler(headers, body);

// XML message response
ipnResponse.ToXml();

// Associative Hashtable response
ipnResponse.ToDict);

// JSON response
ipnResponse.ToJson();
```
