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
    /// This class drives the service refund sample, and contains the
    /// common logic across all sample code
    /// </summary>
    public class OffAmazonPaymentsServiceProviderRefund
    {
        private IOffAmazonPaymentsService _service;
        private OffAmazonPaymentsServicePropertyCollection _propertiesCollection;
        private Random _rng;

        /// <summary>
        /// Create a new instance of the Service Refund sample class
        /// </summary>
        public OffAmazonPaymentsServiceProviderRefund()
        {
            // Instantiate the Merchant propertiesCollection object which contains required parameters for creating a Marketplace Payment Service
            this._propertiesCollection = OffAmazonPaymentsServicePropertyCollection.getInstance();
            this._service = new OffAmazonPaymentsServiceClient(this._propertiesCollection);
            this._rng = new Random();
        }

        //Invoke the Refund method without Provider Credit Reversal.
        public RefundResponse RefundAction(string amazonCaptureID, string refundAmount)
        {
            return RefundSample.RefundAction(this._service, this._propertiesCollection, this._rng, amazonCaptureID, refundAmount, null, null);
        }

        //Invoke the Refund method with Provider Credit Reversal 
        public RefundResponse RefundActionWithProviderCreditReversal(string amazonCaptureID, string refundAmount, string providerId, string creditReversalAmountString)
        {
            return RefundSample.RefundAction(this._service, this._propertiesCollection, this._rng, amazonCaptureID, refundAmount, providerId, creditReversalAmountString);
        }

        //Invoke the GetRefundDetails method
        public GetRefundDetailsResponse GetRefundDetails(RefundResponse response)
        {
            return GetRefundDetailsSample.GetRefundDetails(this._service, this._propertiesCollection, response.RefundResult.RefundDetails.AmazonRefundId);
        }

        //Invoke the GetProviderCreditReversalDetails method
        public GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(ProviderCreditReversalSummary providerCreditReversalSummary)
        {
            return GetProviderCreditReversalDetailsSample.GetProviderCreditReversalDetails(this._service, this._propertiesCollection, providerCreditReversalSummary.ProviderCreditReversalId);
        }

        //Use a loop to check the status of the refund. Once the status is not "PENDING", it returns the response.
        public GetRefundDetailsResponse CheckRefundStatus(RefundResponse refundResponse)
        {
            return RefundSample.CheckRefundStatus(refundResponse.RefundResult.RefundDetails.AmazonRefundId, this._service, this._propertiesCollection);
        }
    }
}

