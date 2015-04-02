/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Off Amazon Payments Service CSharp Library
 *  API Version: 2013-01-01
 * 
 */


using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;



namespace OffAmazonPaymentsServiceSampleLibrary
{
    public class ValidateBillingAgreementSample : SampleBase
    {
        public static ValidateBillingAgreementResponse InvokeValidateBillingAgreement(IOffAmazonPaymentsService service, ValidateBillingAgreementRequest request)
        {
            ValidateBillingAgreementResponse response = null;
            try
            {
                response = service.ValidateBillingAgreement(request);

                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();

                Console.WriteLine("        ValidateBillingAgreementResponse");
                if (response.IsSetValidateBillingAgreementResult())
                {
                    Console.WriteLine("            ValidateBillingAgreementResult");
                    ValidateBillingAgreementResult validateBillingAgreementResult = response.ValidateBillingAgreementResult;
                    if (validateBillingAgreementResult.IsSetValidationResult())
                    {
                        Console.WriteLine("                ValidationResult");
                        Console.WriteLine("                    {0}", validateBillingAgreementResult.ValidationResult);
                    }
                    if (validateBillingAgreementResult.IsSetFailureReasonCode())
                    {
                        Console.WriteLine("                FailureReasonCode");
                        Console.WriteLine("                    {0}", validateBillingAgreementResult.FailureReasonCode);
                    }
                    if (validateBillingAgreementResult.IsSetBillingAgreementStatus())
                    {
                        Console.WriteLine("                BillingAgreementStatus");
                        BillingAgreementStatus billingAgreementStatus = validateBillingAgreementResult.BillingAgreementStatus;
                        if (billingAgreementStatus.IsSetState())
                        {
                            Console.WriteLine("                    State");
                            Console.WriteLine("                        {0}", billingAgreementStatus.State);
                        }
                        if (billingAgreementStatus.IsSetLastUpdatedTimestamp())
                        {
                            Console.WriteLine("                    LastUpdatedTimestamp");
                            Console.WriteLine("                        {0}", billingAgreementStatus.LastUpdatedTimestamp);
                        }
                        if (billingAgreementStatus.IsSetReasonCode())
                        {
                            Console.WriteLine("                    ReasonCode");
                            Console.WriteLine("                        {0}", billingAgreementStatus.ReasonCode);
                        }
                        if (billingAgreementStatus.IsSetReasonDescription())
                        {
                            Console.WriteLine("                    ReasonDescription");
                            Console.WriteLine("                        {0}", billingAgreementStatus.ReasonDescription);
                        }
                    }
                }
                if (response.IsSetResponseMetadata())
                {
                    Console.WriteLine("            ResponseMetadata");
                    ResponseMetadata responseMetadata = response.ResponseMetadata;
                    if (responseMetadata.IsSetRequestId())
                    {
                        Console.WriteLine("                RequestId");
                        Console.WriteLine("                    {0}", responseMetadata.RequestId);
                    }
                }
            }
            catch (OffAmazonPaymentsServiceException ex)
            {
                PrintException(ex);
            }
            return response;
        }

        public static ValidateBillingAgreementResponse ValidateBillingAgreement(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string billingAgreementId)
        {
            ValidateBillingAgreementRequest request = new ValidateBillingAgreementRequest();
            request.AmazonBillingAgreementId = billingAgreementId;
            request.SellerId = propertiesCollection.MerchantID;
            return InvokeValidateBillingAgreement(service, request);
        }
    }
}
