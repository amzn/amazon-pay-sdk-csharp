/*******************************************************************************
 *  Copyright 2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    public abstract class SampleBase
    {
        public static void PrintException(OffAmazonPaymentsServiceException ex)
        {
            Console.WriteLine("Caught Exception: " + ex.Message);
            Console.WriteLine("Response Status Code: " + ex.StatusCode);
            Console.WriteLine("Error Code: " + ex.ErrorCode);
            Console.WriteLine("Error Type: " + ex.ErrorType);
            Console.WriteLine("Request ID: " + ex.RequestId);
            Console.WriteLine("XML: " + ex.XML);
            Console.WriteLine("ResponseHeaderMetadata: " + ex.ResponseHeaderMetadata);
        }
    }
}

