using System;
using System.Collections.Generic;
using NUnit.Framework;
using AmazonPay;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Net;
using AmazonPay.ProviderCreditRequests;
using AmazonPay.RecurringPaymentRequests;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.CommonRequests;
using AmazonPay.Responses;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Threading;


namespace UnitTests
{
    [TestFixture]
    public class AmazonPayUnitTests
    {
        Configuration clientConfig = new Configuration();

        public AmazonPayUnitTests()
        {
            clientConfig.WithMerchantId("test")
                .WithAccessKey("test")
                .WithSecretKey("test")
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithClientId("test")
                .WithRegion(Regions.supportedRegions.us)
                .WithSandbox(true)
                .WithPlatformId("test")
                .WithCABundleFile("test")
                .WithApplicationName("test")
                .WithApplicationVersion("1.0.0")
                .WithProxyHost("")
                .WithProxyPort(-1)
                .WithProxyUserName("test")
                .WithProxyUserPassword("test")
                .WithAutoRetryOnThrottle(true);
        }

        //loadTestFile loads XML file for testing
        private String loadTestFile(String fileName)
        {
            StringBuilder output = new StringBuilder();
            string xmlString = File.ReadAllText(@"TestFiles\" + fileName);

            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Name);
                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
            }
            return output.ToString();
        }

        [Test]
        public void TestConfig()
        {

            try
            {
                Configuration clientConfig = new Configuration();
                clientConfig.WithAccessKey("A")
                    .WithSecretKey("B");
                Client client = new Client(clientConfig);
            }
            catch (KeyNotFoundException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "is either not part of the configuration or has incorrect Key name", RegexOptions.IgnoreCase));
            }

            try
            {
                Configuration clientConfig = new Configuration();
                clientConfig = null;
                Client client = new Client(clientConfig);
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
                string jsonfilepath = Path.Combine(Environment.CurrentDirectory, @"config.json");
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
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Incorrect json", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void TestGetOrderReferenceDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()  {
                {"Action","GetOrderReferenceDetails"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"AccessToken","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetOrderReferenceDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            GetOrderReferenceDetailsRequest getOrderReferenceDetails = new GetOrderReferenceDetailsRequest();
            getOrderReferenceDetails.WithMerchantId("test")
                .WithAccessToken("test")
                .WithAmazonOrderReferenceId("test")
                .WithMWSAuthToken("test");

            //Testing GetOrderReferenceDetails Request
            client.GetOrderReferenceDetails(getOrderReferenceDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing GetOrderReferenceDetails Response
            String rawResponse = loadTestFile("GetOrderReferenceDetails.xml");
            OrderReferenceDetailsResponse oroResponseObject = new OrderReferenceDetailsResponse(rawResponse);
            Assert.AreEqual(oroResponseObject.GetAmazonOrderReferenceId(), "S01-9111020-6707923");
            Assert.AreEqual(oroResponseObject.GetOrderReferenceState(), "Open");
            Assert.AreEqual(oroResponseObject.GetDestinationType(), "Physical");
            Assert.AreEqual(oroResponseObject.GetCity(), "New York");
            Assert.AreEqual(oroResponseObject.GetStateOrRegion(), "NY");
            Assert.AreEqual(oroResponseObject.GetPostalCode(), "10101-9876");
            Assert.AreEqual(oroResponseObject.GetCountryCode(), "US");
            Assert.AreEqual(oroResponseObject.GetReleaseEnvironment(), "Sandbox");
            Assert.AreEqual(oroResponseObject.GetRequestId(), "373eb307-5f37-468c-b6ba-1ef578ac2f51");
            Assert.AreEqual(oroResponseObject.GetBillingAddressDetails().GetAddressLine1(), "4996 Rockford Mountain Lane");
            Assert.AreEqual(oroResponseObject.GetBillingAddressDetails().GetCity(), "Appleton");
            Assert.AreEqual(oroResponseObject.GetBillingAddressDetails().GetStateOrRegion(), "WI");
            Assert.AreEqual(oroResponseObject.GetBillingAddressDetails().GetPostalCode(), "54911");
            Assert.AreEqual(oroResponseObject.GetBillingAddressDetails().GetCountryCode(), "US");
            Assert.AreEqual(oroResponseObject.GetBillingAddressDetails().GetName(), "Christopher C. Conn");
            
            //Test Payment Descriptor
            Assert.AreEqual(oroResponseObject.GetAmazonBalanceFirst().ToString(), "False");
            Assert.AreNotEqual(oroResponseObject.GetAmazonBalanceFirst().ToString(), "true");
            Assert.AreEqual(oroResponseObject.GetFullDescriptor(), "Amazon Pay (Visa **11)");

            Assert.AreEqual(oroResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestGetPaymentDetails()
        {
            PaymentDetailsResponse testGetAllResponseDetails = new PaymentDetailsResponse();
            String rawOroResponse = loadTestFile("GetOrderReferenceDetails.xml");
            OrderReferenceDetailsResponse oroResponseObject = new OrderReferenceDetailsResponse(rawOroResponse);
            
            String rawAuthResponse = loadTestFile("GetAuthorizationDetails.xml");
            AuthorizeResponse authResponseObject = new AuthorizeResponse(rawAuthResponse);

            String rawCaptureResponse = loadTestFile("GetCaptureDetails.xml");
            CaptureResponse captureResponseObject = new CaptureResponse(rawCaptureResponse);


            String rawRefundResponse = loadTestFile("GetRefundDetails.xml");
            RefundResponse refundResponseObject = new RefundResponse(rawRefundResponse);
         
            testGetAllResponseDetails.PutOrderReferenceDetails(oroResponseObject.GetAmazonOrderReferenceId().ToString(), oroResponseObject);
            Assert.AreEqual(testGetAllResponseDetails.GetOrderReferenceDetails(), oroResponseObject);

            testGetAllResponseDetails.PutAuthorizationDetails(authResponseObject.GetAuthorizationReferenceId(), authResponseObject);
            foreach (var group in testGetAllResponseDetails.GetAuthorizationDetails())
            {
                Assert.AreEqual(group.Value.GetXml(), authResponseObject.GetXml());
            }
            
            testGetAllResponseDetails.PutCaptureDetails(captureResponseObject.GetCaptureReferenceId(), captureResponseObject);
            foreach (var group in testGetAllResponseDetails.GetCaptureDetails())
            {
                Assert.AreEqual(group.Value.GetXml(), captureResponseObject.GetXml());
            }

            testGetAllResponseDetails.PutRefundDetails(refundResponseObject.GetRefundReferenceId(), refundResponseObject);
            foreach (var group in testGetAllResponseDetails.GetRefundDetails())
            {
                Assert.AreEqual(group.Value.GetXml(), refundResponseObject.GetXml());
            }
        }

        [Test]
        public void TestLoggingMessageClient()
        {
            // Setting Simple Logger Adapter
            Common.Logging.LogManager.Adapter = new Common.Logging.Simple.TraceLoggerFactoryAdapter();

            // Create logger
            Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger<Client>();

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            // Test call to the API GetOrderReferenceDetails
            client = new Client(clientConfig);

            // Set Logger for Client
            client.Logger = logger;

            client.SetTimeStamp("0000");

            GetOrderReferenceDetailsRequest getOrderReferenceDetails = new GetOrderReferenceDetailsRequest();
            getOrderReferenceDetails.WithAmazonOrderReferenceId("test")
                .WithAccessToken("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");

            var response = client.GetOrderReferenceDetails(getOrderReferenceDetails);
            // Creating Request String
            string requestString = @"POST
                                mws.amazonservices.com
                                /OffAmazonPayments_Sandbox/2013-01-01
AWSAccessKeyId=test&Action=GetOrderReferenceDetails&AddressConsentToken=test&AmazonOrderReferenceId=test&MWSAuthToken=test&SellerId=test&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp=0000&Version=2013-01-01";

            // Setting up Expected Request
            string expectedRequest = @"POST
                                mws.amazonservices.com
                                /OffAmazonPayments_Sandbox/2013-01-01
AWSAccessKeyId=test&Action=GetOrderReferenceDetails&AddressConsentToken=test&AmazonOrderReferenceId=test&MWSAuthToken=test&SellerId=*REMOVED*&SignatureMethod=*REMOVED*&SignatureVersion=2&Timestamp=0000&Version=2013-01-01";

            // Test SanitizeData functionality for response 
            StringAssert.AreEqualIgnoringCase(expectedRequest, SanitizeData.SanitizeGivenData(requestString, SanitizeData.DataType.Request), "Actual Request after Sanitizing data is not was is Expected");

            // Setting up Expected response 
            string expectedresponse = @"<?xml version=""1.0""?><ErrorResponse xmlns=""http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01""><Error>*REMOVED*</Error><RequestID>*REMOVED*</RequestID></ErrorResponse>";

            // Test SanitizeData functionality for response 
            StringAssert.AreEqualIgnoringCase(expectedresponse, SanitizeData.SanitizeGivenData(response.GetXml(), SanitizeData.DataType.Response), "Actual Response after Sanitizing data is not was is Expected");

        }

        [Test]
        public void TestLoggingMessage_IpnHandler()
        {
            // Setting Simple Logger Adapter
            Common.Logging.LogManager.Adapter = new Common.Logging.Simple.TraceLoggerFactoryAdapter();

            // Create logger
            Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger<IpnHandler>();

            //Setting filePath to access test files 
            string filePath = @"TestFiles\AuthorizeNotification.json";

            // Extract AuthorizeNotification XML data from json
            var json = JObject.Parse(File.ReadAllText(filePath));
           
            string xmlData = JObject.Parse(json["Message"].ToString())["NotificationData"].ToString();
            
            NameValueCollection headers = new NameValueCollection { { "x-amz-sns-message-type", "Notification" } };

            IpnHandler ipnHandler = new IpnHandler(headers, File.ReadAllText(filePath), logger);
            Assert.AreEqual(ipnHandler.GetAuthorizeResponse().GetAuthorizationId(), new AuthorizeResponse(xmlData).GetAuthorizationId());
        }

        [Test]
        public void TestChargebackIPN()
        {
            //Setting filePath to access test files 
            string filePath_chargeback = @"TestFiles\ChargebackNotification.json";

            // Extract ChargebackNotification XML data from json
            var json = JObject.Parse(File.ReadAllText(filePath_chargeback));

            string xmlData = JObject.Parse(json["Message"].ToString())["NotificationData"].ToString();

            NameValueCollection headers = new NameValueCollection { { "x-amz-sns-message-type", "Notification" } };

            IpnHandler ipnHandler = new IpnHandler(headers, File.ReadAllText(filePath_chargeback));
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetAmazonChargebackId(), new ChargebackResponse(xmlData).GetAmazonChargebackId());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackAmount(), new ChargebackResponse(xmlData).GetChargebackAmount());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackAmountCurrencyCode(), new ChargebackResponse(xmlData).GetChargebackAmountCurrencyCode());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackReason(), new ChargebackResponse(xmlData).GetChargebackReason());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackState(), new ChargebackResponse(xmlData).GetChargebackState());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetCreationTimestamp(), new ChargebackResponse(xmlData).GetCreationTimestamp());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetAmazonCaptureId(), new ChargebackResponse(xmlData).GetAmazonCaptureId());
            Assert.AreEqual(ipnHandler.GetNotificationReferenceId().ToString(), "1111111-1111-11111-1111-11111EXAMPLE");
            Assert.AreEqual(ipnHandler.GetNotificationType().ToString(), "ChargebackDetailedNotification");
            Assert.AreEqual(ipnHandler.GetSellerId().ToString(), "A2AMR0CLHFUKIG");
            Assert.AreEqual(ipnHandler.GetMarketplaceId().ToString(), "A3BXB0YN3XH17H");
            Assert.AreEqual(ipnHandler.GetVersion().ToString(), "2013-01-01");
            Assert.AreEqual(ipnHandler.GetReleaseEnvironment().ToString(), "Sandbox");
        }

        [Test]
        public void TestChargebackIPN_Unauthorized()
        {
            //Setting filePath to access test files 
            string filePath_chargeback = @"TestFiles\ChargebackNotification_Unauthorized.json";

            // Extract ChargebackNotification XML data from json
            var json = JObject.Parse(File.ReadAllText(filePath_chargeback));

            string xmlData = JObject.Parse(json["Message"].ToString())["NotificationData"].ToString();

            NameValueCollection headers = new NameValueCollection { { "x-amz-sns-message-type", "Notification" } };

            IpnHandler ipnHandler = new IpnHandler(headers, File.ReadAllText(filePath_chargeback));
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetAmazonChargebackId(), new ChargebackResponse(xmlData).GetAmazonChargebackId());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackAmount(), new ChargebackResponse(xmlData).GetChargebackAmount());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackAmountCurrencyCode(), new ChargebackResponse(xmlData).GetChargebackAmountCurrencyCode());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackReason(), new ChargebackResponse(xmlData).GetChargebackReason());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetChargebackState(), new ChargebackResponse(xmlData).GetChargebackState());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetCreationTimestamp(), new ChargebackResponse(xmlData).GetCreationTimestamp());
            Assert.AreEqual(ipnHandler.GetChargebackResponse().GetAmazonCaptureId(), new ChargebackResponse(xmlData).GetAmazonCaptureId());
            Assert.AreEqual(ipnHandler.GetNotificationReferenceId().ToString(), "1111111-1111-11111-1111-11111EXAMPLE");
            Assert.AreEqual(ipnHandler.GetNotificationType().ToString(), "ChargebackDetailedNotification");
            Assert.AreEqual(ipnHandler.GetSellerId().ToString(), "A2AMR0CLHFUKIG");
            Assert.AreEqual(ipnHandler.GetMarketplaceId().ToString(), "A3BXB0YN3XH17H");
            Assert.AreEqual(ipnHandler.GetVersion().ToString(), "2013-01-01");
            Assert.AreEqual(ipnHandler.GetReleaseEnvironment().ToString(), "Sandbox");
        }

        [Test]
        public void TestSetOrderReferenceDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","SetOrderReferenceDetails"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"OrderReferenceAttributes.OrderTotal.Amount","100.05"},
                {"OrderReferenceAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderReferenceAttributes.PlatformId","test"},
                {"OrderReferenceAttributes.SellerNote","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.StoreName","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"OrderReferenceAttributes.RequestPaymentAuthorization", "true"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetOrderReferenceDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            SetOrderReferenceDetailsRequest setOrderReferenceDetails = new SetOrderReferenceDetailsRequest();
            setOrderReferenceDetails.WithMerchantId("test")
                .WithAmazonOrderReferenceId("test")
                .WithAmount(100.05m)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("test")
                .WithSellerNote("test")
                .WithSellerOrderId("test")
                .WithStoreName("test")
                .WithCustomInformation("test")
                .WithRequestPaymentAuthorization(true)
                .WithMWSAuthToken("test");
            
            client.SetOrderReferenceDetails(setOrderReferenceDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestSetOrderReferenceDetails_withCIIT()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("it-IT");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","SetOrderReferenceDetails"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"OrderReferenceAttributes.OrderTotal.Amount","123123.45"},
                {"OrderReferenceAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderReferenceAttributes.PlatformId","test"},
                {"OrderReferenceAttributes.SellerNote","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.StoreName","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"OrderReferenceAttributes.RequestPaymentAuthorization", "true"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetOrderReferenceDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            SetOrderReferenceDetailsRequest setOrderReferenceDetails = new SetOrderReferenceDetailsRequest();
            setOrderReferenceDetails.WithAmazonOrderReferenceId("test")
                .WithMerchantId("test")
                .WithAmount(decimal.Parse("123.123,45"))
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("test")
                .WithSellerNote("test")
                .WithSellerOrderId("test")
                .WithStoreName("test")
                .WithCustomInformation("test")
                .WithRequestPaymentAuthorization(true)
                .WithMWSAuthToken("test");

            client.SetOrderReferenceDetails(setOrderReferenceDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestSetOrderReferenceDetails_withCIUS()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","SetOrderReferenceDetails"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"OrderReferenceAttributes.OrderTotal.Amount","100.50"},
                {"OrderReferenceAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderReferenceAttributes.PlatformId","test"},
                {"OrderReferenceAttributes.SellerNote","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.StoreName","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"OrderReferenceAttributes.RequestPaymentAuthorization", "true"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetOrderReferenceDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            SetOrderReferenceDetailsRequest setOrderReferenceDetails = new SetOrderReferenceDetailsRequest();
            setOrderReferenceDetails.WithAmazonOrderReferenceId("test")
                .WithMerchantId("test")
                .WithAmount(decimal.Parse("100.50"))
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("test")
                .WithSellerNote("test")
                .WithSellerOrderId("test")
                .WithStoreName("test")
                .WithCustomInformation("test")
                .WithRequestPaymentAuthorization(true)
                .WithMWSAuthToken("test");

            client.SetOrderReferenceDetails(setOrderReferenceDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestSetOrderAttributes()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","SetOrderAttributes"},
                {"AmazonOrderReferenceId","Order #12345"},
                {"SellerId","test"},
                {"OrderAttributes.OrderTotal.Amount","100.05"},
                {"OrderAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderAttributes.PlatformId","A2STY9B5HPCDII"},
                {"OrderAttributes.SellerNote","testNote #12345"},
                {"OrderAttributes.SellerOrderAttributes.SellerOrderId","test-12345"},
                {"OrderAttributes.SellerOrderAttributes.StoreName","testStore #12345"},
                {"OrderAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"OrderAttributes.RequestPaymentAuthorization", "true"},
                {"OrderAttributes.PaymentServiceProviderAttributes.PaymentServiceProviderId", "A2STY9B5HPCDII"},
                {"OrderAttributes.PaymentServiceProviderAttributes.PaymentServiceProviderOrderId", "PSP-Order-Id"},
                {"OrderAttributes.SellerOrderAttributes.OrderItemCategories.OrderItemCategory.1", "Antiques"},
                {"OrderAttributes.SellerOrderAttributes.OrderItemCategories.OrderItemCategory.2", "Apparel"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetOrderReferenceDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            List<string> orderItemCategories = new List<string>();
            orderItemCategories.Add("Antiques");
            orderItemCategories.Add("Apparel");
            SetOrderAttributesRequest setOrderAttributes = new SetOrderAttributesRequest();
            setOrderAttributes.WithMerchantId("test")
                .WithPaymentServiceProviderId("A2STY9B5HPCDII")
                .WithPaymentServiceProviderOrderId("PSP-Order-Id")
                .WithOrderItemCategories(orderItemCategories)
                .WithAmazonOrderReferenceId("Order #12345")
                .WithAmount(100.05m)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("A2STY9B5HPCDII")
                .WithSellerNote("testNote #12345")
                .WithSellerOrderId("test-12345")
                .WithStoreName("testStore #12345")
                .WithCustomInformation("test")
                .WithRequestPaymentAuthorization(true);

            client.SetOrderAttributes(setOrderAttributes);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing SetOrderAttributes Response
            String rawResponse = loadTestFile("GetOrderReferenceDetails.xml");
            OrderReferenceDetailsResponse oroResponseObject = new OrderReferenceDetailsResponse(rawResponse);
            Assert.AreEqual(oroResponseObject.GetAmazonOrderReferenceId(), "S01-9111020-6707923");
            Assert.AreEqual(oroResponseObject.GetSellerNote(), "1st Amazon Pay OneTime Checkout Order");
            Assert.AreEqual(oroResponseObject.GetSellerOrderId(), "test-12345");
            Assert.AreEqual(oroResponseObject.GetStoreName(), "Java Cosmos Store");
            Assert.AreEqual(oroResponseObject.GetRequestPaymentAuthorization(), false);
            Assert.AreEqual(oroResponseObject.GetPaymentServiceProviderId(), "A2STY9B5HPCDII");
            Assert.AreEqual(oroResponseObject.GetPaymentServiceProviderOrderId(), "PSP-Order-Id");
            Assert.AreEqual(oroResponseObject.GetOrderItemCategories().Count, 2);

            Assert.AreEqual(oroResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestConfirmOrderReference()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","ConfirmOrderReference"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API ConfirmOrderReference
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            ConfirmOrderReferenceRequest confirmOrderReference = new ConfirmOrderReferenceRequest();
            confirmOrderReference.WithAmazonOrderReferenceId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");

            client.ConfirmOrderReference(confirmOrderReference);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing ConfirmOrderReference Response
            String rawResponse = loadTestFile("ConfirmOrderReference.xml");
            ConfirmOrderReferenceResponse confirmOrderResponseObject = new ConfirmOrderReferenceResponse(rawResponse);
            Assert.AreEqual(confirmOrderResponseObject.GetRequestId(), "f1f52572-a347-4f7a-a630-be066f3ba827");

            Assert.AreEqual(confirmOrderResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestCancelOrderReference()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CancelOrderReference"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"CancelationReason","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CancelOrderReference
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            CancelOrderReferenceRequest cancelOrderReference = new CancelOrderReferenceRequest();
            cancelOrderReference.WithAmazonOrderReferenceId("test")
                .WithCancelationReason("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            
            client.CancelOrderReference(cancelOrderReference);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing CancelOrderReference Response
            String rawResponse = loadTestFile("CancelOrderReference.xml");
            CancelOrderReferenceResponse cancelOrderResponseObject = new CancelOrderReferenceResponse(rawResponse);
            Assert.AreEqual(cancelOrderResponseObject.GetRequestId(), "0714c2dd-c3fa-45af-afc7-b48055cfd7bf");

            Assert.AreEqual(cancelOrderResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestCloseOrderReference()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CloseOrderReference"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"ClosureReason","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CloseOrderReference
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            CloseOrderReferenceRequest closeOrderReference = new CloseOrderReferenceRequest();
            closeOrderReference.WithAmazonOrderReferenceId("test")
                .WithClosureReason("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            
            client.CloseOrderReference(closeOrderReference);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing CloseOrderReference Response
            String rawResponse = loadTestFile("CloseOrderReference.xml");
            CloseOrderReferenceResponse closeOrderResponseObject = new CloseOrderReferenceResponse(rawResponse);
            Assert.AreEqual(closeOrderResponseObject.GetRequestId(), "5f20169b-7ab2-11df-bcef-d35615e2b044");

            Assert.AreEqual(closeOrderResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestCloseAuthorization()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CloseAuthorization"},
                {"SellerId","test"},
                {"AmazonAuthorizationId","test"},
                {"ClosureReason","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CloseAuthorization
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            CloseAuthorizationRequest closeAuthorization = new CloseAuthorizationRequest();
            closeAuthorization.WithAmazonAuthorizationId("test")
                .WithClosureReason("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");

            client.CloseAuthorization(closeAuthorization);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing CloseAuthorization Response
            String rawResponse = loadTestFile("CloseOrderReference.xml");
            CloseAuthorizationResponse closeAuthorizationResponseObject = new CloseAuthorizationResponse(rawResponse);
            Assert.AreEqual(closeAuthorizationResponseObject.GetRequestId(), "5f20169b-7ab2-11df-bcef-d35615e2b044");

            Assert.AreEqual(closeAuthorizationResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestAuthorizeWithCaptureNowTrue()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","Authorize"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"AuthorizationAmount.Amount","100.00"},
                {"AuthorizationAmount.CurrencyCode","USD"},
                {"AuthorizationReferenceId","test"},
                {"CaptureNow","true"},
                {"SellerAuthorizationNote","test"},
                {"TransactionTimeout","5"},
                {"SoftDescriptor","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Authorize
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            AuthorizeRequest authorize = new AuthorizeRequest();
            authorize.WithAmazonOrderReferenceId("test")
                .WithAmount(100.00m)
                .WithAuthorizationReferenceId("test")
                .WithCaptureNow(true)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerAuthorizationNote("test")
                .WithTransactionTimeout(5)
                .WithSoftDescriptor("test");
            
            client.Authorize(authorize);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing Authorize Response
            String rawResponse = loadTestFile("AuthorizeResponse.xml");
            AuthorizeResponse authorizeResponseObject = new AuthorizeResponse(rawResponse);
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationAmount(), 1.00);
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationAmountCurrencyCode(), "USD");
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationFee(),0.00 );
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationFeeCurrencyCode(), "USD");
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationId(), "S01-9821095-1837200-A041953");
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationReferenceId(), "asdcdsd5iiiii");
            Assert.AreEqual(authorizeResponseObject.GetAuthorizationState(), "Closed");
            Assert.AreEqual(authorizeResponseObject.GetCapturedAmount(), 0);
            Assert.AreEqual(authorizeResponseObject.GetCapturedAmountCurrencyCode(), "USD");
            Assert.AreEqual(authorizeResponseObject.GetCaptureNow(), true);
            Assert.AreEqual(authorizeResponseObject.GetSellerAuthorizationNote(), "testing");
            Assert.AreEqual(authorizeResponseObject.GetRequestId(), "adabc99d-8351-48dc-acef-1bc049215f55");

            Assert.AreEqual(authorizeResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestAuthorizeWithCaptureNowFalse()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","Authorize"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"AuthorizationAmount.Amount","100.00"},
                {"AuthorizationAmount.CurrencyCode","USD"},
                {"AuthorizationReferenceId","test"},
                {"CaptureNow","false"},
                {"SellerAuthorizationNote","test"},
                {"TransactionTimeout","5"},
                {"SoftDescriptor","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Authorize
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            AuthorizeRequest authorize = new AuthorizeRequest();
            authorize.WithAmazonOrderReferenceId("test")
                .WithAmount(100.00m)
                .WithAuthorizationReferenceId("test")
                .WithCaptureNow(false)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerAuthorizationNote("test")
                .WithTransactionTimeout(5)
                .WithSoftDescriptor("test");

            client.Authorize(authorize);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestAuthorizeWithNoCaptureNow()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","Authorize"},
                {"SellerId","test"},
                {"AmazonOrderReferenceId","test"},
                {"AuthorizationAmount.Amount","100.00"},
                {"AuthorizationAmount.CurrencyCode","USD"},
                {"AuthorizationReferenceId","test"},
                {"SellerAuthorizationNote","test"},
                {"TransactionTimeout","5"},
                {"SoftDescriptor","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Authorize
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            AuthorizeRequest authorize = new AuthorizeRequest();
            authorize.WithAmazonOrderReferenceId("test")
                .WithAmount(100.00m)
                .WithAuthorizationReferenceId("test")
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerAuthorizationNote("test")
                .WithTransactionTimeout(5)
                .WithSoftDescriptor("test");

            client.Authorize(authorize);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetAuthorizationDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetAuthorizationDetails"},
                {"SellerId","test"},
                {"AmazonAuthorizationId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetAuthorizationDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            GetAuthorizationDetailsRequest getAuthorizationDetails = new GetAuthorizationDetailsRequest();
            getAuthorizationDetails.WithAmazonAuthorizationId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            
            client.GetAuthorizationDetails(getAuthorizationDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCapture()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","Capture"},
                {"SellerId","test"},
                {"AmazonAuthorizationId","test"},
                {"CaptureAmount.Amount","100.02"},
                {"CaptureAmount.CurrencyCode","USD"},
                {"CaptureReferenceId","test"},
                {"SellerCaptureNote","test"},
                {"SoftDescriptor","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Capture
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            CaptureRequest capture = new CaptureRequest();
            capture.WithAmazonAuthorizationId("test")
                .WithAmount(100.02m)
                .WithCaptureReferenceId("test")
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerCaptureNote("test")
                .WithSoftDescriptor("test");
            client.Capture(capture);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing Authorize Response
            String rawResponse = loadTestFile("CaptureResponse.xml");
            CaptureResponse captureResponseObject = new CaptureResponse(rawResponse);
            Assert.AreEqual(captureResponseObject.GetCaptureAmount(), 1.00);
            Assert.AreEqual(captureResponseObject.GetCaptureAmountCurrencyCode(), "USD");
            Assert.AreEqual(captureResponseObject.GetCaptureFee(), 0.00);
            Assert.AreEqual(captureResponseObject.GetCaptureFeeCurrencyCode(), "USD");
            Assert.AreEqual(captureResponseObject.GetCaptureId(), "S01-9821095-1837200-C053432");
            Assert.AreEqual(captureResponseObject.GetCaptureState(), "Completed");
            Assert.AreEqual(captureResponseObject.GetRequestId(), "1ec2813f-3d33-4b3a-a198-a25cd608310d");

            Assert.AreEqual(captureResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestGetCaptureDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetCaptureDetails"},
                {"SellerId","test"},
                {"AmazonCaptureId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetCaptureDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            GetCaptureDetailsRequest getCaptureDetails = new GetCaptureDetailsRequest();
            getCaptureDetails.WithAmazonCaptureId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");

            //Test CaptureDetails Request
            client.GetCaptureDetails(getCaptureDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Test CaptureDetails Response
            String rawCapResponse = loadTestFile("GetCaptureDetails_MultiCurrency.xml");
            CaptureResponse capResponseObject = new CaptureResponse(rawCapResponse);
            Assert.AreEqual(capResponseObject.GetCaptureId(), "S02-7423235-4925359-C052508");
            Assert.AreEqual(capResponseObject.GetCaptureAmount(), 0.99m);
            Assert.AreNotEqual(capResponseObject.GetCaptureAmount(), "0.99"); // I18N/culture test
            Assert.AreEqual(capResponseObject.GetCaptureAmountCurrencyCode(), "CHF");
            Assert.AreEqual(capResponseObject.GetCaptureReferenceId(), "7a087b12a3cb4d0ba3cb4230aa953de4");
            Assert.AreEqual(capResponseObject.GetCaptureFee(), 0.00m);
            Assert.AreNotEqual(capResponseObject.GetCaptureFee(), "0.00"); // I18N/culture test
            Assert.AreEqual(capResponseObject.GetCaptureFeeCurrencyCode(), "EUR");
            Assert.AreEqual(capResponseObject.GetSoftDescriptor(), "AMZ*Matt's Test Stor");
            Assert.AreEqual(capResponseObject.GetSellerCaptureNote(), null);
            Assert.AreEqual(capResponseObject.GetCaptureState(), "Completed");
            Assert.AreEqual(capResponseObject.GetRequestId(), "a17ee562-9a97-4b22-8487-20e8e7230639");

            // Test multi-currency specific fields
            Assert.AreEqual(capResponseObject.GetConvertedAmount(), 1.88m);
            Assert.AreNotEqual(capResponseObject.GetConvertedAmount(), "1.88"); // I18N/culture test
            Assert.AreEqual(capResponseObject.GetConvertedAmountCurrencyCode(), "EUR");
            Assert.AreEqual(capResponseObject.GetConversionRate(), 1.1297854087m);
            
            Assert.AreEqual(capResponseObject.GetXml(), rawCapResponse);
        }

        [Test]
        public void TestRefund()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","Refund"},
                {"SellerId","test"},
                {"AmazonCaptureId","test"},
                {"RefundReferenceId","test"},
                {"RefundAmount.Amount","10.05"},
                {"RefundAmount.CurrencyCode","USD"},
                {"SellerRefundNote","test"},
                {"SoftDescriptor","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API Refund
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            RefundRequest refund = new RefundRequest();
            refund.WithAmazonCaptureId("test")
                .WithAmount(10.05m)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithRefundReferenceId("test")
                .WithSellerRefundNote("test")
                .WithSoftDescriptor("test");
            client.Refund(refund);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing Refund Response
            String rawResponse = loadTestFile("RefundResponse.xml");
            RefundResponse refundResponseObject = new RefundResponse(rawResponse);
            Assert.AreEqual(refundResponseObject.GetAmazonRefundId(), "S01-5695290-1354077-R072290");
            Assert.AreEqual(refundResponseObject.GetRefundType(), "SellerInitiated");
            Assert.AreEqual(refundResponseObject.GetRefundAmount(), 0.50m);
            Assert.AreEqual(refundResponseObject.GetRefundAmountCurrencyCode(), "USD");
            Assert.AreEqual(refundResponseObject.GetRefundFee(), 0.00m);
            Assert.AreEqual(refundResponseObject.GetRefundFeeCurrencyCode(), "USD");
            Assert.AreEqual(refundResponseObject.GetRefundState(), "Pending");
            Assert.AreEqual(refundResponseObject.GetReasonCode(), null);
            Assert.AreEqual(refundResponseObject.GetReasonDescription(), null);
            Assert.AreEqual(refundResponseObject.GetSoftDescriptor(), "AMZ*test");

            Assert.AreEqual(refundResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestGetRefundDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetRefundDetails"},
                {"SellerId","test"},
                {"AmazonRefundId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetRefundDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            GetRefundDetailsRequest getRefundDetails = new GetRefundDetailsRequest();
            getRefundDetails.WithAmazonRefundId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");

            //Test RefundDetails Request
            client.GetRefundDetails(getRefundDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Test RefundDetails Response
            String rawRefResponse = loadTestFile("GetRefundDetails_MultiCurrency.xml");
            RefundResponse refundResponseObject = new RefundResponse(rawRefResponse);
            Assert.AreEqual(refundResponseObject.GetAmazonRefundId(), "S02-8274313-3487267-R019346");
            Assert.AreEqual(refundResponseObject.GetRefundType(), "SellerInitiated");
            Assert.AreEqual(refundResponseObject.GetRefundAmount(), 1.33m);
            Assert.AreNotEqual(refundResponseObject.GetRefundAmount(), "1,33");  // I18N/culture test
            Assert.AreEqual(refundResponseObject.GetRefundAmountCurrencyCode(), "NOK");
            Assert.AreEqual(refundResponseObject.GetRefundFee(), 0.00m);
            Assert.AreNotEqual(refundResponseObject.GetRefundFee(), "0,00"); //// I18N/culture test
            Assert.AreEqual(refundResponseObject.GetRefundFeeCurrencyCode(), "EUR");
            Assert.AreEqual(refundResponseObject.GetRefundState(), "Completed");
            Assert.AreEqual(refundResponseObject.GetReasonCode(), null);
            Assert.AreEqual(refundResponseObject.GetReasonDescription(), null);
            Assert.AreEqual(refundResponseObject.GetSoftDescriptor(), "AMZ*Matt's Test Stor");

            // The three new multi-currency specific fields
            Assert.AreEqual(refundResponseObject.GetConvertedAmount(), 1.03m);
            Assert.AreNotEqual(refundResponseObject.GetConvertedAmount(), "1.03"); // I18N/culture test
            Assert.AreEqual(refundResponseObject.GetConvertedAmountCurrencyCode(), "EUR");
            Assert.AreEqual(refundResponseObject.GetConversionRate(), 9.9248293483m);

            Assert.AreEqual(refundResponseObject.GetRequestId(), "3b14705b-0a11-4b05-98d3-eb62c9bf1d22");
            Assert.AreEqual(refundResponseObject.GetXml(), rawRefResponse);
        }

        [Test]
        public void TestGetServiceStatus()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetServiceStatus"},
                {"SellerId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetServiceStatus
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            GetServiceStatusRequest getServicetatus = new GetServiceStatusRequest();
            getServicetatus.WithMerchantId("test")
                .WithMWSAuthToken("test");
            client.GetServiceStatus(getServicetatus);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing GetServiceStatus Response
            String rawResponse = loadTestFile("GetServiceStatusResponse.xml");
            GetServiceStatusResponse getServiceStatusResponseObject = new GetServiceStatusResponse(rawResponse);
            Assert.AreEqual(getServiceStatusResponseObject.GetStatus(), "GREEN");
            Assert.AreEqual(getServiceStatusResponseObject.GetRequestId(), "93437336-70dd-4359-b453-f13a90dccb99");

            Assert.AreEqual(getServiceStatusResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestCreateOrderReferenceForIdWithConfirmNowTrue()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CreateOrderReferenceForId"},
                {"SellerId","test"},
                {"Id","test"},
                {"IdType","test"},
                {"InheritShippingAddress","true"},
                {"ConfirmNow","true"},
                {"OrderReferenceAttributes.OrderTotal.Amount","100.05"},
                {"OrderReferenceAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderReferenceAttributes.PlatformId","test"},
                {"OrderReferenceAttributes.SellerNote","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.StoreName","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CreateOrderReferenceForId
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            CreateOrderReferenceForIdRequest createOrderReferenceForId = new CreateOrderReferenceForIdRequest();
            createOrderReferenceForId.WithConfirmNow(true)
                .WithAmount(100.05m)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithCustomInformation("test")
                .WithId("test")
                .WithIdType("test")
                .WithInheritShippingAddress(true)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithPlatformId("test")
                .WithSellerNote("test")
                .WithSellerOrderId("test")
                .WithStoreName("test");
            client.CreateOrderReferenceForId(createOrderReferenceForId);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCreateOrderReferenceForIdWithConfirmNowFalse()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CreateOrderReferenceForId"},
                {"SellerId","test"},
                {"Id","test"},
                {"IdType","test"},
                {"InheritShippingAddress","true"},
                {"ConfirmNow","false"},
                {"OrderReferenceAttributes.OrderTotal.Amount","100.05"},
                {"OrderReferenceAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderReferenceAttributes.PlatformId","test"},
                {"OrderReferenceAttributes.SellerNote","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.StoreName","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CreateOrderReferenceForId
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            CreateOrderReferenceForIdRequest createOrderReferenceForId = new CreateOrderReferenceForIdRequest();
            createOrderReferenceForId.WithConfirmNow(false)
                .WithAmount(100.05m)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithCustomInformation("test")
                .WithId("test")
                .WithIdType("test")
                .WithInheritShippingAddress(true)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithPlatformId("test")
                .WithSellerNote("test")
                .WithSellerOrderId("test")
                .WithStoreName("test");
            client.CreateOrderReferenceForId(createOrderReferenceForId);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCreateOrderReferenceForIdWithNoConfirmNow()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CreateOrderReferenceForId"},
                {"SellerId","test"},
                {"Id","test"},
                {"IdType","test"},
                {"InheritShippingAddress","true"},
                {"OrderReferenceAttributes.OrderTotal.Amount","100.05"},
                {"OrderReferenceAttributes.OrderTotal.CurrencyCode","USD"},
                {"OrderReferenceAttributes.PlatformId","test"},
                {"OrderReferenceAttributes.SellerNote","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.StoreName","test"},
                {"OrderReferenceAttributes.SellerOrderAttributes.CustomInformation","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CreateOrderReferenceForId
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            CreateOrderReferenceForIdRequest createOrderReferenceForId = new CreateOrderReferenceForIdRequest();
            createOrderReferenceForId.WithAmount(100.05m)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithCustomInformation("test")
                .WithId("test")
                .WithIdType("test")
                .WithInheritShippingAddress(true)
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithPlatformId("test")
                .WithSellerNote("test")
                .WithSellerOrderId("test")
                .WithStoreName("test");
            client.CreateOrderReferenceForId(createOrderReferenceForId);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestGetBillingAgreementDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetBillingAgreementDetails"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"AddressConsentToken","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetBillingAgreementDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            GetBillingAgreementDetailsRequest getBillingAgreement = new GetBillingAgreementDetailsRequest();
            getBillingAgreement.WithaddressConsentToken("test")
                .WithAmazonBillingAgreementId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            client.GetBillingAgreementDetails(getBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing BillingAgreementDetails Response
            String rawResponse = loadTestFile("BillingAgreementDetailsResponse.xml");
            BillingAgreementDetailsResponse billingAgreementDetailsResponseObject = new BillingAgreementDetailsResponse(rawResponse);
            Assert.AreEqual(billingAgreementDetailsResponseObject.GetStateOrRegion(), "BC");
            Assert.AreEqual(billingAgreementDetailsResponseObject.GetAmazonBillingAgreementId(), "C01-3925266-2250830");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetAddressLine1(), "999 Canada Place 140");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetAmountLimitPerTimePeriod(), 500.00);
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetAmountLimitPerTimePeriodCurrencyCode(), "USD");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetBillingAgreementState(), "Draft");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetBuyerName(), "Test Buyer");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetCurrentRemainingBalanceAmount(), 500.00);
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetCurrentRemainingBalanceCurrencyCode(), "USD");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetCity(), "Vancouver");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetCountryCode(), "CA");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetEmail(), "testbuyer2@amazon.com");
             Assert.AreEqual(billingAgreementDetailsResponseObject.GetRequestId(), "d69e8d60-3682-43d7-bf5e-e2ef64dc685e");

            Assert.AreEqual(billingAgreementDetailsResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestSetBillingAgreementDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","SetBillingAgreementDetails"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"BillingAgreementAttributes.PlatformId","test"},
                {"BillingAgreementAttributes.SellerNote","test"},
                {"BillingAgreementAttributes.SellerBillingAgreementAttributes.SellerBillingAgreementId","test"},
                {"BillingAgreementAttributes.SellerBillingAgreementAttributes.CustomInformation","test"},
                {"BillingAgreementAttributes.SellerBillingAgreementAttributes.StoreName","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API SetBillingAgreementDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            SetBillingAgreementDetailsRequest setBillingAgreementDetails = new SetBillingAgreementDetailsRequest();
            setBillingAgreementDetails.WithAmazonBillingAgreementId("test")
                .WithCustomInformation("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithPlatformId("test")
                .WithSellerBillingAgreementId("test")
                .WithSellerNote("test")
                .WithStoreName("test");
            client.SetBillingAgreementDetails(setBillingAgreementDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestConfirmBillingAgreement()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","ConfirmBillingAgreement"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API ConfirmBillingAgreement
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            ConfirmBillingAgreementRequest confirmBillingAgreement = new ConfirmBillingAgreementRequest();
            confirmBillingAgreement.WithAmazonBillingreementId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            client.ConfirmBillingAgreement(confirmBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing ConfirmBillingAgrrement Response
            String rawResponse = loadTestFile("ConfirmBillingAgreementResponse.xml");
            ConfirmBillingAgreementResponse confirmBillingAgreementResponseObject = new ConfirmBillingAgreementResponse(rawResponse);
            Assert.AreEqual(confirmBillingAgreementResponseObject.GetRequestId(), "3d1db999-b790-47bb-87d3-9c673c38a1ed");

            Assert.AreEqual(confirmBillingAgreementResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestValidateBillingAgreement()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","ValidateBillingAgreement"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API ValidateBillingAgreement
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            ValidateBillingAgreementRequest validateBillingAgreement = new ValidateBillingAgreementRequest();
            validateBillingAgreement.WithAmazonBillingAgreementId("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            client.ValidateBillingAgreement(validateBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing ValidateBillingAgrrement Response
            String rawResponse = loadTestFile("ValidateBillingAgreementResponse.xml");
            ValidateBillingAgreementResponse validateBillingAgreementResponseObject = new ValidateBillingAgreementResponse(rawResponse);
            Assert.AreEqual(validateBillingAgreementResponseObject.GetBillingAgreementState(), "Open");
            Assert.AreEqual(validateBillingAgreementResponseObject.GetValidationResult(), "Success");
            Assert.AreEqual(validateBillingAgreementResponseObject.GetRequestId(), "0f48a4e0-2a7c-4036-9a8a-339e419fd53f");

            Assert.AreEqual(validateBillingAgreementResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestAuthorizeOnBillingAgreementWithDefaultInheritShippingAddress()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","AuthorizeOnBillingAgreement"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"AuthorizationReferenceId","test"},
                {"AuthorizationAmount.Amount","100.05"},
                {"AuthorizationAmount.CurrencyCode","USD"},
                {"SellerAuthorizationNote","test"},
                {"TransactionTimeout","5"},
                {"CaptureNow","true"},
                {"SoftDescriptor","test"},
                {"SellerNote","test"},
                {"PlatformId","test"},
                {"SellerOrderAttributes.CustomInformation","test"},
                {"SellerOrderAttributes.SellerOrderId","test"},
                {"SellerOrderAttributes.StoreName","test"},
                {"InheritShippingAddress","true"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API AuthorizeOnBillingAgreement
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            AuthorizeOnBillingAgreementRequest authorizeOnBillingAgreement = new AuthorizeOnBillingAgreementRequest();
            authorizeOnBillingAgreement.WithAmazonBillingAgreementId("test")
                .WithAmount(100.05m)
                .WithAuthorizationReferenceId("test")
                .WithCaptureNow(true)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("test")
                .WithCustomInformation("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerAuthorizationNote("test")
                .WithSellerNote("test")
                .WithTransactionTimeout(5)
                .WithSoftDescriptor("test")
                .WithStoreName("test")
                .WithSellerOrderId("test")
                .WithTransactionTimeout(5);
            client.AuthorizeOnBillingAgreement(authorizeOnBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestAuthorizeOnBillingAgreementWithInheritShippingAddressTrue()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","AuthorizeOnBillingAgreement"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"AuthorizationReferenceId","test"},
                {"AuthorizationAmount.Amount","100.05"},
                {"AuthorizationAmount.CurrencyCode","USD"},
                {"SellerAuthorizationNote","test"},
                {"TransactionTimeout","5"},
                {"CaptureNow","true"},
                {"SoftDescriptor","test"},
                {"SellerNote","test"},
                {"PlatformId","test"},
                {"SellerOrderAttributes.CustomInformation","test"},
                {"SellerOrderAttributes.SellerOrderId","test"},
                {"SellerOrderAttributes.StoreName","test"},
                {"InheritShippingAddress","true"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API AuthorizeOnBillingAgreement
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            AuthorizeOnBillingAgreementRequest authorizeOnBillingAgreement = new AuthorizeOnBillingAgreementRequest();
            authorizeOnBillingAgreement.WithAmazonBillingAgreementId("test")
                .WithAmount(100.05m)
                .WithAuthorizationReferenceId("test")
                .WithCaptureNow(true)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("test")
                .WithCustomInformation("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerAuthorizationNote("test")
                .WithSellerNote("test")
                .WithTransactionTimeout(5)
                .WithSoftDescriptor("test")
                .WithStoreName("test")
                .WithSellerOrderId("test")
                .WithTransactionTimeout(5)
                .WithInheritShippingAddress(true);
            client.AuthorizeOnBillingAgreement(authorizeOnBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestAuthorizeOnBillingAgreementWithInheritShippingAddressFalse()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","AuthorizeOnBillingAgreement"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"AuthorizationReferenceId","test"},
                {"AuthorizationAmount.Amount","100.05"},
                {"AuthorizationAmount.CurrencyCode","USD"},
                {"SellerAuthorizationNote","test"},
                {"TransactionTimeout","5"},
                {"CaptureNow","true"},
                {"SoftDescriptor","test"},
                {"SellerNote","test"},
                {"PlatformId","test"},
                {"SellerOrderAttributes.CustomInformation","test"},
                {"SellerOrderAttributes.SellerOrderId","test"},
                {"SellerOrderAttributes.StoreName","test"},
                {"InheritShippingAddress","false"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API AuthorizeOnBillingAgreement
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            AuthorizeOnBillingAgreementRequest authorizeOnBillingAgreement = new AuthorizeOnBillingAgreementRequest();
            authorizeOnBillingAgreement.WithAmazonBillingAgreementId("test")
                .WithAmount(100.05m)
                .WithAuthorizationReferenceId("test")
                .WithCaptureNow(true)
                .WithCurrencyCode(Regions.currencyCode.USD)
                .WithPlatformId("test")
                .WithCustomInformation("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test")
                .WithSellerAuthorizationNote("test")
                .WithSellerNote("test")
                .WithTransactionTimeout(5)
                .WithSoftDescriptor("test")
                .WithStoreName("test")
                .WithSellerOrderId("test")
                .WithTransactionTimeout(5)
                .WithInheritShippingAddress(false);
            client.AuthorizeOnBillingAgreement(authorizeOnBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);
        }

        [Test]
        public void TestCloseBillingAgreement()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","CloseBillingAgreement"},
                {"SellerId","test"},
                {"AmazonBillingAgreementId","test"},
                {"ClosureReason","test"},
                {"MWSAuthToken","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API CloseBillingAgreement
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            CloseBillingAgreementRequest closeBillingAgreement = new CloseBillingAgreementRequest();
            closeBillingAgreement.WithAmazonBillingAgreementId("test")
                .WithClosureReason("test")
                .WithMerchantId("test")
                .WithMWSAuthToken("test");
            client.CloseBillingAgreement(closeBillingAgreement);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing CloseBillingAgreement Response
            String rawResponse = loadTestFile("CloseBillingAgreementResponse.xml");
            CloseBillingAgreementResponse closeBillingAgreementResponseObject = new CloseBillingAgreementResponse(rawResponse);
            Assert.AreEqual(closeBillingAgreementResponseObject.GetRequestId(), "7541230f-e349-4180-a4ac-ba9f2cf6ac79");

            Assert.AreEqual(closeBillingAgreementResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestCharge()
        {
            Client client = new Client(clientConfig);
            try
            {
                ChargeRequest charge = new ChargeRequest();
                charge.WithAmazonReferenceId("S01-TEST")
                    .WithAmount(100.05m)
                    .WithCaptureNow(true)
                    .WithChargeNote("test")
                    .WithChargeOrderId("test")
                    .WithChargeReferenceId("test")
                    .WithCurrencyCode(Regions.currencyCode.USD)
                    .WithCustomInformation("test")
                    .WithInheritShippingAddress(true)
                    .WithMerchantId("test")
                    .WithMWSAuthToken("test")
                    .WithPlatformId("test")
                    .WithSoftDescriptor("test")
                    .WithStoreName("test")
                    .WithTransactionTimeout(5);
                client.Charge(charge);
            }
            catch (NullReferenceException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "state value is null", RegexOptions.IgnoreCase));
            }
            try
            {
                client = new Client(clientConfig);
                ChargeRequest charge = new ChargeRequest();
                charge.WithAmazonReferenceId("");
                client.Charge(charge);
            }
            catch (MissingFieldException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Amazon Reference ID is a required field and should be a Order Reference ID / Billing Agreement ID", RegexOptions.IgnoreCase));
            }

            try
            {
                client = new Client(clientConfig);
                ChargeRequest charge = new ChargeRequest();
                charge.WithAmazonReferenceId("T01");
                client.Charge(charge);
            }
            catch (InvalidDataException expected)
            {
                Assert.IsTrue(Regex.IsMatch(expected.ToString(), "Invalid Amazon Reference ID", RegexOptions.IgnoreCase));
            }
        }

        [Test]
        public void TestGetProviderCreditDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetProviderCreditDetails"},
                {"SellerId","test"},            
                {"MWSAuthToken","test"},
                {"AmazonProviderCreditId","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetProviderCreditDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            GetProviderCreditDetailsRequest getProviderCreditDetails = new GetProviderCreditDetailsRequest();
            getProviderCreditDetails
                 .WithMerchantId("test")
                 .WithAmazonProviderCreditId("test")
                 .WithMWSAuthToken("test");
            client.GetProviderCreditDetails(getProviderCreditDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing GetProviderCreditDetails Response
            String rawResponse = loadTestFile("GetProviderCreditDetailsResponse.xml");
            GetProviderCreditDetailsResponse getProviderCreditDetailsResponseObject = new GetProviderCreditDetailsResponse(rawResponse);
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetAmazonProviderCreditId(), "S01-2117025-2155793-P045170");
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetCreditAmount(), 1.00);
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetCreditAmountCurrencyCode(), "USD");
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetCreditReferenceId(), "S01-2117025-2155793nesasdh");
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetCreditStatus(), "Closed");
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetCreditReversalAmount(), 1.00);
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetCreditReversalAmountCurrencyCode(), "USD");
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetSellerId(), "TEST_SELLER_ID");
            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetRequestId(), "21162350-7135-46ae-aa20-68d5361cef17");

            Assert.AreEqual(getProviderCreditDetailsResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestGetProviderCreditReversalDetails()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetProviderCreditReversalDetails"},
                {"SellerId","test"},            
                {"MWSAuthToken","test"},
                {"AmazonProviderCreditReversalId","test"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("0000");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetProviderCreditReversalDetails
            client = new Client(clientConfig);
            client.SetTimeStamp("0000");
            GetProviderCreditReversalDetailsRequest getProviderCreditReversalDetails = new GetProviderCreditReversalDetailsRequest();
            getProviderCreditReversalDetails
                 .WithAmazonProviderCreditReversalId("test")
                 .WithMerchantId("test")
                 .WithMWSAuthToken("test");
            client.GetProviderCreditReversalDetails(getProviderCreditReversalDetails);
            IDictionary<string, string> apiParametersDict = client.GetParameters();

            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing GetProviderCreditReversalDetails Response
            String rawResponse = loadTestFile("GetProviderCreditReversalDetailsResponse.xml");
            GetProviderCreditReversalDetailsResponse getProviderCreditReversalDetailsResponseObject = new GetProviderCreditReversalDetailsResponse(rawResponse);
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetAmazonProviderCreditReversalId(), "S01-2117025-2155793-P045170");
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetCreditReversalAmount(), 1.00);
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetCreditReversalAmountCurrencyCode(), "USD");
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetCreditReversalReferenceId(), "S01-2117025-2155793nesasdh");
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetCreditReversalStatus(), "Closed");
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetReasonCode(), "MaxAmountReversed");
            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetRequestId(), "10a7736b-bb9b-447c-9be1-4f5e76166e48");

            Assert.AreEqual(getProviderCreditReversalDetailsResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestGetMerchantAccountStatus()
        {
            Dictionary<string, string> expectedParameters = new Dictionary<string, string>()
            {
                {"Action","GetMerchantAccountStatus"},
                {"SellerId","A2AMR0CLHFUKIG"},
                {"MWSAuthToken","test123"}
            };

            // Test direct call to CalculateSignatureAndParametersToString
            Client client = new Client(clientConfig);
            client.SetTimeStamp("2018-09-27T02:18:33.408Z");

            MethodInfo method = GetMethod("CalculateSignatureAndParametersToString");
            method.Invoke(client, new object[] { expectedParameters }).ToString();
            IDictionary<string, string> expectedParamsDict = client.GetParameters();

            // Test call to the API GetMerchantAccountStatus
            client = new Client(clientConfig);
            client.SetTimeStamp("2018-09-27T02:18:33.408Z");
            GetMerchantAccountStatusRequest getMerchantAccountStatus = new GetMerchantAccountStatusRequest();
            getMerchantAccountStatus.WithMerchantId("A2AMR0CLHFUKIG")
                .WithMWSAuthToken("test123");

            client.GetMerchantAccountStatus(getMerchantAccountStatus);
            IDictionary<string, string> apiParametersDict = client.GetParameters();
            CollectionAssert.AreEqual(apiParametersDict, expectedParamsDict);

            //Testing GetMerchantAccountStatus Response
            String rawResponse = loadTestFile("GetMerchantAccountStatusResponse.xml");
            GetMerchantAccountStatusResponse getMerchantAccountStatusResponseObject = new GetMerchantAccountStatusResponse(rawResponse);
            Assert.AreEqual(getMerchantAccountStatusResponseObject.GetRequestId(), "51eaf2d5-0b9c-4630-b0e7-1ef61582076a");

            Assert.AreEqual(getMerchantAccountStatusResponseObject.GetXml(), rawResponse);
        }

        [Test]
        public void TestGetUserInfo()
        {
                Enum emptyRegion = null;
                Client client = new Client(clientConfig);
                // Exeption for Null "Region" value
                Assert.Throws<NullReferenceException>(()=> clientConfig.WithRegion(emptyRegion));
                // Exeption for Null value
                Assert.Throws<NullReferenceException>(() => client.GetUserInfo(null));
                // Check for invalid Access token
                Assert.IsTrue(Regex.IsMatch(client.GetUserInfo("Atza"),"invalid_token",RegexOptions.IgnoreCase));          
        }

        [Test]
        public void Test500or503()
        {
            try
            {
                Client client = new Client(clientConfig);

                string url = "https://dsenetsdk.ant.amazon.com/500error/500error.aspx";

                client.SetMwsTestUrl(url);
                client.SetTimeStamp("0000");

                CloseBillingAgreementRequest closeBillingAgreement = new CloseBillingAgreementRequest();
                closeBillingAgreement.WithAmazonBillingAgreementId("test")
                    .WithClosureReason("test")
                    .WithMerchantId("test")
                    .WithMWSAuthToken("test");
                client.CloseBillingAgreement(closeBillingAgreement);
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

            string jsonResponse = ResponseParser.ToJson(response["ResponseBody"].ToString());
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

            Dictionary<string, object> returnDictResponse = ResponseParser.ToDict(response["ResponseBody"].ToString());

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

        /// <summary>
        /// Get the private method of the Client class for testing using the Reflection method
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private MethodInfo GetMethod(string methodName)
        {
            Client client = new Client(clientConfig);
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