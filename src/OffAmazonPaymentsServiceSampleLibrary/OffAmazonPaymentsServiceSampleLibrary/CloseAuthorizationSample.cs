/******************************************************************************* 
 *  Copyright 2008-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    public class CloseAuthorizationSample : SampleBase
    {
        public static CloseAuthorizationResponse InvokeCloseAuthorization(IOffAmazonPaymentsService service, CloseAuthorizationRequest request)
        {
            CloseAuthorizationResponse response = null;
            try
            {
                response = service.CloseAuthorization(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        CloseAuthorizationResponse");
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
                Console.WriteLine();
            }
            catch (OffAmazonPaymentsServiceException ex)
            {
                PrintException(ex);
            }

            return response;
        }
    }
}

