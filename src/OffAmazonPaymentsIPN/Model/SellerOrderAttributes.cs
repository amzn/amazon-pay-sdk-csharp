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

using System.Xml.Serialization;

namespace OffAmazonPaymentsNotifications
{
    public class SellerOrderAttributes
    {

        private string sellerIdField;

        private string sellerOrderIdField;

        private string[] orderItemCategoriesField;

        /// <remarks/>
        public string SellerId
        {
            get
            {
                return this.sellerIdField;
            }
            set
            {
                this.sellerIdField = value;
            }
        }

        /// <remarks/>
        public string SellerOrderId
        {
            get
            {
                return this.sellerOrderIdField;
            }
            set
            {
                this.sellerOrderIdField = value;
            }
        }

        /// <remarks/>
        [XmlArrayItemAttribute("String", IsNullable = false)]
        public string[] OrderItemCategories
        {
            get
            {
                return this.orderItemCategoriesField;
            }
            set
            {
                this.orderItemCategoriesField = value;
            }
        }
    }
}