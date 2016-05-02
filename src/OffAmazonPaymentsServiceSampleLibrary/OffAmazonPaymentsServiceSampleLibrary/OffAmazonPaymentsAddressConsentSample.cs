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
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;
using OffAmazonPaymentsService;
using System.IO;

namespace OffAmazonPaymentsNotifications.Samples.Samples
{
    public class OffAmazonPaymentsAddressConsentSample
    {
        /************************************************************************
         * Address consent sample - for US users only
         * This demonstrates how the get order reference request returns additional
         * information about the merchant when an address consent token is passed in
         * from a user @@ProductName@@ session
         *
         * This use case requires the OffAmazonButton with the correct login options
         * scope - check the integration guide on how to setup the button for shipment
         * information details.
         *
         * This example will show the following service calls:
         *    - GetOrderReferenceDetails
        ***********************************************************************/

        public OffAmazonPaymentsAddressConsentSample(string orderReferenceId)
        {
            /************************************************************************
            * Instantiate the Merchant propertiesCollection object which contains required parameters for creating a Marketplace Payment Service  
            ***********************************************************************/
            propertiesCollection = OffAmazonPaymentsServicePropertyCollection.getInstance();

            /************************************************************************
            * Instantiate  Implementation of Marketplace Payment Service  
            ***********************************************************************/
            service = new OffAmazonPaymentsServiceClient(propertiesCollection);
            OrderReferenceId = orderReferenceId;
        }

        //Invoke the GetOrderReferenceDetailsWithoutConsent method
        public String GetOrderReferenceDetailsWithoutConsent()
        {
            TextWriter writer = new StringWriter();
            GetOrderReferenceDetailsSample.GetOrderReferenceDetails(propertiesCollection, service, OrderReferenceId, null, writer);
            return writer.ToString();
        }

        //Invoke the GetOrderReferenceDetailsWithConsent method
        public String GetOrderReferenceDetailsWithConsent(string addressConsentToken)
        {
            TextWriter writer = new StringWriter();
            GetOrderReferenceDetailsSample.GetOrderReferenceDetails(propertiesCollection, service, OrderReferenceId, addressConsentToken, writer);
            return writer.ToString();
        }

        public string OrderReferenceId
        {
            get { return orderReferenceId; }
            set { orderReferenceId = value; }
        }

        private string orderReferenceId;
        private OffAmazonPaymentsServicePropertyCollection propertiesCollection;
        private OffAmazonPaymentsServiceClient service;
    }
}
