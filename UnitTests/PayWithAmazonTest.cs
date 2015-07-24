using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PayWithAmazon;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Net;

namespace UnitTests
{
    [TestFixture]
    public class PayWithAmazonTest
    {
        private Hashtable configParams = new Hashtable()
        {
            {"merchant_id","test"},
            {"access_key","test"},
            {"secret_key","test"},
            {"currency_code","usd"},
            {"client_id","test"},
            {"region","us"},
            {"sandbox", true},
            {"platform_id",null},
            {"cabundle_file", null},
            {"application_name","sdk testing"},
            {"application_version","1.0"},
            {"proxy_host", null},
            {"proxy_port", -1},
            {"proxy_username", null},
            {"proxy_Password", null}
        };

        [Test]
        public void TestConfig()
        {

            try
            {
                Hashtable configParams = new Hashtable(){
                {"a","A"},
                {"b","B"}
                };
                Client client = new Client(configParams);
            }
            catch (KeyNotFoundException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "is either not part of the configuration or has incorrect Key name", RegexOptions.IgnoreCase));
            }

            try
            {
                Hashtable configParams = new Hashtable();
                configParams = null;
                Client client = new Client(configParams);
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "config is null", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void TestJsonFile()
        {
            try
            {
                string jsonfilepath = "";
                Client client = new Client(jsonfilepath);
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Json file path is not provided", RegexOptions.IgnoreCase));
            }
            try
            {
                string jsonfilepath = Path.Combine(Environment.CurrentDirectory, @"confi.json");
                Client client = new Client(jsonfilepath);
            }
            catch (FileNotFoundException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "File not found", RegexOptions.IgnoreCase));
            }
            try
            {
                string jsonfilepath = Path.Combine(Environment.CurrentDirectory, @"config.json");
                Client client = new Client(jsonfilepath);
            }
            catch (JsonReaderException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "incorrect json", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void TestSandboxSetter()
        {
            Client client = new Client(configParams);
            client.SetSandbox(true);
            Assert.AreEqual(client.config["sandbox"], true);
        }

        [Test]
        public void TestClientIDSetter()
        {
            Client client = new Client(configParams);
            try
            {
                client.SetClientId("");
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Client ID value cannot be empty", RegexOptions.IgnoreCase));
            }
            try
            {
                client.SetClientId(null);
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Client ID value cannot be empty", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void TestProxySetter()
        {
            Client client = new Client(configParams);
            Hashtable proxy = new Hashtable();
            proxy.Add("proxy_user_host", null);
            client.SetProxy(proxy);
        }

        [Test]
        public void TestGetOrderReferenceDetails()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"address_consent_token","AddressConsentToken"},
                {"mws_auth_token","MWSAuthToken"} 
            };

            string action = "GetOrderReferenceDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetOrderReferenceDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.GetOrderReferenceDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestSetOrderReferenceDetails()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"Merchant_Id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"amount","OrderReferenceAttributes.OrderTotal.Amount"},
                {"currency_code","OrderReferenceAttributes.OrderTotal.CurrencyCode"},
                {"platform_id","OrderReferenceAttributes.PlatformId"},
                {"seller_note","OrderReferenceAttributes.SellerNote"},
                {"seller_order_id","OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId"},
                {"store_name","OrderReferenceAttributes.SellerOrderAttributes.StoreName"},
                {"custom_information","OrderReferenceAttributes.SellerOrderAttributes.CustomInformation"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "SetOrderReferenceDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetOrderReferenceDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.SetOrderReferenceDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestConfirmOrderReference()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "ConfirmOrderReference";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API ConfirmOrderReference
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.ConfirmOrderReference(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        public void TestCancelOrderReference()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"cancelation_reason","CancelationReason"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "CancelOrderReference";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CancelOrderReference
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.CancelOrderReference(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        public void TestCloseOrderReference()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_order_reference_id","AmazonOrderReferenceId"},
                    {"closure_reason","ClosureReason"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "CloseOrderReference";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CloseOrderReference
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.CloseOrderReference(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCloseAuthorization()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_authorization_id","AmazonAuthorizationId"},
                    {"closure_reason","ClosureReason"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "CloseAuthorization";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CloseAuthorization
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.CloseAuthorization(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestAuthorize()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_order_reference_id","AmazonOrderReferenceId"},
                    {"authorization_amount","AuthorizationAmount.Amount"},
                    {"currency_code","AuthorizationAmount.CurrencyCode"},
                    {"authorization_reference_id","AuthorizationReferenceId"},
                    {"capture_now","CaptureNow"},
                    {"seller_authorization_note","SellerAuthorizationNote"},
                    {"transaction_timeout","TransactionTimeout"},
                    {"soft_descriptor","SoftDescriptor"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "Authorize";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Authorize
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.Authorize(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetAuthorizationDetails()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_authorization_id","AmazonAuthorizationId"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "GetAuthorizationDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetAuthorizationDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.GetAuthorizationDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCapture()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_authorization_id","AmazonAuthorizationId"},
                    {"capture_amount","CaptureAmount.Amount"},
                    {"currency_code","CaptureAmount.CurrencyCode"},
                    {"capture_reference_id","CaptureReferenceId"},
                    {"seller_capture_note","SellerCaptureNote"},
                    {"soft_descriptor","SoftDescriptor"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "Capture";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Capture
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.Capture(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetCaptureDetails()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_capture_id","AmazonCaptureId"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "GetCaptureDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetCaptureDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.GetCaptureDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

        }

        [Test]
        public void TestRefund()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id" ,"SellerId"},
                    {"amazon_capture_id","AmazonCaptureId"},
                    {"refund_reference_id","RefundReferenceId"},
                    {"refund_amount" ,"RefundAmount.Amount"},
                    {"currency_code" ,"RefundAmount.CurrencyCode"},
                    {"seller_refund_note","SellerRefundNote"},
                    {"soft_descriptor" ,"SoftDescriptor"},
                    {"mws_auth_token" ,"MWSAuthToken"}
                };

            string action = "Refund";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Refund
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.Refund(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetRefundDetails()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_refund_id","AmazonRefundId"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "GetRefundDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetRefundDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.GetRefundDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetServiceStatus()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "GetServiceStatus";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetServiceStatus
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.GetServiceStatus(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCreateOrderReferenceForId()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"id","Id"},
                    {"id_type","IdType"},
                    {"inherit_shipping_address","InheritShippingAddress"},
                    {"confirm_now","ConfirmNow"},
                    {"amount","OrderReferenceAttributes.OrderTotal.Amount"},
                    {"currency_code","OrderReferenceAttributes.OrderTotal.CurrencyCode"},
                    {"platform_id","OrderReferenceAttributes.PlatformId"},
                    {"seller_note","OrderReferenceAttributes.SellerNote"},
                    {"seller_order_id","OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId"},
                    {"store_name","OrderReferenceAttributes.SellerOrderAttributes.StoreName"},
                    {"custom_information","OrderReferenceAttributes.SellerOrderAttributes.CustomInformation"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "CreateOrderReferenceForId";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CreateOrderReferenceForId
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.CreateOrderReferenceForId(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetBillingAgreementDetails()
        {
            Hashtable fieldMappings = new Hashtable()
                {
                    {"merchant_id","SellerId"},
                    {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                    {"address_consent_token" ,"AddressConsentToken"},
                    {"mws_auth_token","MWSAuthToken"}
                };

            string action = "GetBillingAgreementDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetBillingAgreementDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.GetBillingAgreementDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestSetBillingAgreementDetails()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"platform_id","BillingAgreementAttributes.PlatformId"},
                {"seller_note","BillingAgreementAttributes.SellerNote"},
                {"seller_billing_agreement_id","BillingAgreementAttributes.SellerBillingAgreementAttributes.SellerBillingAgreementId"},
                {"custom_information","BillingAgreementAttributes.SellerBillingAgreementAttributes.CustomInformation"},
                {"store_name","BillingAgreementAttributes.SellerBillingAgreementAttributes.StoreName"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "SetBillingAgreementDetails";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetBillingAgreementDetails
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.SetBillingAgreementDetails(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestConfirmBillingAgreement()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "ConfirmBillingAgreement";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API ConfirmBillingAgreement
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.ConfirmBillingAgreement(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestValidateBillingAgreement()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "ValidateBillingAgreement";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API ValidateBillingAgreement
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.ValidateBillingAgreement(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestAuthorizeOnBillingAgreement()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"authorization_reference_id","AuthorizationReferenceId"},
                {"authorization_amount","AuthorizationAmount.Amount"},
                {"currency_code","AuthorizationAmount.CurrencyCode"},
                {"seller_authorization_note","SellerAuthorizationNote"},
                {"transaction_timeout","TransactionTimeout"},
                {"capture_now","CaptureNow"},
                {"soft_descriptor","SoftDescriptor"},
                {"seller_note","SellerNote"},
                {"platform_id","PlatformId"},
                {"custom_information","SellerOrderAttributes.CustomInformation"},
                {"seller_order_id","SellerOrderAttributes.SellerOrderId"},
                {"store_name","SellerOrderAttributes.StoreName"},
                {"inherit_shipping_address","InheritShippingAddress"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "AuthorizeOnBillingAgreement";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API AuthorizeOnBillingAgreement
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.AuthorizeOnBillingAgreement(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCloseBillingAgreement()
        {
            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"closure_reason","ClosureReason"},
                {"mws_auth_token","MWSAuthToken"}
            };

            string action = "CloseBillingAgreement";
            Hashtable parameters = SetParametersAndPost(fieldMappings, action);
            Hashtable expectedParametershash = parameters["expectedParameters"] as Hashtable;
            Hashtable apiCallParams = parameters["apiCallParams"] as Hashtable;

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(configParams);
            client.SetTimeStamp("0000");
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>();
            expectedParameters = convertHashToDict(expectedParametershash);

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CloseBillingAgreement
            client = new Client(configParams);
            client.SetTimeStamp("0000");

            client.CloseBillingAgreement(apiCallParams);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCharge()
        {
            Client client = new Client(configParams);
            Hashtable apiCallParams = new Hashtable();
            try
            {
                apiCallParams.Add("amazon_reference_id", "S01-TEST");
                client.Charge(apiCallParams);
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "state not found", RegexOptions.IgnoreCase));
            }
            try
            {
                client = new Client(configParams);
                apiCallParams.Clear();
                apiCallParams.Add("amazon_reference_id", "");
                client.Charge(apiCallParams);
            }
            catch (MissingFieldException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "key amazon_order_reference_id or amazon_billing_agreement_id is null and is a required parameter", RegexOptions.IgnoreCase));
            }

            try
            {
                apiCallParams.Clear();
                client = new Client(configParams);
                apiCallParams.Add("amazon_reference_id", "T01");
                client.Charge(apiCallParams);
            }
            catch (InvalidDataException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Invalid Amazon Reference ID", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void TestGetUserInfo()
        {
            try
            {
                configParams["region"] = "";
                Client client = new Client(configParams);
                client.GetUserInfo("Atza");
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "is a required parameter", RegexOptions.IgnoreCase));
            }

            try
            {
                configParams["region"] = "us";
                Client client = new Client(configParams);
                client.GetUserInfo(null);
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Access Token is a required parameter and is not set", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void Test500or503()
        {
            string parameters = "Actinon=hjhjhjh=saaa&jg=100";
            try
            {
                Client client = new Client(configParams);

                string url = "https://dsenetsdk.ant.amazon.com/500error/500error.aspx";
                client.SetMwsServiceUrl(url);

                MethodInfo method = GetMethod("Invoke");
                method.Invoke(client, new object[] { parameters }).ToString();

            }
            catch (WebException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Maximum number of retry attempts", RegexOptions.IgnoreCase));
            }

        }

        [Test]
        public void TestJsonResponse()
        {
            Hashtable response = new Hashtable();
            response["ResponseBody"] =
            "<GetOrderReferenceDetailsResponse xmlns='http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01'>"
            + "<AmazonOrderReferenceId>S01-5806490-2147504</AmazonOrderReferenceId>"
            + "<ExpirationTimestamp>2015-09-27T02:18:33.408Z</ExpirationTimestamp>"
            + "<SellerNote>This is testing API call</SellerNote>"
            + "</GetOrderReferenceDetailsResponse>";

            string json = File.ReadAllText("json.txt");

            ResponseParser responseObj = new ResponseParser(response["ResponseBody"].ToString());
            string jsonResponse = responseObj.ToJson();
            Assert.AreEqual(json, jsonResponse);
        }

        [Test]
        public void TestDictResponse()
        {
            Hashtable response = new Hashtable();
            IDictionary tempDict = null;
            Dictionary<string, string> compareDict = new Dictionary<string, string>();
            response["ResponseBody"] =
            "<GetOrderReferenceDetailsResponse xmlns='http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01'>"
            + "<AmazonOrderReferenceId>S01-5806490-2147504</AmazonOrderReferenceId>"
            + "<ExpirationTimestamp>2015-09-27T02:18:33.408Z</ExpirationTimestamp>"
            + "<SellerNote>This is testing API call</SellerNote>"
            + "</GetOrderReferenceDetailsResponse>";

            Dictionary<string, object> dictResponse = new Dictionary<string, object>()
              {
                  {"AmazonOrderReferenceId","S01-5806490-2147504"},
                  {"ExpirationTimestamp","9/27/2015 2:18:33 AM"},
                  {"SellerNote","This is testing API call"}
              };

            ResponseParser responseObj = new ResponseParser(response["ResponseBody"].ToString());
            Dictionary<string, object> returnDictResponse = responseObj.ToDict();

            foreach (KeyValuePair<string, object> item in returnDictResponse)
            {
                object o = returnDictResponse[item.Key];
                if (o is IDictionary)
                {
                    tempDict = (IDictionary)o;
                    tempDict.Remove("@xmlns");
                    foreach (string items in tempDict.Keys)
                    {
                        compareDict.Add(items, tempDict[items].ToString());
                    }
                }
                else
                {
                    compareDict.Add(o.ToString(), tempDict[o.ToString()].ToString());

                }
            }

            CollectionAssert.AreEqual(dictResponse, compareDict);
        }

        private Hashtable SetParametersAndPost(Hashtable fieldMappings, string action)
        {
            Hashtable expectedParameters = new Hashtable();
            Hashtable apiCallParams = new Hashtable();
            Hashtable returnTable = new Hashtable();

            Hashtable parameters = SetDefaultValues(fieldMappings);
            expectedParameters = parameters["expectedParameters"] as Hashtable;
            apiCallParams = parameters["apiCallParams"] as Hashtable;

            expectedParameters.Add("Action", action);

            foreach (DictionaryEntry param in fieldMappings)
            {
                try
                {
                    if (string.IsNullOrEmpty(expectedParameters[param.Value].ToString()))
                    {
                        expectedParameters[param.Value] = "test";
                        apiCallParams[param.Key] = "test";
                    }
                }
                catch (NullReferenceException)
                {
                    expectedParameters[param.Value] = "test";
                    apiCallParams[param.Key] = "test";
                }
            }

            returnTable.Add("expectedParameters", expectedParameters);
            returnTable.Add("apiCallParams", apiCallParams);

            return returnTable;
        }

        private Hashtable SetDefaultValues(Hashtable fieldMappings)
        {
            Hashtable expectedParameters = new Hashtable();
            Hashtable apiCallParams = new Hashtable();
            Hashtable returnTable = new Hashtable();

            if (fieldMappings.ContainsKey("platform_id"))
            {
                expectedParameters[fieldMappings["platform_id"]] = null;
                apiCallParams["platform_id"] = null;
            }

            if (fieldMappings.ContainsKey("currency_code"))
            {
                expectedParameters[fieldMappings["currency_code"]] = "TEST";
                apiCallParams["currency_code"] = "TEST";
            }

            returnTable.Add("expectedParameters", expectedParameters);
            returnTable.Add("apiCallParams", apiCallParams);

            return returnTable;
        }

        /* Get the private method of the Client class for testing using the Reflection method */

        private MethodInfo GetMethod(string methodName)
        {
            Client client = new Client(configParams);
            Type type = typeof(Client);
            var method = client.GetType()
                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }

        private Dictionary<string, string> convertHashToDict(Hashtable input)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (DictionaryEntry item in input)
            {
                dict.Add(item.Key.ToString(), item.Value.ToString());
            }

            return dict;
        }
    }
}