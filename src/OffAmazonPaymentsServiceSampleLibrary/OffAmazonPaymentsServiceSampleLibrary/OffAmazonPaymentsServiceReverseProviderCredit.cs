/*******************************************************************************
 *  Copyright 2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License");	
 *
 *  You may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at:
 *  http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License
 *  for the
 *  specific language governing permissions and limitations under the
 *  License.
 * *****************************************************************************	
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    /// <summary>
    /// This class drives the service ReverseProviderCredit sample, and contains the
    /// common logic across all sample code
    /// </summary>
    public class OffAmazonPaymentsServiceReverseProviderCredit
    {
        private IOffAmazonPaymentsService _service;
        private OffAmazonPaymentsServicePropertyCollection _propertiesCollection;
        private Random _rng;

        /// <summary>
        /// Create a new instance of the Service ReverseProviderCredit sample class
        /// </summary>
        public OffAmazonPaymentsServiceReverseProviderCredit()
        {
            // Instantiate the Merchant propertiesCollection object which contains required parameters for creating a Marketplace Payment Service
            this._propertiesCollection = OffAmazonPaymentsServicePropertyCollection.getInstance();
            this._service = new OffAmazonPaymentsServiceClient(this._propertiesCollection);
            this._rng = new Random();
        }

        //Invoke the ReverseProviderCredit method
        public ReverseProviderCreditResponse ReverseProviderCreditAction(string amazonProviderCreditId, string creditReversalAmount)
        {
            return ReverseProviderCreditSample.ReverseProviderCreditAction(this._service, this._propertiesCollection, this._rng, amazonProviderCreditId, creditReversalAmount);
        }

        //Invoke the GetProviderCreditReversalDetails method
        public GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(ReverseProviderCreditResponse reverseProviderCreditResponse)
        {
            return GetProviderCreditReversalDetailsSample.GetProviderCreditReversalDetails(this._service, this._propertiesCollection, reverseProviderCreditResponse.ReverseProviderCreditResult.ProviderCreditReversalDetails.AmazonProviderCreditReversalId);
        }
    }
}

